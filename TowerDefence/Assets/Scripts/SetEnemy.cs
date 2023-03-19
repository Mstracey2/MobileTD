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
        if(objPawn != null)
        {
            objPawn.getReferences(safehouse, plane, this.gameObject);
        }


    }
}
