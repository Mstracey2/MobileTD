using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralPawnScript : MonoBehaviour
{
    [SerializeField] protected GameObject safehouse;
    [SerializeField] protected GameObject groundPlane;

    public void getReferences(GameObject house, GameObject plane)
    {
        safehouse = house;
        groundPlane = plane;
    }
}
