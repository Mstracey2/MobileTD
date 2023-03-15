using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : GeneralPawnScript
{
    private float health;
    private float maxHealth = 50;
    [SerializeField] private HealthBar healthBar;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
         if(health <= 0)
         {
            Destroy(this.gameObject);
         }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == groundPlane || collision.gameObject == safehouse)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int dam)
    {
        health -= dam;
        healthBar.SetHealth(health);
    }


}
