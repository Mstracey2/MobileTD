using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// different resource types
/// </summary>
public enum ResourceType
{
    Brown,
    Blue,
    Purple,
    Yellow,
    money,
}

public class SafeHouseManager : MonoBehaviour
{
    [SerializeField] private List<ResourceCounter> playerResources = new List<ResourceCounter>();       //counter for each resource
    [SerializeField] private int health;
    [SerializeField] private HealthBar bar;
    [SerializeField] private GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        bar.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)            //GAME OVER
        {
            gameOver.SetActive(true);
            BuildingSystem.currentSystem.buildMode = true;
        }
    }

    /// <summary>
    /// collision with enemy, removes health
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(collision.gameObject);
            bar.SetHealth(health);
            Destroy(collision.gameObject);
            GameManager.manager.UpdateEnemiesInPlay();      //checks for null references
        }
    }


    /// <summary>
    /// function that add the corrolating resource to the counter
    /// </summary>
    /// <param name="resource"></param>
    public void AddResourceToPlayerResourceInv(ResourceType resource)
    {
        foreach (ResourceCounter thisType in playerResources)
        {
            if (thisType.GetResourceType() == resource)
            {
                thisType.AddToCounter();    
            }
        }
    }

    public void TakeDamage(GameObject enim)
    {
        EnemyScript enimScript = enim.GetComponent<EnemyScript>();
        health -= enimScript.damage;
        bar.SetHealth(health);
    }
}
