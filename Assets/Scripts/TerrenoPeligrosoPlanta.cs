using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrenoPeligrosoPlanta : MonoBehaviour
{
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
          if (col.gameObject.CompareTag("Player1")){
               col.gameObject.SetActive(false);
          }
    }
}
