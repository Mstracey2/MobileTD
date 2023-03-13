using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UIImageDrag : MonoBehaviour
{
    private Transform parent;
    [SerializeField] private StopDragOnScrollList uiList;
    private Vector2 pos;
    private bool draggedOut;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject panelDrop;
    private Image panelImage;
    // Start is called before the first frame update
    void Start()
    {
        panelImage = panelDrop.GetComponent<Image>();
        pos = transform.localPosition;
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey(KeyCode.Mouse0))
         {
            foreach (RaycastResult result in uiList.results)
            {
                if (result.gameObject == this.gameObject)
                {
                    DragImage();
                    draggedOut = true;
                }
                return;
            }

         }
         else
         {
            uiList.results.Clear();
            ReturnImage();

            if (draggedOut)
            {
               RaycastResult hit = uiList.MouseRaycast();
                    if(hit.gameObject == panelDrop.gameObject)
                    {
                        Vector3 mousePos = BuildingSystem.GetMousePosition();
                        GameObject newPrefab = Instantiate(prefab, mousePos, new Quaternion(0, 0, 0, 0));
                        newPrefab.transform.position = BuildingSystem.currentSystem.SnapToGrid(newPrefab.transform.position);
                        BuildingSystem.currentSystem.MovedObjectLocationOnGrid(newPrefab);
                    }
                panelImage.enabled = false;
                draggedOut = false;
                
            }
         }
       
    }

    public void ReturnImage()
    {
        ScrollAndPinch.pinchSystem.draggingUI = false;
        transform.SetParent(parent, true);
        transform.localPosition = pos;
    }

    public void DragImage()
    {
        ScrollAndPinch.pinchSystem.draggingUI = true;
        panelImage.enabled = true;
        gameObject.transform.position = Input.mousePosition;
        gameObject.transform.SetParent(uiList.gameObject.transform, true);
    }
}
