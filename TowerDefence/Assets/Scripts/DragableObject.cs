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
    
    /// <summary>
    /// gets what the player pressed so its ready to be dragged.
    /// </summary>
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
        
    /// <summary>
    /// places the object back down on the grid
    /// </summary>
    private void OnMouseUp()
    {
        if (BuildingSystem.currentSystem.buildMode)
        {
            tapped = false;
            if (buttonDownCounter <= 0.2)           //if the player tapped the object
            {
                placedObject.Rotate(90);            //rotate the object
            }
            buttonDownCounter = 0;
            BuildingSystem.currentSystem.MovedObjectLocationOnGrid(this.gameObject, true);
            ScrollAndPinch.pinchSystem.draggingObject = false;
        }
       
    }

    /// <summary>
    /// drags the object accross the grid
    /// </summary>
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
                    buttonDownCounter += Time.deltaTime;            //sets of a counter to check for tapping objects
                }
            }
        }
       
       
    }
}
