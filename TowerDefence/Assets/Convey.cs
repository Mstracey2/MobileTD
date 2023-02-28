using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum directionOfMomentum
{
    up = 1,
    down = 3,
    left = 4,
    right = 2
}


public class Convey : MonoBehaviour
{
    [SerializeField] private Vector3 force;

    List<Rigidbody> currentPawns = new List<Rigidbody>();
    public  directionOfMomentum movement;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckDirection();

        foreach(Rigidbody thisRid in currentPawns)
        {
            thisRid.AddForce(force * 10 * Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        currentPawns.Add(other.GetComponent<Rigidbody>());
    }

    private void OnTriggerExit(Collider other)
    {
        currentPawns.Remove(other.GetComponent<Rigidbody>());
    }

    public void CheckDirection()
    {
        if(movement == directionOfMomentum.up)
        {
            force = new Vector3(0, 0, 1);
        }
       else if (movement == directionOfMomentum.down)
        {
            force = new Vector3(0, 0, -1);
        }
        else if (movement == directionOfMomentum.left)
        {
            force = new Vector3(-1, 0, 0);
        }
       else if (movement == directionOfMomentum.right)
        {
            force = new Vector3(1, 0, 0);
        }
    }


    public void ChangeDirection()
    {
        
        if (movement.Equals(directionOfMomentum.left))
        {
            movement = directionOfMomentum.up;
        }
        else
        {
            movement++;
        }
    }
}
