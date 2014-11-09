using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private float _damage;

	private float _speed;

	
	public float Damage
	{
		get { return _damage; }
		set { _damage = value; }
	}

	public float Speed
	{
		get { return _speed; }
		set { _speed = value; }
	}


	// Use this for initialization
	void Start () {

		// find nereast enemy and traget it.

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void onColisiionEneter(Collision obj)
	{

		//when colides with enemy ....

	}

}
