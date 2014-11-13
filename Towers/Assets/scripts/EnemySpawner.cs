using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public Transform enemy;
    public PathTile start, end;
    public int counter;

    // Use this for initialization
    void Start()
    {
        Enemy.start = start;
        Enemy.end = end;
        //InvokeRepeating("SpawnEnemies", 0.0f, 5.0f);
    }

    public void RoundStart() 
    {
        counter = 0;
        InvokeRepeating("SpawnEnemies", 0.0f, 5.0f);
    }

    void SpawnEnemies() 
    {
        Vector3 location = start.transform.position + new Vector3(0f, 0.51f, 0f);
        //Debug.Log("I want to see an enemy here: " + location);
        Instantiate(enemy, location, Quaternion.identity);
        counter++;

        if (counter > 20)
        {
            CancelInvoke();
        }
    }
}
