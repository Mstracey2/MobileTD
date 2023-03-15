using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class StopDragOnScrollList : MonoBehaviour
{
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    RaycastResult UIelement;
    //Create a list of Raycast Results
    public List<RaycastResult> results = new List<RaycastResult>();
    void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            MouseRaycast();
        }
    }

    public RaycastResult MouseRaycast()
    {

            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

        bool touchingUI = false;
            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                UIelement = result;
                if(result.gameObject.name == "Scroll")
                {
                 ScrollAndPinch.pinchSystem.scrollingUI = true;
                    touchingUI = true;
                }
               
                
                break;
                
            }

            if(touchingUI == false)
            {
                ScrollAndPinch.pinchSystem.scrollingUI = false;
            }
       
        return UIelement;
    }
}
