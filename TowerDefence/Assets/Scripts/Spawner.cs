using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject spawnObject;
    [SerializeField] protected GameObject safehouse;
    [SerializeField] protected GameObject plane;
    private Renderer rend;
    private Renderer spawnRend;
    protected float timer = 10;
    protected delegate void function(GameObject obj);
    protected function del;
    public GameObject newObj;

    // Start is called before the first frame update
    void Start()
    {
        rend = transform.parent.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BuildingSystem.currentSystem.buildMode == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SpawnObj(spawnObject);
                del(newObj);
                timer = 10;
            }
        }

    }

    public GameObject SpawnObj(GameObject obj)
    {
        newObj = Instantiate(obj, transform.position, new Quaternion(0, 0, 0, 0));
        return newObj;
    }
}
