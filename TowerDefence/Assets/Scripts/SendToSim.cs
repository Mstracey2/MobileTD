using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendToSim : MonoBehaviour
{
    [SerializeField] private Simulation sim;
    public void SendTo(GameObject newSpawner)
    {
        sim.spawners.Add(newSpawner.GetComponentInChildren<Spawner>());
    }
}
