using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollAndPinch : MonoBehaviour
{
    public static ScrollAndPinch pinchSystem;
    public Camera cam;
    protected Plane ground;
    public bool draggingObject;
    public bool draggingUI;
    public bool scrollingUI;
    [SerializeField] private GameObject groundPlane;
    private void Awake()
    {
        pinchSystem = this;
        if(cam == null)
        {
            cam = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (!draggingObject && !draggingUI && !scrollingUI)
        {
            if (Input.touchCount >= 1)
            {
                ground.SetNormalAndPosition(transform.up, transform.position);
            }

            var delta1 = Vector3.zero;
            var delta2 = Vector3.zero;

            //scroll
            if (Input.touchCount >= 1)
            {
                delta1 = PlanePositionDelta(Input.GetTouch(0));
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    cam.transform.Translate(delta1, Space.World);
                }
            }

            //pinch
            if (Input.touchCount >= 2)
            {
                var pos1 = PlanePosition(Input.GetTouch(0).position);
                var pos2 = PlanePosition(Input.GetTouch(1).position);

                var pos1b = PlanePosition(Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition);
                var pos2b = PlanePosition(Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition);

                var zoom = Vector3.Distance(pos1, pos2) / Vector3.Distance(pos1b, pos2b);

                if (zoom == 0 || zoom > 10)
                {
                    return;
                }
                else
                {
                    cam.transform.position = Vector3.LerpUnclamped(pos1, cam.transform.position, 1 / zoom);
                }

            }
        }


    }


    protected Vector3 PlanePositionDelta(Touch touch)
    {
        if(touch.phase != TouchPhase.Moved)
        {
            return Vector3.zero;
        }

        var rayBefore = cam.ScreenPointToRay(touch.position - touch.deltaPosition);
        var rayNow = cam.ScreenPointToRay(touch.position);
        if(ground.Raycast(rayBefore, out var enterBefore) && ground.Raycast(rayNow, out var enterNow))
        {
            return rayBefore.GetPoint(enterBefore) - rayNow.GetPoint(enterNow);
        }

        return Vector3.zero;
    }

    protected Vector3 PlanePosition(Vector2 screenPos)
    {
        var rayNow = cam.ScreenPointToRay(screenPos);
            if(ground.Raycast(rayNow, out var enterNow))
            {
                return rayNow.GetPoint(enterNow);
            }
        return Vector3.zero;
    }
}
