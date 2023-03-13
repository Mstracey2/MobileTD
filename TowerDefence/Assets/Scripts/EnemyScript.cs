using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : GeneralPawnScript
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == groundPlane || collision.gameObject == safehouse)
        {
            Destroy(this.gameObject);
        }
    }


}
