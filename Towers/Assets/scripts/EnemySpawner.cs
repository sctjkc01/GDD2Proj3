using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public Transform enemy;
    public PathTile start;
    public float counter;

    // Use this for initialization
    void Start() 
    {
    }

    void roundStart() 
    {
        InvokeRepeating("SpawnEnemies", 0.1f, 0.0f);
    }

    void SpawnEnemies() 
    {
        Vector3 location = start.transform.position;
        // Debug.Log("I want to see an enemy here: " + location);
        Instantiate(enemy, location, Quaternion.identity);
        counter++;

        if (counter > 20)
        {
            CancelInvoke();
        }
    }
}
