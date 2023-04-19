using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTileObject : MonoBehaviour
{
    public bool placed { get; private set; }
    public Vector3Int size { get; private set; }

    [SerializeField] private Convey road;

    public void Rotate(int amount)
    {
        transform.Rotate(new Vector3(0, amount, 0));
        size = new Vector3Int(size.y, size.x, 1);
        if(road != null)
        {
            road.ChangeDirection();
        }
    }
}
