using UnityEngine;
using System.Collections;

public abstract class Module : ScriptableObject {
    public TowerAttributes attribs;
    public int level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void MultiplyAttributes (TowerAttributes a, Module m)
    {
        a.Damage *= m.attribs.Damage;
        a.FireRate *= m.attribs.FireRate;
        a.Range *= m.attribs.Range;
        a.Splash *= m.attribs.Splash;
        if (m.attribs.Element != DamageElements.None)
        {
            a.Element = m.attribs.Element;
        }
    }
}
