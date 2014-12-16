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
            GetComponent<UIButton>().isEnabled = false;
        } else {
            int cost = (mod1.myModule.level + mod2.myModule.level + 1) * 5;
            if(GameManager.inst.cash < cost) {
                label.text = "You need\n" + cost + " Gold";
                GetComponent<UIButton>().isEnabled = false;
            } else {
                label.text = "Fuse for\n" + cost + " Gold";
                GetComponent<UIButton>().isEnabled = true;
            }
        }
    }

    public void Fuse() {
        int cost = (mod1.myModule.level + mod2.myModule.level + 1) * 5;
        if(mod1 == null || mod2 == null || GameManager.inst.cash < cost) {
            Debug.LogError("Something isn't right...", this.gameObject);
        } else {
            mod1.myModule.attribs.Damage += mod2.myModule.attribs.Damage;
            mod1.myModule.attribs.FireRate += mod2.myModule.attribs.FireRate;
            mod1.myModule.attribs.Range += mod2.myModule.attribs.Range;
            mod1.myModule.level += mod2.myModule.level;
            mod1.isBase = false;
            mod1.gameObject.name = "Fused Module";
            mod1.GetComponent<UI2DSprite>().color = (mod1.GetComponent<UI2DSprite>().color * 0.55f) + (mod2.GetComponent<UI2DSprite>().color * 0.55f);
            mod1.myModule.tint = mod1.GetComponent<UI2DSprite>().color;
            mod1.myModule.name = "Fused Module";
            DestroyImmediate(mod2.gameObject);
            mod2 = null;
            mod1.transform.localPosition = Vector3.zero;
            GameManager.inst.cash -= cost;
        }
    }
}
