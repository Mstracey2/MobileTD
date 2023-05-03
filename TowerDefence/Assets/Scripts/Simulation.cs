using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Simulation : MonoBehaviour
{
    [SerializeField] public List<Spawner> spawners = new List<Spawner>();
    [SerializeField] private SimulateEnemy enemyPrefab;
    GameObject en;
    bool simulate = false;
    int count = 0;
    public UnityEvent onSuccess;
    public UnityEvent onFail;

    /// <summary>
    /// function that starts the simulation
    /// </summary>
    public void StartSim()
    {
        simulate = true;
        enemyPrefab.running = true;
        enemyPrefab.oldPos = enemyPrefab.transform.position;
        enemyPrefab.transform.position = spawners[count].transform.position;
        Time.timeScale = 5f;
    }

    private void Update()
    {
        if (simulate)
        {
            if (enemyPrefab.running) //continues if running
            {
                if (enemyPrefab.success)    //changes path it successful
                {
                    if (count < spawners.Count) //path is next on list
                    {
                        count++;
                        if(spawners[count-1].activated == true)
                        {
                            enemyPrefab.transform.position = spawners[count - 1].transform.position;
                            enemyPrefab.timer = enemyPrefab.maxTime;
                            enemyPrefab.oldPos = enemyPrefab.transform.position;
                            enemyPrefab.success = false;
                        }
                        
                    }
                    else
                    {
                        SuccessSim();           //if no other paths, then the simulation was succesful
                        Time.timeScale = 1f;
                        enemyPrefab.transform.position = enemyPrefab.returnPos;
                        simulate = false;
                        count = 0;
                    }
                }
            }
            else
            {
                FailedSim();                //if simulating but not running, the sim has failed.
                Time.timeScale = 1f;
                enemyPrefab.transform.position = enemyPrefab.returnPos;
                simulate = false;
                count = 0;
            }
        }

    }

    public void SuccessSim()
    {
        onSuccess.Invoke();
    }

    public void FailedSim()
    {
        onFail.Invoke();
    }
}
