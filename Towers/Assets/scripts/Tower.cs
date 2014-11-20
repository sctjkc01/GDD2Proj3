using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SphereCollider))]
public class Tower : MonoBehaviour
{

    /// <summary>
    /// The _mods only GameObject for now
    /// </summary>
    public FusedModule[] attrMods = new FusedModule[3];
    public FusedModule elementMod = null;
    /// <summary>
    /// Attributes for this tower. Multiplied off of our Modules.
    /// </summary>
    public TowerAttributes attribs;
    public List<Enemy> enemies = new List<Enemy>();

    private SphereCollider colider;
    private float _timer = 0;



    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Enemy")
        {
			Debug.Log("boop");
            enemies.Add(obj.gameObject.GetComponent<Enemy>());
        }

		Debug.Log("boop");

    }


    void OnTriggerExit(Collider obj)
    {
        if (obj.tag == "Enemy")
        {
			enemies.Remove(obj.gameObject.GetComponent<Enemy>());
        }
    }

    void Fire(Enemy e)
    {

		e.takeDamage(attribs.Damage);

        _timer = attribs.FireRate;

    }

    void StartRound()
    {
        colider.enabled = true;
    }

    void EndRound()
    {
        colider.enabled = false;
    }


    // Use this for initialization
    void Start()
    {
        colider = this.gameObject.GetComponent<SphereCollider>();
        attribs = new TowerAttributes();
        attribs.FireRate = 0.5f;
        //if (mods[0] == null)
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        mods[i] = ScriptableObject.CreateInstance<BaseModule>();
        //    }
        //}
        for(int i = 0; i < 3; i++) 
        {
            if(attrMods[i] != null) {
                Module.MultiplyAttributes(attribs, attrMods[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0 && enemies.Count != 0)
        {
            if (enemies[0] == null) { enemies.RemoveAt(0); }
            else
            {
                Fire(enemies[0]);
            }
        }

    }
}
