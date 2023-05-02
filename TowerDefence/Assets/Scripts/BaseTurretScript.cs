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

    /// <summary>
    /// basic cooldown check method, if cooldown is 0, it will shoot.
    /// </summary>
    public void CheckCooldown()
    {
        if (enemiesInView.Count != 0 && BuildingSystem.currentSystem.buildMode == false)            
        {
            if (coolDown <= 0)
            {
                Shoot();
                coolDown = cooldownLength;                                                          //resets cooldown
            }
        }
        else
        {
            coolDown = 0;
        }

    }


    /// <summary>
    /// instansiates a new bullet at the location of each barrel end.
    /// </summary>
    public void Shoot()
    {
        foreach (GameObject thisBarrel in barrel)
        {
            GameObject newBullet = Instantiate(bullet, thisBarrel.transform.position, thisBarrel.transform.rotation);
        }

    }


    /// <summary>
    /// this is a function that will check for any objects that are missing in the list, its a failsafe to stop the list from having troubles searching for null variables.
    /// </summary>
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


    /// <summary>
    /// updates the rotation of the object to look the first enemy on the list.
    /// </summary>
    public void LookAtObject()
    {
        if (enemiesInView.Count != 0 && enemiesInView[0] != null)                       //will not run if no targets are in sight
        {
            Transform targetAxis = enemiesInView[0].transform;
            transform.parent.LookAt(new Vector3(targetAxis.position.x, transform.parent.position.y, targetAxis.position.z));
        }
    }
}
