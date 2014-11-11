using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health = 20;
    public float listIndex = 0;

    public static PathTile start;
    public static PathTile end;

    public Vector3 movement;

    public List<PathTile> tileList;

   	// Use this for initialization
	void Start()
    {
        GameObject.getComponent<TileMap>().findPath(start, end, tileList);
	}
	
	// Update is called once per frame
	void Update() 
    {
        movement = transform.position - tileList[listIndex].transform.position;
        transform.translate(movement * Time.deltaTime);
        if (health < 1)
        {
            Destroy(this.gameObject);
        }

        if (transform.positon == tileList[listIndex].transform.position)
        {
            if (listIndex == tileList.length)
            {
                //make player lose life here
                Destroy(this.gameObject);
            }

            else
            {
                listIndex++;
            }
        }
	}

    void takeDamage(float dmg)
    {
        health -= dmg;
    }
}