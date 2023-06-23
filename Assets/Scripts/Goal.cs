using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeSpan;

public class Goal : MonoBehaviour
{
  
    private int playersInZoneCount = 0;
    
    [SerializeField]private Canvas playerPointsCanvas;
    [SerializeField]private TextMeshProUGUI player1PointsText;
    [SerializeField]private TextMeshProUGUI player2PointsText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            playersInZoneCount++;
            if (playersInZoneCount >= 2)
            {
                CheckAndActivateNextLevel();
            }
        }
        else if (collision.CompareTag("Player2"))
        {
            playersInZoneCount++;
            
            if (playersInZoneCount >= 2)
            {
                CheckAndActivateNextLevel();
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
    
    private void CheckAndActivateNextLevel()
    {
        GameManager.Instance.NextLevel();
       
    }
    
    
}
