using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralPawnScript : MonoBehaviour
{
    [SerializeField] protected GameObject safehouse;
    [SerializeField] protected GameObject groundPlane;
    [SerializeField] protected GameObject objectHome;

    public void getReferences(GameObject house, GameObject plane, GameObject home)
    {
        safehouse = house;
        groundPlane = plane;
        objectHome = home;
    }
}
