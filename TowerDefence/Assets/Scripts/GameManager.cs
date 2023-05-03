using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public List<GameObject> enemiesInPlay = new List<GameObject>();                 // keeps track of all enemies in play
    public List<GameObject> spawnerPrefabs = new List<GameObject>();                //list of different respawn spawners
    [SerializeField] private Simulation sim;                                        //simulation to check if all roads are working
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject builder;
    [SerializeField] public List<int> maxSpawnTimeRounds = new List<int>();         //list of max time the spawner takes to spawn another enemy, will change on certain rounds

    private void Awake()
    {
        manager = this;
    }
    [SerializeField] private TMP_Text roundText;
    public int round = 0;
    int enemyAmountPerRound = 10;                                                   //amount of enemies each round
    public int enemyCount = 0;                                                      //number of enemies in play

    // Start is called before the first frame update
    void Start()
    {
        roundText.text = "Round: " + round;
    }

    // Update is called once per frame
    void Update()
    {
        checkRoundChange();
    }

    /// <summary>
    /// checks for any null references in the list
    /// </summary>
    public void UpdateEnemiesInPlay()
    {
        foreach (GameObject thisObj in enemiesInPlay)
        {
            if (thisObj == null)
            {
                enemiesInPlay.Remove(thisObj);
            }
        }
    }


    /// <summary>
    /// function that checks to see if the round is over
    /// </summary>
    private void checkRoundChange()
    {
        if (enemyCount <= 0 && BuildingSystem.currentSystem.buildMode == false && enemiesInPlay.Count == 0)
        {
            playButton.SetActive(true);
            builder.SetActive(true);
            SpawnSpawner();                                     //spawns a random spawner anywhere on the map
            BuildingSystem.currentSystem.buildMode = true;
            round++;
            ReduceTime();
            roundText.text = "Round: " + round;
        }
    }


    /// <summary>
    /// instantiates a new spawner on the map
    /// </summary>
    public void SpawnSpawner()
    {
        GameObject newSpawner = Instantiate(spawnerPrefabs[Random.Range(0, spawnerPrefabs.Count - 1)]);
        RandomizeLocation.randomLocation.RandomizeobjectLocation(newSpawner);                               //will also check if the grid section is used
        sim.spawners.Add(newSpawner.GetComponentInChildren<Spawner>());                                     //adds the spawner to the list of starting areas the simulator needs to check
    }


    /// <summary>
    /// function to start the new round
    /// </summary>
    public void BeginRound()
    {
        enemyAmountPerRound += 5;
        enemyCount = enemyAmountPerRound;
    }


    /// <summary>
    /// function that reduces the max time to spawn for each spawner
    /// </summary>
    public void ReduceTime()
    {
        foreach (int thisRound in GameManager.manager.maxSpawnTimeRounds)
        {
            if (GameManager.manager.round == thisRound)                     //if the round on the list is equal to current round
            {
                foreach (GameObject thisSpawner in spawnerPrefabs)
                {
                    thisSpawner.GetComponent<Spawner>().maxTime -= 1;      
                }
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
