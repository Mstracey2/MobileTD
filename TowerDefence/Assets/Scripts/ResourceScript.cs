using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScript : GeneralPawnScript
{
    public ResourceType resource;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == safehouse)
        {
            safehouse.GetComponent<SafeHouseManager>().AddResourceToPlayerResourceInv(resource);
            Destroy(this.gameObject);
        }
        if (collision.gameObject == groundPlane)
        {
            transform.position = objectHome.transform.position;
        }
    }
}
