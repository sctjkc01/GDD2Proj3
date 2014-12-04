using UnityEngine;
using System.Collections;

public class FuseButton : MonoBehaviour {

    public static FuseButton inst;
    public ModuleControl mod1, mod2;
    public UILabel label;

    // Use this for initialization
    void Start() {
        inst = this;
    }

    public void AddModule(ModuleControl what) {
        if(mod1 == null) {
            mod1 = what;
        } else {
            mod2 = what;
        }
    }

    public void RemoveModule(ModuleControl what) {
        if(mod1 == what) {
            mod1 = null;
        } else if(mod2 == what) {
            mod2 = null;
        }
    }

    public bool HasModule(ModuleControl what) {
        return mod1 == what || mod2 == what;
    }

    void Update() {
        if(mod1 == null || mod2 == null) {
            label.text = ". . .";
            GetComponent<UIButton>().enabled = false;
        } else {
            int cost = (mod1.myModule.level + mod2.myModule.level + 1) * 5;
            if(GameManager.inst.cash < cost) {
                label.text = "You need\n" + cost + " Gold";
                GetComponent<UIButton>().enabled = false;
            } else {
                label.text = "Fuse for\n" + cost + " Gold";
                GetComponent<UIButton>().enabled = true;
            }
        }
    }
}
