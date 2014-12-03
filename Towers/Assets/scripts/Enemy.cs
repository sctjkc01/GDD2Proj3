using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

	public float health;
    public float speed = 2.5f;
    public static PathTile start, end;
    public Vector3 movement = new Vector3(0, 0, 0);
    public int listIndex = 0;
    public List<PathTile> tileList = new List<PathTile>();
    public int bounty;
	public ParticleSystem ps;

   	// Use this for initialization
	void Start()
    {
        health = ((GameManager.inst.level + 3) * (GameManager.inst.level + 2)) / 2;
        
        //Debug.Log("Enemy Health is: " + health);

        if (GameObject.Find("TileMap").GetComponent<TileMap>().FindPath(start, end, tileList))
        {
            //Debug.Log("Path found!");
        }

        else
        {
            //Debug.Log("Path not found!");
        }
	}
	
	// Update is called once per frame
	void Update() 
    {
        movement = (tileList[listIndex].transform.position + new Vector3(0f, 0.51f, 0f)) - transform.position;
        movement = movement.normalized * speed;

        transform.Translate(movement * Time.deltaTime);

        if (Vector3.Distance(transform.position, tileList[listIndex].transform.position + new Vector3(0f, 0.51f, 0f)) < 0.05f)
        {
            if (listIndex == tileList.Count - 1)
            {
                //make player lose life here
                Destroy(this.gameObject);
                GameManager.inst.enemiesAlive--;
            }

            else
            {
                listIndex++;
                //Debug.Log(movement);
            }
        }
	}

    public void takeDamage(float dmg)
    {
        health -= dmg;

		ps.Play();

		//Debug.Log("Hit");

		if (health <= 0)
		{
            Destroy(this.gameObject);
            GameManager.inst.enemiesAlive--;
            GameManager.inst.cash += bounty;
		}
    }
}