using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    [SerializeField]private GameManager gameManager;

    private void Start()
    {
        // Obtener una referencia al GameManager
        //gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            Destroy(collision.gameObject);

            // Pausar el juego y esperar un tiempo antes de cargar la escena del menú
            Invoke("CallExitDead", 1f);
        }
    }

    private void CallExitDead()
    {
        gameManager.OnExitDead();
    }
}
