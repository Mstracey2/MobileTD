using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public List<GameObject> enemiesInPlay = new List<GameObject>();
    public List<GameObject> spawnerPrefabs = new List<GameObject>();
    [SerializeField] private Simulation sim;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject builder;
    [SerializeField] public List<int> maxSpawnTimeRounds = new List<int>();

    private void Awake()
    {
        manager = this;
    }

    [SerializeField] private TMP_Text roundText;
    public int round = 0;
    int enemyAmountPerRound = 10;
    public int enemyCount = 0;

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

    private void checkRoundChange()
    {
        if (enemyCount <= 0 && BuildingSystem.currentSystem.buildMode == false && enemiesInPlay.Count == 0)
        {
            playButton.SetActive(true);
            builder.SetActive(true);
            SpawnSpawner();
            BuildingSystem.currentSystem.buildMode = true;
            round++;
            ReduceTime();
            roundText.text = "Round: " + round;
        }
    }

    public void SpawnSpawner()
    {
        GameObject newSpawner = Instantiate(spawnerPrefabs[Random.Range(0, spawnerPrefabs.Count - 1)]);
        RandomizeLocation.randomLocation.RandomizeobjectLocation(newSpawner);
        sim.spawners.Add(newSpawner.GetComponentInChildren<Spawner>());
    }

    public void BeginRound()
    {
        enemyAmountPerRound += 5;
        enemyCount = enemyAmountPerRound;
    }

    public void ReduceTime()
    {
        foreach (int thisRound in GameManager.manager.maxSpawnTimeRounds)
        {
            if (GameManager.manager.round == thisRound)
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
