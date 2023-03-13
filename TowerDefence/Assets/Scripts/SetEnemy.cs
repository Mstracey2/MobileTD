using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemy : Spawner
{
    // Start is called before the first frame update
    void Start()
    {
        del = PassThroughReferences; 
    }

    public void PassThroughReferences(GameObject obj)
    {
        EnemyScript objPawn = obj.GetComponent<EnemyScript>();
        objPawn.getReferences(safehouse, plane);

    }
}
