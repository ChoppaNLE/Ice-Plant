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
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            
            UpdatePlayerPointsText();
        }
        else
        {
            GameManager.Instance.NextLevel();
        }
    }

    private async void UpdatePlayerPointsText()
    {
        player1PointsText.text = "Points: " + GameManager.PointsData.player1Points.ToString();
        player2PointsText.text = "Points: " + GameManager.PointsData.player2Points.ToString();

        playerPointsCanvas.enabled = true;
        await Task.Delay(FromSeconds(value: 2)); // Espera durante 2 segundos
        GameManager.Instance.NextLevel();
        playerPointsCanvas.enabled = false;
    }
    
    
}
