using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public Transform enemy;
    public PathTile start, end;

    // Use this for initialization
    void Start()
    {
        Enemy.start = start;
        Enemy.end = end;
    }

    public void RoundStart() 
    {
        if(GameManager.inst.enemiesLeft > 0) return;
        GameManager.inst.enemiesLeft = GameManager.inst.enemiesToSpawn;
        InvokeRepeating("SpawnEnemies", 0.0f, 1.0f);
    }

    void SpawnEnemies() 
    {
        Vector3 location = start.transform.position + new Vector3(0f, 0.51f, 0f);
        //Debug.Log("I want to see an enemy here: " + location);
        Instantiate(enemy, location, Quaternion.identity);
        GameManager.inst.enemiesLeft--;
        GameManager.inst.enemiesAlive++;

        if (GameManager.inst.enemiesLeft == 0)
        {
            CancelInvoke();
        }
    }
}
