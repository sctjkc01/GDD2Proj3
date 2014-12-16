using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class Module {
    public TowerAttributes attribs;
    public int level;
    public Color tint;
    public string name;

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
