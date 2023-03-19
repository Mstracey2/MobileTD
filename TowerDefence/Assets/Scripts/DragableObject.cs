using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableObject : MonoBehaviour
{
    private Vector3 offset;
    public float buttonDownCounter = 0;
    private PlaceableTileObject placedObject;
    public int resourceCost;
    public ResourceType resource;
    bool tapped = false;

    private void Start()
    {
        placedObject = GetComponent<PlaceableTileObject>();
    }
    
    private void OnMouseDown()
    {
        if (BuildingSystem.currentSystem.buildMode)
        {
            offset = transform.position - BuildingSystem.GetMousePosition();
            tapped = true;
            BuildingSystem.currentSystem.PlacedObjectLocationOnGrid(this.gameObject);
            ScrollAndPinch.pinchSystem.draggingObject = true;
        }
    }
        
    private void OnMouseUp()
    {
        if (BuildingSystem.currentSystem.buildMode)
        {
            tapped = false;
            if (buttonDownCounter <= 0.2)
            {
                placedObject.Rotate();
            }
            buttonDownCounter = 0;
            BuildingSystem.currentSystem.MovedObjectLocationOnGrid(this.gameObject);
            ScrollAndPinch.pinchSystem.draggingObject = false;
        }
       
    }

    public void OnMouseDrag()
    {
        if (BuildingSystem.currentSystem.buildMode)
        {
            Vector3 pos = BuildingSystem.GetMousePosition() + offset;
            transform.position = BuildingSystem.currentSystem.SnapToGrid(pos);
            BuildingSystem.currentSystem.placeableObject = this.gameObject.GetComponent<PlaceableTileObject>();
        }
        
    }

    private void Update()
    {
        if (BuildingSystem.currentSystem.buildMode)
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
}
