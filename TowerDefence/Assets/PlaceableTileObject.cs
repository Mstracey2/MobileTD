using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTileObject : MonoBehaviour
{
    public bool placed { get; private set; }
    public Vector3Int size { get; private set; }

    public void Rotate()
    {
        transform.Rotate(new Vector3(0, 90, 0));
        size = new Vector3Int(size.y, size.x, 1);
    }

    public virtual void Place()
    {
        DragableObject drag = gameObject.GetComponent<DragableObject>();
        Destroy(drag);
        placed = true;
    }
}
