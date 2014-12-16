using UnityEngine;
using System.Collections;

public class ModuleAnchor : MonoBehaviour {
    private Camera main;
    public TogglePlacement toggPlacementButton;
    public ModuleInstall moduleWindow;
    public GameObject modulePrefab;
    private Tower t;

    public UI2DSprite[] ModuleSlots;

    void Start() {
        main = GameObject.Find("World Camera").GetComponent<Camera>();
        moduleWindow.anchor = this;
    }

    void OnClick() {
        if(toggPlacementButton.toggOn) return;

        RaycastHit hitInfo;
        if(Physics.Raycast(main.ScreenPointToRay(Input.mousePosition), out hitInfo)) {
            GameObject hit = hitInfo.transform.gameObject;
            while(!(hit.transform.parent.gameObject.name.Equals("TileMap", System.StringComparison.InvariantCultureIgnoreCase))) {
                // Traverse up the Heirarchy until you get the main tile
                hit = hit.transform.parent.gameObject;
            }
            Tower foundTower = hit.GetComponentInChildren<Tower>();
            if(foundTower != null) {
                t = foundTower;
                ShowModules();
            } else {
                t = null;
                HideModules();
            }
            moduleWindow.tower = t;
        } else {
            t = null;
            HideModules();
        }
    }

    void Update() {
        if(toggPlacementButton.toggOn) t = null;

        if(t != null) {
            Vector2 loc = (Vector2)main.WorldToViewportPoint(t.transform.FindChild("Sphere").position);
            loc.x = GetComponent<UIWidget>().width * loc.x - 300;
            loc.y = GetComponent<UIWidget>().height * loc.y - 500;
            moduleWindow.transform.localPosition = loc;
        } else {
            moduleWindow.transform.localPosition = new Vector3(-1024, 0, 0);
        }
        for(int i = 0; i < 3; i++) {
            ModuleSlots[i].collider.enabled = !(ModuleSlots[i].transform.childCount > 0);
        }
    }

    void ShowModules() {
        HideModules();
        for(int i = 0; i < 3; i++) {
            if(t.attrMods[i] != null) {
                GameObject go = (GameObject)Instantiate(modulePrefab);
                FusedModule m = t.attrMods[i];
                go.name = m.name;
                go.GetComponent<UI2DSprite>().color = m.tint;
                ModuleControl mc = go.GetComponent<ModuleControl>();
                mc.myModule = m;
                mc.isOriginal = false;
                mc.isBase = m.name.Contains("Base");
                mc.installed = true;
                go.transform.parent = ModuleSlots[i].transform;
                go.transform.localPosition = Vector3.zero;
                go.transform.localScale = Vector3.one;
                ModuleSlots[i].collider.enabled = false;
            } else {
                ModuleSlots[i].collider.enabled = true;
            }
        }
    }

    public void HideModules() {
        ModuleControl[] ctrls = transform.GetComponentsInChildren<ModuleControl>();
        int cnt = ctrls.Length;
        for(int i = 0; i < cnt; i++) {
            Destroy(ctrls[i].gameObject);
        }
    }
}
