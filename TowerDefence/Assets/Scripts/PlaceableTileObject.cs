using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTileObject : MonoBehaviour
{
    public bool placed { get; private set; }
    public Vector3Int size { get; private set; }

    [SerializeField] private Convey road;

    public void Rotate()
    {
        transform.Rotate(new Vector3(0, 90, 0));
        size = new Vector3Int(size.y, size.x, 1);
        if(road != null)
        {
            road.ChangeDirection();
        }
    }

    public virtual void Place()
    {
        DragableObject drag = gameObject.GetComponent<DragableObject>();
        Destroy(drag);
        placed = true;
    }
}
