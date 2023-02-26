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

    public GameObject section1;
    public GameObject section2;

    public PlaceableTileObject placeableObject;

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

        if (Input.GetKeyDown(KeyCode.R))
        {
            placeableObject.Rotate();
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
                placeableObject.Place();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(placeableObject.gameObject);
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
        Vector3Int tilePos = layout.WorldToCell(position);
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
}
