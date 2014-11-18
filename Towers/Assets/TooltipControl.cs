using UnityEngine;
using System.Collections;

public class TooltipControl : MonoBehaviour {
    public static TooltipControl inst;
    public UILabel nameField, desc;

    void Start() {
        if(inst == null) {
            inst = this;
        }
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
        desctext += "Level: " + fm.level;
        inst.desc.text = desctext;
    }

    public static void Hide() {
        inst.transform.position = new Vector3(0f, -10f, 0f);
    }

}
