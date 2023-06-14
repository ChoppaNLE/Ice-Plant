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
    private int playerone = 0;
    private int playertwo= 0;
    private int playersAtGoal = 0;
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

        levelCanvas.enabled = false;
        youLosetext.enabled = false;
        youWintext.enabled = false;
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Levers");
        Time.timeScale = 1f; // Reanudar el juego
        StartCoroutine(ShowLevelMessage());


    }

    private IEnumerator ShowLevelMessage()
    {
        levelMessage.text = "If you fall to hell , you lose";
        levelMessage.enabled = true; // Asegurarse de que el texto esté habilitado

        yield return new WaitForSeconds(1f); 

        levelMessage.text = "¡Platforms green and white are levers ";
        yield return new WaitForSeconds(1f); 
        levelMessage.enabled = false; // Deshabilitar el texto después de mostrar los mensajes
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
        //youLosetext.enabled = false;
        //youWintext.enabled = false;
        SceneManager.LoadScene("Level2");
    }
    
    
    public void IncrementPlayersAtGoal(string player)
    {
 
        if (player == "one")
        {
            playerone++;
        }
        else
        {
            playertwo++;
        }
        playersAtGoal = playerone + playertwo;
        if (playersAtGoal >= 2)
        {
            // Ambos jugadores han llegado a su meta, el juego se gana aquí
            GameWin();
        }
    }
    public void GameWin()
    {

        //youWintext.enabled = true;
        Invoke("LoadStartScene", 1f);
    }   
    
    
}