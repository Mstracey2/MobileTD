using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{

    public static BuildingSystem currentSystem;         //setting the building system as a singleton, this script will only be used for one system

    public GridLayout layout;                           
    private Grid currentGrid;
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private TileBase defualtTile;
    public List<GameObject> gameObjectsInPlay = new List<GameObject>();                     //list of objects on the grid
    Vector3Int tilePos;
    public PlaceableTileObject placeableObject;
    public bool buildMode;                                                                          //game modes, either editing or playing mode
    [SerializeField] private List<ResourceCounter> playerResources = new List<ResourceCounter>();   

    private void Awake()
    {
        currentSystem = this;
        currentGrid = layout.gameObject.GetComponent<Grid>();
    }
    private void Start()
    {
        mainTilemap.CompressBounds();
    }
    private void Update()
    {
        if (!placeableObject)
        {
            return;
        }
    }


    /// <summary>
    /// raycast to get the players mouse position
    /// </summary>
    /// <returns></returns>
    public static Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }


    /// <summary>
    /// function to snap the object to the grid
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public Vector3 SnapToGrid(Vector3 position)
    {
        tilePos = layout.WorldToCell(position);
        position = currentGrid.GetCellCenterWorld(tilePos);
        return position;
    }


    /// <summary>
    /// instantiate a new object to snap to grid
    /// </summary>
    /// <param name="pref"></param>
    public void InitializeObject(GameObject pref)
    {
        Vector3 position = SnapToGrid(Vector3.zero);

        GameObject obj = Instantiate(pref, position, Quaternion.identity);
        placeableObject = obj.GetComponent<PlaceableTileObject>();
        obj.AddComponent<DragableObject>();
    }


    /// <summary>
    /// will add the object to the list of objects in play but only if its a new object. If the player is moving a object thats already on the grid, then there is no need to add it to the list again
    /// </summary>
    /// <param name="obj"></param>
    public void PlacedObjectLocationOnGrid(GameObject obj)
    {
        foreach (GameObject thisObj in gameObjectsInPlay)
        {
            if (thisObj == obj)
            {
                return;
            }
        }
       
        gameObjectsInPlay.Add(obj);
    }

    /// <summary>
    /// checks to see if an object has been placed ontop of another one
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="resource"></param>
    /// <returns></returns>
    public bool MovedObjectLocationOnGrid(GameObject obj, bool resource)
    {
        Vector3Int movedObjPos = layout.WorldToCell(obj.transform.position);

        foreach (GameObject thisObj in gameObjectsInPlay)
        {
            Vector3Int currentObjPos = layout.WorldToCell(thisObj.transform.position);
            if (movedObjPos == currentObjPos && thisObj != obj)                             //if the position of the new object matches the position of another
            {
                gameObjectsInPlay.Remove(obj);                                              //removes the moved object from the list
                DragableObject objDrag = obj.GetComponent<DragableObject>();
                if (resource)
                {
                    foreach (ResourceCounter thisRes in playerResources)
                    {
                        if (thisRes.GetResourceType() == objDrag.resource)
                        {
                            thisRes.counter += objDrag.resourceCost;                        //returns the resource amount back to the player
                        }
                    }
                }
                else
                {

                }
                
                Destroy(obj);                                                               //destroys the object that was placed ontop
                return false;
            }
        }
        return true;
    }

    public void ChangeMode()
    {
        buildMode = !buildMode;
    }

    /// <summary>
    /// stops the camera from moving while the player scrolls through menus
    /// </summary>
    public void AllowScroll()
    {
        ScrollAndPinch.pinchSystem.scrollingUI = false;
        ScrollAndPinch.pinchSystem.draggingObject = false;
        ScrollAndPinch.pinchSystem.draggingObject = false;
    }
}
