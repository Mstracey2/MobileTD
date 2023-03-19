using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{

    public static BuildingSystem currentSystem;

    public GridLayout layout;
    private Grid currentGrid;
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private TileBase defualtTile;

    public List<GameObject> gameObjectsInPlay = new List<GameObject>();
    public GameObject section1;
    public GameObject section2;
    Vector3Int tilePos;
    public PlaceableTileObject placeableObject;
    public bool buildMode;
    [SerializeField] private List<ResourceCounter> playerResources = new List<ResourceCounter>();

    GameObject savedObjectMoved;

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


    public Vector3 SnapToGrid(Vector3 position)
    {
        tilePos = layout.WorldToCell(position);
        position = currentGrid.GetCellCenterWorld(tilePos);
        return position;
    }

    public void InitializeObject(GameObject pref)
    {
        Vector3 position = SnapToGrid(Vector3.zero);

        GameObject obj = Instantiate(pref, position, Quaternion.identity);
        placeableObject = obj.GetComponent<PlaceableTileObject>();
        obj.AddComponent<DragableObject>();
    }

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

    public bool MovedObjectLocationOnGrid(GameObject obj)
    {
        Vector3Int movedObjPos = layout.WorldToCell(obj.transform.position);

        foreach (GameObject thisObj in gameObjectsInPlay)
        {
            Vector3Int currentObjPos = layout.WorldToCell(thisObj.transform.position);
            if (movedObjPos == currentObjPos && thisObj != obj)
            {
                gameObjectsInPlay.Remove(obj);
                DragableObject objDrag = obj.GetComponent<DragableObject>();
                foreach(ResourceCounter thisRes in playerResources)
                {
                    if (thisRes.GetResourceType() == objDrag.resource)
                    {
                        thisRes.counter += objDrag.resourceCost;
                    }
                }
                Destroy(obj);
                return false;
            }
        }
        return true;
    }

    public void ChangeMode()
    {
        buildMode = !buildMode;
    }

    public void AllowScroll()
    {
        ScrollAndPinch.pinchSystem.scrollingUI = false;
        ScrollAndPinch.pinchSystem.draggingObject = false;
        ScrollAndPinch.pinchSystem.draggingObject = false;
    }
}
