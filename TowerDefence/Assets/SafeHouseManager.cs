using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    Brown,
    Blue,
    Purple,
    Yellow,
}

public class SafeHouseManager : MonoBehaviour
{
    [SerializeField] private List<ResourceCounter> playerResources = new List<ResourceCounter>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddResourceToPlayerResourceInv(ResourceType resource)
    {
        foreach(ResourceCounter thisType in playerResources)
        {
            if(thisType.GetResourceType() == resource)
            {
                thisType.AddToCounter();
            }
        }
    }
}
