using UnityEngine;
using System.Collections;

[System.Serializable]
public class TowerAttributes {
    public float Damage = 1.0f;
    public float FireRate = 1.0f;
    public float Splash = 1.0f;
    public float Range = 1.0f;
    public DamageElements Element = DamageElements.None;

    public static TowerAttributes operator +(TowerAttributes left, TowerAttributes right) {
        TowerAttributes rtn = new TowerAttributes();
        rtn.Damage = left.Damage + right.Damage;
        rtn.FireRate = left.FireRate + right.FireRate;
        rtn.Range = left.Range + right.Range;
        return rtn;
    }

    public static TowerAttributes operator *(TowerAttributes left, float right) {
        TowerAttributes rtn = new TowerAttributes();
        rtn.Damage = left.Damage * right;
        rtn.FireRate = left.FireRate * right;
        rtn.Range = left.Range * right;
        return rtn;
    }

    public override string ToString() {
        if(Element != DamageElements.None) return "Grants the " + Element + " element to a tower."; // No real use, sure, but meh
        else {
            string rtn = "";
            if(Damage > 0) {
                rtn += "+" + 4 * Damage + " Damage\n";
            }
            if(FireRate > 0) {
                rtn += Mathf.RoundToInt(1.0f / Mathf.Pow(0.8f, FireRate) * 100f) + "% Fire Rate\n";
            }
            if(Range > 0) {
                rtn += "+" + Range + " Tiles Range\n";
            }
            return rtn;
        }
    }
}

public enum DamageElements {
    None,
    Fire,
    Electric
}