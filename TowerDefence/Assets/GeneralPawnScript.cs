using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralPawnScript : MonoBehaviour
{
    [SerializeField] private GameObject safehouse;
    [SerializeField] private GameObject groundPlane;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == groundPlane || collision.gameObject == safehouse)
        {
            Destroy(this.gameObject);
        }
        
    }

    public void getReferences(GameObject house, GameObject plane)
    {
        safehouse = house;
        groundPlane = plane;
    }
}
