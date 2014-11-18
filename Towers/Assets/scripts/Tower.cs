using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SphereCollider))]
public class Tower : MonoBehaviour
{

    /// <summary>
    /// The _mods only GameObject for now
    /// </summary>
    public Module[] mods = new Module[4];
    /// <summary>
    /// Attributes for this tower. Multiplied off of our Modules.
    /// </summary>
    public TowerAttributes attribs;
    public List<GameObject> enemies = new List<GameObject>();

    private SphereCollider colider;
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

    void Fire(GameObject target)
    {

        Debug.Log(target.name);

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
        if (mods[0] == null)
        {
            for (int i = 0; i < 4; i++)
            {
                mods[i] = new BaseModule();
            }
        }
        foreach (Module m in mods)
        {
            Module.MultiplyAttributes(attribs, m);
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
