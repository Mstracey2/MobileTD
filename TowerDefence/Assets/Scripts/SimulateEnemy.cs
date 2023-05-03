using UnityEngine;

public class SimulateEnemy : MonoBehaviour
{
    public bool running;            //checks if the simulation enemy is running
    public bool success;            //checks if the simulation enemy succceded
    public Vector3 returnPos;       //return position once task is done
    public Vector3 oldPos;          //tracks old position, fails the simulation if the enemy sticks around this position for too long
    public float maxTime = 6;       //time it takes to check old position
    public float timer;
    public float dis;

    private void Start()
    {
        timer = maxTime;
        oldPos = transform.position;
        returnPos = transform.position;
    }

    private void Update()
    {
        if (running)
        {
            timer -= Time.deltaTime;
        }

        //checks to see if enemy sim is stuck
        if (timer <= 0)
        {
            dis = Vector3.Distance(transform.position, oldPos);
            if (dis < 3)
            {
                success = false;
                running = false;
            }
            else
            {
                oldPos = transform.position;
            }
            timer = maxTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            success = false;
            running = false;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SafeHouse")//if the sim reaches the safehouse, its successful
        {
            success = true;
        }
    }
}
