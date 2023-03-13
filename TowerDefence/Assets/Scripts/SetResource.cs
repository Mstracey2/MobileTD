using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResource : Spawner
{
    [SerializeField] private ResourceType resource;
    // Start is called before the first frame update
    void Start()
    {
        del = PassThroughReferences;
    }

    public void PassThroughReferences(GameObject obj)
    {
        ResourceScript objPawn = obj.GetComponent<ResourceScript>();
        objPawn.resource = resource;
        objPawn.getReferences(safehouse, plane);

    }
}
