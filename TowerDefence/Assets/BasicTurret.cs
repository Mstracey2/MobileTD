using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurret : BaseTurretScript
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForMissingObjects();
        LookAtObject();
        Timer();
    }

    public void LookAtObject()
    {
        if (enemiesInView.Count != 0)
        {
            Transform targetAxis = enemiesInView[enemiesInView.Count - 1].transform;
            transform.parent.LookAt(new Vector3(targetAxis.position.x, transform.parent.position.y,targetAxis.position.z ));
        }
    }
}
