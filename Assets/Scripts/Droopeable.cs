using UnityEngine;

public class Droopeable : MonoBehaviour
{
    
    [SerializeField] private int pointsPlayer1 = 5;
    [SerializeField] private int pointsPlayer2 = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            if (collision.CompareTag("Player1"))
            {
                gameManager.AddPointsToPlayer(1, pointsPlayer1);
            }
            else if (collision.CompareTag("Player2")) gameManager.AddPointsToPlayer(2, pointsPlayer2);
        }

        Destroy(gameObject);
    }
    }


