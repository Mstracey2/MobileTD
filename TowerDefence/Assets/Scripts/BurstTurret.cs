using System.Collections;
using UnityEngine;

public class BurstTurret : BaseTurretScript
{

    private int burst = 2;


    // Update is called once per frame
    void Update()
    {
        coolDown -= Time.deltaTime;
        CheckForMissingObjects();
        LookAtObject();
        BurstCountDownCheck();
    }

    public void BurstCountDownCheck()
    {
        if (enemiesInView.Count != 0 && BuildingSystem.currentSystem.buildMode == false)
        {
            if (coolDown <= 0)
            {
                StartCoroutine(BurstDelay());
            }
        }
        else
        {
            coolDown = 0;
        }
    }


    private IEnumerator BurstDelay()
    {
        for (int i = 0; i <= burst; i++)
        {
            Shoot();
            coolDown = cooldownLength;
            yield return new WaitForSeconds(0.2f);
        }

        yield return null;
    }
}
