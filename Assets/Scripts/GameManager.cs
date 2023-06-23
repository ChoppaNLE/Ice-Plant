using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using static System.TimeSpan;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI youLosetext;
    [SerializeField] private TextMeshProUGUI youWintext;
    [SerializeField] private Canvas pauseMenu;
    public static GameManager Instance { get; private set; }
    private bool isPaused = false;
    private int currentLevel = 1;
    private int finalTime = 0;
    public TMP_InputField namePlayer1;
    public TMP_InputField namePlayer2;
    private string player1;
    private string player2;
    public TextMeshProUGUI plantPoints;
    public TextMeshProUGUI icePoints;
    public ScoreManager scoreManager;

    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
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
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", currentLevel);
        player1 = PlayerPrefs.GetString("player1", player1);
        player2 = PlayerPrefs.GetString("player2", player2);

        youLosetext.enabled = false;
        youWintext.enabled = false;
        pauseMenu.enabled = false;
        if (currentLevel == 4)
        {
             scoreManager.AddScore(new Score(player1 + "/" + player2, PointsData.player1Points + PointsData.player2Points));   
        }

    }

    private void OnDestroy()
    {
        // Guardar el valor de currentLevel en PlayerPrefs antes de cambiar de escena
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.SetString("player1", player1);
        PlayerPrefs.SetString("player2", player2);

    }

    public void LoadFirstLevel()
    {
        currentLevel = 1;
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f; // Reanudar el juego
        player1 = namePlayer1.text;
        player2 = namePlayer2.text;

    }

    public void LoadNameSelecting()
    {
        SceneManager.LoadScene("NameSelecting");
        Time.timeScale = 0f; // Parar el juego
    }

    public void LoadScores()
    {
        SceneManager.LoadScene("Scores");
        Time.timeScale = 0f; // Parar el juego
    }

    public void LoadStart()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 0f; // Parar el juego
    }

    public void AddPointsToPlayer(int playerNumber, int points)
    {
        if (playerNumber == 1)
        {
            PointsData.player1Points += points;
            icePoints.text = (int.Parse(icePoints.text) + 1).ToString();
        }
        else if (playerNumber == 2)
        {
            PointsData.player2Points += points;
            plantPoints.text = (int.Parse(plantPoints.text) + 1).ToString();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausar el juego
            pauseMenu.enabled = true;
        }
        else
        {
            Time.timeScale = 1f; // Reanudar el juego
            pauseMenu.enabled = false;
        }
    }

    public void OnExitButtonClicked()
    {
        SceneManager.LoadScene("Start");
    }

    public void OnExitDead()
    {
        youLosetext.enabled = true;
        currentLevel --;
        Invoke("NextLevel", 2f);
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
        currentLevel ++;
        switch (currentLevel)
        {
            case 4:
                youWintext.enabled = true;
                Invoke("Ranks", 2f);
                break;
            default:
                SceneManager.LoadScene("Level" + currentLevel);
                break;
        }
    }

    public void Ranks()
    {
        SceneManager.LoadScene("Scores");
    }
    
    public static class PointsData
    {
        public static int player1Points = 0;
        public static int player2Points = 0;
    }
}