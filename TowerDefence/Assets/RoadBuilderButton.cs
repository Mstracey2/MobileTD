using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuilderButton : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    public void OnButtonPressed()
    {
        Instantiate(prefab);
    }
}
