using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public Transform enemy;
    public PathTile start, end;
    public float counter;

    // Use this for initialization
    void Start()
    {
        Enemy.start = start;
        Enemy.end = end;

        //InvokeRepeating("SpawnEnemies", 0.0f, 5.0f);
    }

    void roundStart() 
    {
        InvokeRepeating("SpawnEnemies", 0.0f, 5.0f);
    }

    void SpawnEnemies() 
    {
        Vector3 location = start.transform.position;
        //Debug.Log("I want to see an enemy here: " + location);
        Instantiate(enemy, location, Quaternion.identity);
        counter++;

        if (counter > 20)
        {
            CancelInvoke();
        }
    }
}
