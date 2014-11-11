using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {

	/// <summary>
	/// The _mods only GameObject for now
	/// </summary>
	public GameObject[] mods = new GameObject[4];

	public List<GameObject> enemies = new List<GameObject>();

	private Collider colider;

	/// <summary>
	/// The time between shots.
	/// </summary>
	public float timeBetweenShots = 0.5f;

	public float dammage = 1.0f;

	public float range  = 1.0f;


	private float _timer = 0;



	void OnTriggerEnter(Collider obj)
	{
		if (obj.tag == "Enemy")
		{
			enemies.Add(obj.gameObject);
		}
		Debug.Log("boop");
	}


	void OnTriggerExit(Collider obj)
	{
		if (obj.tag == "Enemy")
		{
			enemies.Remove(obj.gameObject);
		}
		Debug.Log("poob");
	}

	void Fire()
	{


	}

	void StartRound()
	{
		colider.enabled = true;
	}

	void endrouind()
	{
		colider.enabled = false;
	}


	// Use this for initialization
	void Start () 
	{
	  colider = this.gameObject.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	
	}
}
