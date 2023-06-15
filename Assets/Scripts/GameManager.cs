using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Canvas levelCanvas;
    [SerializeField] private TextMeshProUGUI youLosetext;
    [SerializeField] private TextMeshProUGUI youWintext;
    [SerializeField] private TextMeshProUGUI levelMessage;
    public static GameManager Instance { get; private set; }
    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;
    private bool isPaused = false;
    private int currentLevel = 1;
    private void Awake()
    {
        // Verificar si ya existe una instancia del GameManager y destruir esta si es el caso
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Recuperar el valor de currentLevel desde PlayerPrefs
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        
        levelCanvas.enabled = false;
        youLosetext.enabled = false;
        youWintext.enabled = false;
    }
    private void OnDestroy()
    {
        // Guardar el valor de currentLevel en PlayerPrefs antes de cambiar de escena
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
    }
    public void LoadFirstLevel()
    {
        currentLevel = 1;
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f; // Reanudar el juego
    }

    private void ShowLevelMessage()
    {
        levelMessage.enabled = false;
    }


public void AddPointsToPlayer(int playerNumber, int points)
    {
        if (playerNumber == 1)
        {
            scorePlayer1 += points;
            Debug.Log("Player 1 Score: " + scorePlayer1);
        }
        else if (playerNumber == 2)
        {
            scorePlayer2 += points;
            Debug.Log("Player 2 Score: " + scorePlayer2);
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausar el juego
            levelCanvas.enabled = true;
        }
        else
        {
            Time.timeScale = 1f; // Reanudar el juego
            levelCanvas.enabled = false;
        }
    }
    public void OnExitButtonClicked()
    {
        
        SceneManager.LoadScene("Start");

    }
    public void OnExitDead()
    {
        youLosetext.enabled = true;
        Invoke("LoadStartScene", 1f);

    }

    private void LoadStartScene()
    {
        currentLevel = 1;
        Time.timeScale = 1f;
        youLosetext.enabled = false;
        youWintext.enabled = false;
        SceneManager.LoadScene("Start");
    }
    
    public void NextLevel()
    {
        currentLevel++;
        Debug.Log(currentLevel);
        switch (currentLevel)
        {
            case 4:
                youWintext.enabled = true;
            
                Invoke("LoadStartScene",1f);
                break;
            default:
                SceneManager.LoadScene("Level" + currentLevel);
                Invoke("ShowLevelMessage",1f);
                break;
        }
    }
    
    
}