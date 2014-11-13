using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

	public float health = 20;
    public float speed = 1;
    public static PathTile start, end;
    public Vector3 movement = new Vector3(0, 0, 0);
    public int listIndex = 0;
    public List<PathTile> tileList = new List<PathTile>();

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
        movement = tileList[listIndex].transform.position - transform.position;
        movement = movement.normalized * speed;

        transform.Translate(movement * Time.deltaTime);

        if (health < 1)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.x == tileList[listIndex].transform.position.x && transform.position.y == tileList[listIndex].transform.position.y)
        {
            if (listIndex == tileList.Count)
            {
                //make player lose life here
                Destroy(this.gameObject);
            }

            else
            {
                listIndex++;
                Debug.Log(movement);
            }
        }
	}

    void takeDamage(float dmg)
    {
        health -= dmg;
    }
}