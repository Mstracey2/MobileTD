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
            if (enemyPrefab.running)
            {
                if (enemyPrefab.success)
                {
                    if (count < spawners.Count)
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
                        SuccessSim();
                        Time.timeScale = 1f;
                        enemyPrefab.transform.position = enemyPrefab.returnPos;
                        simulate = false;
                        count = 0;
                    }
                }
            }
            else
            {
                FailedSim();
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
