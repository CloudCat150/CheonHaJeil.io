using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class NetworkClient : MonoBehaviour
{
    private TcpClient client;
    private NetworkStream stream;

    void Start()
    {
        client = new TcpClient("127.0.0.1", 12345);
        stream = client.GetStream();
        Debug.Log("Connected to server");
    }

    void Update()
    {
        // Send player input to server
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        string message = $"MOVE:{input.x},{input.y}";
        SendToServer(message);

        if (Input.GetButtonDown("Fire1"))
        {
            string shootMessage = "SHOOT";
            SendToServer(shootMessage);
        }
    }

    void SendToServer(string message)
    {
        byte[] data = Encoding.UTF8.GetBytes(message);
        stream.Write(data, 0, data.Length);
    }

    private void OnApplicationQuit()
    {
        stream.Close();
        client.Close();
    }
}
