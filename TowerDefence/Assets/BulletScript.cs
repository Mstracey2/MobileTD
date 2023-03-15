using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int speed;
    private float bulletTime = 5;
    private int bulletDamage = 10;

    // Update is called once per frame
    void Update()
    {
        bulletTime -= Time.deltaTime;
        if(bulletTime <= 0)
        {
            Destroy(this.gameObject);
        }
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyScript>().TakeDamage(bulletDamage);
            Destroy(this.gameObject);
        }
    }
}
