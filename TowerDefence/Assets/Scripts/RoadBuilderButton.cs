using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuilderButton : MonoBehaviour
{
   public GameObject spr;
    GameObject currentSpr;

    public void OnButtonPressed()
    {
        currentSpr = Instantiate(spr,BuildingSystem.GetMousePosition(), new Quaternion(0,0,0,0));
    }

    private void Update()
    {
        if (currentSpr != null && Input.GetKey(KeyCode.Mouse0))
        {
            
        }
    }
    private void OnMouseDrag()
    {
       
    }

}
