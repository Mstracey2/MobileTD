using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomizeLocation : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private GameObject xbound;
    [SerializeField]private GameObject ybound;
    [SerializeField] private GameObject xandybound;

    [SerializeField] private Vector3 randomXLocation;
    [SerializeField] private Vector3 randomYLocation;

    [SerializeField] private GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        randomXLocation.x = Random.Range(xbound.transform.position.x, xandybound.transform.position.x);
        randomYLocation.y = Random.Range(ybound.transform.position.z, xandybound.transform.position.z);
        Vector3 randomPos = new Vector3(randomXLocation.x, 0, randomYLocation.z);

        spawner.transform.position = BuildingSystem.currentSystem.SnapToGrid(randomPos);
        spawner.transform.position = new Vector3(spawner.transform.position.x, spawner.transform.position.y + 0.3f, spawner.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
