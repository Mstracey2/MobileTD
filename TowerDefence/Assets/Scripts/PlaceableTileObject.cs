using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTileObject : MonoBehaviour
{
    public bool placed { get; private set; }
    public Vector3Int size { get; private set; }

    [SerializeField] private Convey road;

    /// <summary>
    /// function used to rotate the object
    /// </summary>
    /// <param name="amount"></param>
    public void Rotate(int amount)
    {
        transform.Rotate(new Vector3(0, amount, 0));
        size = new Vector3Int(size.y, size.x, 1);
        if(road != null)                                //if the object is a road, then change the direction of flow
        {
            road.ChangeDirection();
        }
    }
}
