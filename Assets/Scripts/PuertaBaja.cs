using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaBaja : MonoBehaviour
{
    public Transform destiny;
    private float speed;
    public bool towardsDown;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
         initialPosition = transform.position;
         speed = 2f;
         towardsDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        if (transform.position.y > destiny.position.y && towardsDown)
        {
          transform.position = Vector3.MoveTowards(transform.position, destiny.position, step);
        }

        if (transform.position.y < initialPosition.y && !towardsDown)
        {
          transform.position = Vector3.MoveTowards(transform.position, initialPosition, step);
        }  
    }

}
