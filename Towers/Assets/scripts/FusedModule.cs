using UnityEngine;
using System.Collections;

[System.Serializable]
public class FusedModule : Module
{
    public FusedModule(Module m1, Module m2)
    {
        this.attribs = new TowerAttributes();
        Module.MultiplyAttributes(this.attribs, m1);
        Module.MultiplyAttributes(this.attribs, m2);
        this.level = m1.level + m2.level;
    }

    public FusedModule(float damage, float range, float fireRate, float splash, DamageElements elem)
    {
        this.level = 1;
        this.attribs = new TowerAttributes();
        this.attribs.Damage = damage;
        this.attribs.Range = range;
        this.attribs.FireRate = fireRate;
        this.attribs.Splash = splash;
        this.attribs.Element = elem;
    }

    public FusedModule(FusedTemplate template) {
        this.level = 1;
        this.attribs = template.attribs;
    }
}
