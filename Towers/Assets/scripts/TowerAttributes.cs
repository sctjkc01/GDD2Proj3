using UnityEngine;
using System.Collections;

public class TowerAttributes {
    private float damage = 1.0f;
    private float fireRate = 1.0f;
    private float splash = 1.0f;
    private float range = 1.0f;
    private DamageElements elem = DamageElements.None;

    public float Damage 
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }

    public float FireRate
    {
        get
        {
            return fireRate;
        }
        set
        {
            fireRate = value;
        }
    }

    public float Splash
    {
        get
        {
            return splash;
        }
        set
        {
            splash = value;
        }
    }

    public float Range
    {
        get
        {
            return range;
        }
        set
        {
            range = value;
        }
    }

    public DamageElements Element
    {
        get
        {
            return elem;
        }
        set
        {
            elem = value;
        }
    }
}

public enum DamageElements
{
    None,
    Fire,
    Electric
}