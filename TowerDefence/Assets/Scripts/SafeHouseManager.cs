using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] private List<ResourceCounter> playerResources = new List<ResourceCounter>();
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
        if (health <= 0)
        {
            gameOver.SetActive(true);
            BuildingSystem.currentSystem.buildMode = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(collision.gameObject);
            bar.SetHealth(health);
            Destroy(collision.gameObject);
            GameManager.manager.UpdateEnemiesInPlay();
        }
    }
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
