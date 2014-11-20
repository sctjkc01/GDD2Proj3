using UnityEngine;
using System.Collections;

public class TooltipControl : MonoBehaviour {
    public static TooltipControl inst;
    public UILabel nameField, desc;

    void Start() {
        if(inst == null) {
            inst = this;
        }
        Hide();
    }

    public static void Show(GameObject mod) {
        Vector3 loc = mod.transform.position + new Vector3(-0.1f, 0f, -0.01f);

        if(loc.y < -100) {
            loc.y += 150;
        }
        inst.transform.position = loc;

        inst.nameField.text = "[b]" + mod.name + "[/b]";
        string desctext = "";
        FusedModule fm = mod.GetComponent<ModuleControl>().myModule;
        if(fm.attribs.Element != DamageElements.None) {
            desctext = "Grants the " + fm.attribs.Element + " element to a tower.";
        } else {
            desctext += "Level: " + fm.level + "\n\n";
            if(fm.attribs.Damage > 1) {
                desctext += "+" + Mathf.RoundToInt((fm.attribs.Damage - 1) * 100) + "% Damage\n";
            }
            if(fm.attribs.FireRate > 1) {
                desctext += "+" + Mathf.RoundToInt((fm.attribs.FireRate - 1) * 100) + "% Fire Rate\n";
            }
            if(fm.attribs.Range > 1) {
                desctext += "+" + Mathf.RoundToInt((fm.attribs.Range - 1) * 100) + "% Range\n";
            }
            if(fm.attribs.Splash > 1) {
                desctext += "+" + Mathf.RoundToInt((fm.attribs.Splash - 1) * 100) + "% Splash Radius\n";
            }
        }
        inst.desc.text = desctext;
    }

    public static void Hide() {
        inst.transform.position = new Vector3(0f, -10f, 0f);
    }

}
