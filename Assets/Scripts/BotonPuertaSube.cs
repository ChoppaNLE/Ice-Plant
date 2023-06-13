using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPuertaSube : MonoBehaviour
{
    [SerializeField]
    private PuertaSube puertaAsociada;
     
    // Start is called before the first frame update
    void Start()
    {
          //puertaAsociada.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
          puertaAsociada.towardsUp = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
         puertaAsociada.towardsUp = false;
    }
}
