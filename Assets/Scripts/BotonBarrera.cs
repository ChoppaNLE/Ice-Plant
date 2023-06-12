using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonBarrera : MonoBehaviour
{
    [SerializeField]
    private GameObject barreraAsociada;
     
    // Start is called before the first frame update
    void Start()
    {
          barreraAsociada.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
          barreraAsociada.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
         barreraAsociada.SetActive(true);
    }
}
