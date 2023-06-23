using UnityEngine;

public class Droopeable : MonoBehaviour
{
    
    private int pointsPlayer1 = 1;
    private int pointsPlayer2 = 1;
    public string type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            if (collision.CompareTag("Player1") & type == "ice")
            {
                gameManager.AddPointsToPlayer(1, pointsPlayer1);
                Destroy(gameObject);
            }
            else if (collision.CompareTag("Player2") & type == "plant")
            {
                gameManager.AddPointsToPlayer(2, pointsPlayer2);
                Destroy(gameObject);
            } 
        }
    }

}


