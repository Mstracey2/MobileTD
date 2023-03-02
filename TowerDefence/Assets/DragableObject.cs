using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableObject : MonoBehaviour
{
    private Vector3 offset;
    public float buttonDownCounter = 0;
    private PlaceableTileObject placedObject;
    bool tapped = false;

    private void Start()
    {
        placedObject = GetComponent<PlaceableTileObject>();
    }
    
    private void OnMouseDown()
    {
        offset = transform.position - BuildingSystem.GetMousePosition();
        tapped = true;
        BuildingSystem.currentSystem.PlacedObjectLocationOnGrid(this.gameObject);
    }
    private void OnMouseUp()
    {
        tapped = false;
        if (buttonDownCounter <=0.2)
        {
            placedObject.Rotate();
        }
        buttonDownCounter = 0;
        BuildingSystem.currentSystem.MovedObjectLocationOnGrid(this.gameObject);
    }

    public void OnMouseDrag()
    {
        Vector3 pos = BuildingSystem.GetMousePosition() + offset;
        transform.position = BuildingSystem.currentSystem.SnapToGrid(pos);
        BuildingSystem.currentSystem.placeableObject = this.gameObject.GetComponent<PlaceableTileObject>();
    }

    private void Update()
    {
        if (tapped)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                buttonDownCounter += Time.deltaTime;
            }
        }
       
    }
}
