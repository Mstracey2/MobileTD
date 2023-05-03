using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// enum for direction of the road movement flow
/// </summary>
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
    public directionOfMomentum movement;

    // Update is called once per frame
    void Update()
    {
      CheckDirection();
    }

    private void OnCollisionStay(Collision collision)
    {
        if(BuildingSystem.currentSystem.buildMode == false || collision.gameObject.name == "SimEnemy")          //will add force to any rigid body if not in build mode or sim mode
        {
            collision.gameObject.transform.position = collision.gameObject.transform.position + force * 2 * Time.deltaTime;
        }
       
    }


    /// <summary>
    /// changes force direction depending on the enum variable direction
    /// </summary>
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

    /// <summary>
    /// function to change the direction of movement if the road is rotated
    /// </summary>
    public void ChangeDirection()
    { 
        if (movement.Equals(directionOfMomentum.left)) // if the direction is left, it will loop back to the first enum (up).
        {
            movement = directionOfMomentum.up;
        }
        else
        {
            movement++;
        }
    }
}
