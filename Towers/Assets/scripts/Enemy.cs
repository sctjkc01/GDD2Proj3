using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

	public float health = 20;
    public float speed = 1;
    public static PathTile start, end;
    public Vector3 movement = new Vector3(0, 0, 0);
    public int listIndex = 0;
    public List<PathTile> tileList = new List<PathTile>();
    public int bounty;

   	// Use this for initialization
	void Start()
    {
        if (GameObject.Find("TileMap").GetComponent<TileMap>().FindPath(start, end, tileList))
        {
            Debug.Log("Path found!");
        }

        else
        {
            Debug.Log("Path not found!");
        }
	}
	
	// Update is called once per frame
	void Update() 
    {
        movement = (tileList[listIndex].transform.position + new Vector3(0f, 0.51f, 0f)) - transform.position;
        movement = movement.normalized * speed;

        transform.Translate(movement * Time.deltaTime);

        if (health < 1)
        {
            Destroy(this.gameObject);
            GameManager.inst.enemiesAlive--;
            GameManager.inst.cash += bounty;
        }

        if (Vector3.Distance(transform.position, tileList[listIndex].transform.position + new Vector3(0f, 0.51f, 0f)) < 0.05f)
        {
            if (listIndex == tileList.Count)
            {
                //make player lose life here
                Destroy(this.gameObject);
                GameManager.inst.enemiesAlive--;
            }

            else
            {
                listIndex++;
                Debug.Log(movement);
            }
        }
	}

    public void takeDamage(float dmg)
    {
        health -= dmg;

		Debug.Log("Hit");

		if (health <= 0)
		{
			Destroy(this.gameObject);
		}
    }
}