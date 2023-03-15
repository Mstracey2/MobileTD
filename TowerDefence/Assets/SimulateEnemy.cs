using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateEnemy : MonoBehaviour
{
    public bool running;
    public bool success;
    public Vector3 returnPos;

    private void Start()
    {
        returnPos = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            success = false;
            running = false;
        }
        else if(collision.gameObject.name == "SafeHouse")
        {
            success = true;
        }
    }
}
