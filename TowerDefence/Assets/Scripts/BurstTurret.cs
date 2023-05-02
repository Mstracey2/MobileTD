using System.Collections;
using UnityEngine;

public class BurstTurret : BaseTurretScript
{
    private int burst = 2;      //number of bullets on burst


    // Update is called once per frame
    void Update()
    {
        coolDown -= Time.deltaTime;
        CheckForMissingObjects();
        LookAtObject();
        BurstCountDownCheck();
    }


    /// <summary>
    /// special function for the burst turret that checks cooldown, then fires a number of amount of bullets in a single burst
    /// </summary>
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


    /// <summary>
    /// fires a burst of bullets through a coroutine
    /// </summary>
    /// <returns></returns>
    private IEnumerator BurstDelay()
    {
        for (int i = 0; i <= burst; i++)
        {
            Shoot();
            coolDown = cooldownLength;                      //turret on cooldown
            yield return new WaitForSeconds(0.2f);
        }

        yield return null;
    }
}
