using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteredSafeHouse : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
