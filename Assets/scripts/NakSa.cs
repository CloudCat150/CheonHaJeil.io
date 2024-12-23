using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NakSa : MonoBehaviour
{
    private bool isInsideTrigger = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Background"))
        {
            isInsideTrigger = true;
            Debug.Log("Player entered the trigger.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Background"))
        {
            isInsideTrigger = false;
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("Game Over!");
        gameObject.SetActive(false);
    }
}