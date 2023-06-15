using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
  
    private int playersInZoneCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            playersInZoneCount++;
            if (playersInZoneCount >= 2)
            {
                GameManager.Instance.NextLevel();
            }
        }
        else if (collision.CompareTag("Player2"))
        {
            playersInZoneCount++;
            
            if (playersInZoneCount >= 2)
            {
                GameManager.Instance.NextLevel();
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            playersInZoneCount--;
        }
    }
}
