using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;

public class UIImageDrag : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollbar;
    private Transform parent;
    [SerializeField] private StopDragOnScrollList uiList;
    private Vector2 pos;
    private bool draggedOut;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject panelDrop;
    [SerializeField] private List<ResourceCounter> resources = new List<ResourceCounter>();
    private DragableObject prefabDrag;
    private ResourceCounter counterRes;
    private Image panelImage;
    private Image uiDragImage;
    [SerializeField] private Color greyedOut;
    [SerializeField] private Color selectable;
    [SerializeField] private GameObject resourceCostVisual;
    private Image visualColour;
    private TMP_Text visualText;
    // Start is called before the first frame update
    void Start()
    {
        
        uiDragImage = GetComponent<Image>();
        panelImage = panelDrop.GetComponent<Image>();
        pos = transform.localPosition;
        parent = transform.parent;
        prefabDrag = prefab.GetComponent<DragableObject>();
        foreach (ResourceCounter res in resources)
        {
            if (res.GetResourceType() == prefabDrag.resource)
            {
                counterRes = res;
            }
        }

        visualColour = resourceCostVisual.GetComponent<Image>();
        visualText = resourceCostVisual.GetComponentInChildren<TMP_Text>();
        visualColour.color = counterRes.resourceColour;
        visualText.text = prefabDrag.resourceCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(counterRes.counter < prefabDrag.resourceCost)
        {
            uiDragImage.color = greyedOut;
        }
        else
        {
            uiDragImage.color = selectable;
        }

         if(Input.GetKey(KeyCode.Mouse0) && counterRes.counter >= prefabDrag.resourceCost)
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
                    counterRes.counter = counterRes.counter - prefabDrag.resourceCost;
                        newPrefab.transform.position = BuildingSystem.currentSystem.SnapToGrid(newPrefab.transform.position);
                     if (BuildingSystem.currentSystem.MovedObjectLocationOnGrid(newPrefab))
                     {
                        BuildingSystem.currentSystem.gameObjectsInPlay.Add(newPrefab);
                     }
                    }
                panelImage.enabled = false;
                draggedOut = false;
                
            }
         }
       
    }

    public void ReturnImage()
    {
        scrollbar.enabled = true;
        ScrollAndPinch.pinchSystem.draggingUI = false;
        transform.SetParent(parent, true);
        transform.localPosition = pos;
    }

    public void DragImage()
    {
        scrollbar.enabled = false;
        ScrollAndPinch.pinchSystem.draggingUI = true;
        panelImage.enabled = true;
        gameObject.transform.position = Input.mousePosition;
        gameObject.transform.SetParent(uiList.gameObject.transform, true);
    }
}
