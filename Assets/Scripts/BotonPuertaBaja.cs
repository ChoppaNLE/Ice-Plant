using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPuertaBaja : MonoBehaviour
{
    [SerializeField]
    private PuertaBaja puertaAsociada;
     
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
          puertaAsociada.towardsDown = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
         puertaAsociada.towardsDown = false;
    }
}
