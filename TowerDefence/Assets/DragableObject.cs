using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableObject : MonoBehaviour
{
    private Vector3 offset;

    private void OnMouseDown()
    {
        offset = transform.position - BuildingSystem.GetMousePosition();
    }

    public void OnMouseDrag()
    {
        Vector3 pos = BuildingSystem.GetMousePosition() + offset;
        transform.position = BuildingSystem.currentSystem.SnapToGrid(pos);
        BuildingSystem.currentSystem.placeableObject = this.gameObject.GetComponent<PlaceableTileObject>();
    }
}
