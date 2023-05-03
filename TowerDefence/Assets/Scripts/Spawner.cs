using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject defaultObject;
    private Renderer rend;
    private Renderer spawnRend;
    public float maxTime = 10;
    protected float timer = 3;
    protected delegate void function(GameObject obj);
    protected function del;
    public GameObject newObj;
    public bool activated;

    // Start is called before the first frame update
    void Start()
    {
        rend = transform.parent.GetComponent<Renderer>();
    }

    /// <summary>
    /// default update for basic spawner, will countdown then spawn object
    /// </summary>
    // Update is called once per frame
    private void Update()
    {
        if (BuildingSystem.currentSystem.buildMode == false && activated)
        {
            timer -= Time.deltaTime;
            if (timer <= 0 && GameManager.manager.enemyCount != 0)
            {
                RunSpawn(false, defaultObject);
            }
        }
    }


    /// <summary>
    /// function for instantiating a new game object
    /// </summary>
    /// <param name="resource"></param>
    /// <param name="objPref"></param>
    /// <returns></returns>
    public GameObject RunSpawn(bool resource, GameObject objPref)
    {
        newObj = Instantiate(objPref, transform.position, new Quaternion(0, 0, 0, 0));
        if (!resource)// if its an enemy
        {
            GameManager.manager.enemyCount--;
            GameManager.manager.enemiesInPlay.Add(newObj);
        }
        timer = Random.Range(1, maxTime);
        return newObj;
    }


}
