using UnityEngine;

public class SimulateEnemy : MonoBehaviour
{
    public bool running;
    public bool success;
    public Vector3 returnPos;
    public Vector3 oldPos;
    public float maxTime = 6;
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
        else if (collision.gameObject.name == "SafeHouse")
        {
            success = true;
        }
    }
}
