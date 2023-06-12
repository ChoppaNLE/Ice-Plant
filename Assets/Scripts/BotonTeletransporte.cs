using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonTeletransporte : MonoBehaviour
{
     [SerializeField]
     private Teletransporte[] teleportesAsociados = new Teletransporte[2];
     

    // Start is called before the first frame update
    void Start()
    {
          teleportesAsociados[0].gameObject.transform.GetChild(3).gameObject.SetActive(false);  
          teleportesAsociados[1].gameObject.transform.GetChild(3).gameObject.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
         if (teleportesAsociados[0].gameObject.transform.GetChild(3).gameObject.activeSelf == false){
              teleportesAsociados[0].gameObject.transform.GetChild(3).gameObject.SetActive(true); 
              teleportesAsociados[1].gameObject.transform.GetChild(3).gameObject.SetActive(true);  
         }   
    }

    private void OnTriggerExit2D(Collider2D col)
    {
         teleportesAsociados[0].gameObject.transform.GetChild(3).gameObject.SetActive(false);  
         teleportesAsociados[1].gameObject.transform.GetChild(3).gameObject.SetActive(false); 
    }
}
