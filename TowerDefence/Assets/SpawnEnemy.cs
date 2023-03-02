using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject safehouse;
    [SerializeField] private GameObject plane;
    private float timer = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
           GameObject newEnemy = Instantiate(enemy, transform.position, new Quaternion(0,0,0,0));
            PassThroughReferences(newEnemy);
            timer = 10;
        }
    }

    public void PassThroughReferences(GameObject obj)
    {
       GeneralPawnScript objPawn = obj.GetComponent<GeneralPawnScript>();
       objPawn.getReferences(safehouse, plane);

    }
}
