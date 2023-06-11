
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;

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
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Levers");
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
}