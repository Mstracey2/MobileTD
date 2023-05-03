using UnityEngine;

public class SetResource : Spawner
{
    [SerializeField] private ResourceType resource;
    [SerializeField] private GameObject resourcepref;
    [SerializeField] private GameObject spawningObj;
    public bool switchObj = true;
    // Start is called before the first frame update
    void Start()
    {
        spawningObj = resourcepref;
    }

    private void Update()
    {
        if (BuildingSystem.currentSystem.buildMode == false && activated)           //if not in build mode and activated
        {
            timer -= Time.deltaTime;                                                //cooldown is on countdown to spawn next resource
            if (timer <= 0 && GameManager.manager.enemyCount != 0)
            {
                GameObject newObj = RunSpawn(switchObj, spawningObj);
                if (switchObj)
                {
                    PassThroughReferences(newObj);                                  //passes through important references for resources
                }
                ChangeObj();
            }
        }
    }

    public void PassThroughReferences(GameObject obj)
    {
        ResourceScript objPawn = obj.GetComponent<ResourceScript>();
        objPawn.resource = resource;
    }

    /// <summary>
    /// the prefab changes to either the enemy prefab or resource prefab after every spawn
    /// </summary>
    public void ChangeObj()
    {
        if (spawningObj == resourcepref)
        {
            spawningObj = defaultObject;
            switchObj = false;
        }
        else
        {
            spawningObj = resourcepref;
            switchObj = true;
        }
    }
}
