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
        if (BuildingSystem.currentSystem.buildMode == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0 && GameManager.manager.enemyCount != 0)
            {
                GameObject newObj = RunSpawn(switchObj, spawningObj);
                if (switchObj)
                {
                    PassThroughReferences(newObj);
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
