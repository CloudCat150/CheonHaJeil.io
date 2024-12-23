using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using System.Collections.Concurrent;

public class UserMoving : MonoBehaviour
{
    private TcpClient client;
    private Thread readThread;
    private NetworkStream stream;
    private StreamWriter writer;
    private ConcurrentDictionary<string, Vector2> playerPositions = new ConcurrentDictionary<string, Vector2>();

    public GameObject playerPrefab; // 플레이어 프리팹
    private GameObject localPlayer; // 로컬 플레이어
    private string playerId; // 고유 ID
    private Vector2 position;

    void Start()
    {
        ConnectToServer();
        playerId = "1"; // 클라이언트 ID 생성
    }

    private void ConnectToServer()
    {
        try
        {
            Debug.Log("서버에 연결 중...");
            client = new TcpClient("10.198.150.140", 8000); // 서버 주소 및 포트
            Debug.Log("서버에 연결되었습니다.");

            stream = client.GetStream();
            writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
            Debug.LogError($"b");
            readThread = new Thread(ReadMessages);
            readThread.Start();
        }
        catch (Exception ex)
        {
            Debug.LogError($"서버 연결 실패: {ex.Message}");
        }
    }

    private void ReadMessages()
    {
        try
        {
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            while (true)
            {
                try
                {
                    string message = reader.ReadLine();
                    if (message == null) break;
                    Debug.Log($"서버 메시지: {message}");
                    ProcessServerMessage(message);
                }
                catch
                {
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"4");
            Debug.LogError($"메시지 읽기 실패: {ex.Message}");
        }
        finally
        {
            Debug.LogError($"5");
            Disconnect();
        }
    }

    private void ProcessServerMessage(string message)
    {
        try
        {
            Debug.LogError($"main: {message}");
            string[] parts = message.Split(':');
            string id = parts[0];
            string[] coords = parts[1].Split(',');
            Debug.Log($"서버 메시지: {float.Parse(coords[0])} {float.Parse(coords[1])}");
            // 메인 스레드에서 실행되도록 UnityMainThreadDispatcher 사용
            UnityMainThreadDispatcher.Enqueue(() =>
            {
                transform.position = new Vector2(float.Parse(coords[0]), float.Parse(coords[1]));
            });
            transform.position = new Vector2(float.Parse(coords[0]), float.Parse(coords[1]));
        }
        catch (Exception ex)
        {
            Debug.LogError($"서버 메시지 처리 실패: {ex.Message}");
        }
    }


    private void Disconnect()
    {
        Debug.Log("서버와의 연결 종료.");
        stream?.Close();
        client?.Close();
        if (readThread != null && readThread.IsAlive)
        {
            readThread.Abort();
        }
    }

    void OnApplicationQuit()
    {
        Disconnect();
    }
}
