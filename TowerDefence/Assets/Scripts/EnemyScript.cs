using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float health;
    private float maxHealth = 50;
    public int damage = 10;
    private Vector3 objectHome;                       //used to respawn the enemy if it falls off the road
    [SerializeField] private HealthBar healthBar;

    private void Start()
    {
        health = maxHealth;
        objectHome = transform.position;
    }

    private void Update()
    {
         if(health <= 0)                              // removes enemy if health is 0
         {
            GameManager.manager.enemiesInPlay.Remove(this.gameObject);
            Destroy(this.gameObject);
         }   
    }


    /// <summary>
    /// returns the enemy back to the place it spawned if it falls off the road
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.position = objectHome;
        }
    }


    /// <summary>
    /// function to take damage when hit by a bullet
    /// </summary>
    /// <param name="dam"></param>
    public void TakeDamage(int dam)
    {
        health -= dam;
        healthBar.SetHealth(health);
    }


}
