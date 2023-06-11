using UnityEngine;

public class Droopeable : MonoBehaviour
{
    [SerializeField] private int pointsPlayer1 = 5;
    [SerializeField] private int pointsPlayer2 = 5;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player1"))
        {
            // Sumar puntos al jugador 1
            GameManager.Instance.AddPointsToPlayer(1, pointsPlayer1);
        }
        else if (collision.CompareTag("Player2"))
        {
            // Sumar puntos al jugador 2
            GameManager.Instance.AddPointsToPlayer(2, pointsPlayer2);
        }

        Destroy(gameObject);
    }
}