using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransporte : MonoBehaviour
{
     [SerializeField]
     private Teletransporte teleporteAsociado;
     private bool llegada;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
         if (this.gameObject.transform.GetChild(6).gameObject.activeSelf){
              if (llegada == false){
                    col.transform.position = teleporteAsociado.transform.position;
                    teleporteAsociado.llegada = true;
              }else{
                   llegada = false;
              }
         }
    }

}
