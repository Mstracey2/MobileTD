using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurretScript : MonoBehaviour
{
    protected List<GameObject> enemiesInView = new List<GameObject>();
    [SerializeField] private List<GameObject> barrel = new List<GameObject>();
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

    private void Update()
    {
        CheckForMissingObjects();
        Timer();
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
        foreach(GameObject thisBarrel in barrel)
        {
            GameObject newBullet = Instantiate(bullet, thisBarrel.transform.position, thisBarrel.transform.rotation);
        }
           
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
