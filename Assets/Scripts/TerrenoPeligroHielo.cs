using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrenoPeligroHielo : MonoBehaviour
{
    [SerializeField]private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
          if (col.gameObject.CompareTag("Player2")){
               col.gameObject.SetActive(false);
               gameManager.OnExitDead();
          }
          
          
    }
}
