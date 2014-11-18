using UnityEngine;
using System.Collections;

[System.Serializable]
public class TowerAttributes {
    public float Damage = 1.0f;
    public float FireRate = 1.0f;
    public float Splash = 1.0f;
    public float Range = 1.0f;
    public DamageElements Element = DamageElements.None;
}

public enum DamageElements {
    None,
    Fire,
    Electric
}