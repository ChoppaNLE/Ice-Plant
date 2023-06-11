using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            // Incrementar el contador de jugadores en el GameManager
            GameManager.Instance.IncrementPlayersAtGoal("one");

            // Otros efectos o acciones que desees realizar cuando un jugador llega a su meta
        }
        else if (other.CompareTag("Player2"))
        {
            // Incrementar el contador de jugadores en el GameManager
            GameManager.Instance.IncrementPlayersAtGoal("two");

            // Otros efectos o acciones que desees realizar cuando un jugador llega a su meta
        }
    }
}
