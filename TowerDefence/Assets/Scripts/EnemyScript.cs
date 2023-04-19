using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float health;
    private float maxHealth = 50;
    public int damage = 10;
    private Vector3 objectHome;
    [SerializeField] private HealthBar healthBar;

    private void Start()
    {
        health = maxHealth;
        objectHome = transform.position;
    }

    private void Update()
    {
         if(health <= 0)
         {
            GameManager.manager.enemiesInPlay.Remove(this.gameObject);
            Destroy(this.gameObject);
         }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.position = objectHome;
        }
    }

    public void TakeDamage(int dam)
    {
        health -= dam;
        healthBar.SetHealth(health);
    }


}
