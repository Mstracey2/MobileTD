using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomizeLocation : MonoBehaviour
{
    public static RandomizeLocation randomLocation;
    public int[] rotations;
    private void Awake()
    {
        randomLocation = this;
    }

    [SerializeField] private Tilemap tilemap;
    // locations that restrict the random location from being off the map
    [SerializeField] private GameObject xbound;
    [SerializeField]private GameObject ybound;
    [SerializeField] private GameObject xandybound;

    [SerializeField] private Vector3 randomXLocation;
    [SerializeField] private Vector3 randomYLocation;

    private bool locationFound;

    /// <summary>
    /// starts a coroutine to randomize the objects locations
    /// </summary>
    /// <param name="obj"></param>
    public void RandomizeobjectLocation(GameObject obj)
    {
        locationFound = false;
        StartCoroutine(randomize(obj));
    }

    /// <summary>
    /// process of placing the spawner in a random location
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    private IEnumerator randomize(GameObject obj)
    {
        while(locationFound == false)
        {
            randomXLocation.x = Random.Range(xbound.transform.position.x, xandybound.transform.position.x);
            randomYLocation.y = Random.Range(ybound.transform.position.z, xandybound.transform.position.z);
            Vector3 randomPos = new Vector3(randomXLocation.x, 0, randomYLocation.z);       //random transform

            obj.transform.position = BuildingSystem.currentSystem.SnapToGrid(randomPos);    //snaps transform to grid
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 0.3f, obj.transform.position.z);
            BuildingSystem.currentSystem.PlacedObjectLocationOnGrid(obj);
            locationFound = BuildingSystem.currentSystem.MovedObjectLocationOnGrid(obj, false);
        }
        yield return null;
      
    }

}
