using System.Collections.Generic;
using UnityEngine;

public class BaseTurretScript : MonoBehaviour
{
    [SerializeField] protected List<GameObject> enemiesInView = new List<GameObject>();             //keeps track of enimies in vision
    [SerializeField] private List<GameObject> barrel = new List<GameObject>();                      //each barrel that the turret shoots out of
    [SerializeField] private GameObject bullet;
    [SerializeField] protected float cooldownLength;
    protected float coolDown;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInView.Add(other.gameObject);                                                    //adds enemy to view list
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInView.Remove(other.gameObject);                                                 //removes enemey from view list
        }
    }

    private void Update()
    {
        coolDown -= Time.deltaTime;                                                                // gun will not shoot unless cool down reaches 0
        CheckForMissingObjects();
        LookAtObject();
        CheckCooldown();
    }

    public void CheckCooldown()
    {
        if (enemiesInView.Count != 0 && BuildingSystem.currentSystem.buildMode == false)            
        {
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
        foreach (GameObject thisBarrel in barrel)
        {
            GameObject newBullet = Instantiate(bullet, thisBarrel.transform.position, thisBarrel.transform.rotation);
        }

    }

    public void CheckForMissingObjects()
    {
        foreach (GameObject thisEnemy in enemiesInView)
        {
            if (thisEnemy == null)
            {
                enemiesInView.Remove(thisEnemy);
                break;
            }
        }
    }

    public void LookAtObject()
    {
        if (enemiesInView.Count != 0 && enemiesInView[0] != null)
        {
            Transform targetAxis = enemiesInView[0].transform;
            transform.parent.LookAt(new Vector3(targetAxis.position.x, transform.parent.position.y, targetAxis.position.z));
        }
    }
}
