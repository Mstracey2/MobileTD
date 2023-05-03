using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraBounds : MonoBehaviour
{

    [SerializeField] private GameObject xbound;
    [SerializeField] private GameObject zbound;
    [SerializeField] private GameObject xandzbound;
    [SerializeField] private GameObject yBound;


    /// <summary>
    /// update is used here to limit how far the camera can go, they cannot go beyond the map
    /// </summary>
    private void Update()
    {
        if(transform.position.y >= yBound.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, yBound.transform.position.y, transform.position.z);
        }
        if (transform.position.y <= xandzbound.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, xandzbound.transform.position.y, transform.position.z);
        }
        if (transform.position.x >= xandzbound.transform.position.x)
        {
            transform.position = new Vector3(xandzbound.transform.position.x,transform.position.y,transform.position.z);
        }
        if(transform.position.z >= xandzbound.transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, xandzbound.transform.position.z);
        }
        if (transform.position.z <= zbound.transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zbound.transform.position.z);
        }
        if (transform.position.x <= xbound.transform.position.x)
        {
            transform.position = new Vector3(xbound.transform.position.x, transform.position.y,transform.position.z);
        }
    }
}
