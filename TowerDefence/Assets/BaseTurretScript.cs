using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurretScript : MonoBehaviour
{
    protected List<GameObject> enemiesInView = new List<GameObject>();
    [SerializeField] private GameObject barrel;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float cooldownLength;
    private float coolDown;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInView.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInView.Remove(other.gameObject);
        }
    }

    public void Timer()
    {
        if(enemiesInView.Count != 0 && BuildingSystem.currentSystem.buildMode == false)
        {
            coolDown -= Time.deltaTime;
            if (coolDown <= 0)
            {
                Shoot();
                coolDown = cooldownLength;
            }
        }
        else
        {
            coolDown = 0;
        }
        
    }

    public void Shoot()
    {
            GameObject newBullet = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
    }

    public void CheckForMissingObjects()
    {
        foreach(GameObject thisEnemy in enemiesInView)
        {
            if(thisEnemy == null)
            {
                enemiesInView.Remove(thisEnemy);
                break;
            }
        }
    }
}
