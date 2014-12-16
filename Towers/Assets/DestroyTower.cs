using UnityEngine;
using System.Collections;

public class DestroyTower : MonoBehaviour {

    public Transform EmptyPrefab;

    public void Delete() {
        GameManager.inst.cash += 5;
        Invoke("SetTile", 0.1f);
    }

    void SetTile() {
        Tower t = ModuleInstall.inst.tower;
        for(int i = 0; i < 3; i++) {
            if(t.attrMods[i] != null && !t.attrMods[i].name.Contains("Base")) {
                GameObject go = (GameObject)Instantiate(ModuleInstall.inst.anchor.modulePrefab);
                FusedModule m = t.attrMods[i];
                go.name = m.name;
                go.GetComponent<UI2DSprite>().color = m.tint;
                ModuleControl mc = go.GetComponent<ModuleControl>();
                mc.myModule = m;
                mc.isOriginal = false;
                mc.isBase = false;
                mc.installed = false;
                go.transform.parent = GameObject.Find("FusionGUI").GetComponent<UIDragDropContainer>().reparentTarget;
                NGUITools.MarkParentAsChanged(go);
                go.transform.localPosition = Vector3.zero;
                go.transform.parent.GetComponent<UIGrid>().repositionNow = true;
                go.transform.localScale = Vector3.one;
            }
        }

        Transform tileTransform = ModuleInstall.inst.tower.transform.parent;
        ModuleInstall.inst.tower = null;
        ModuleInstall.inst.anchor.HideModules();

        Vector3 loc = tileTransform.position;

        TileMapRuntimeEditor.SetTile((int)loc.x, (int)loc.z, EmptyPrefab, 0);
        Collider[] colls = Physics.OverlapSphere(loc + new Vector3(-0.5f, 0.1f, -0.5f), 1f);
        foreach(Collider alpha in colls) {
            alpha.gameObject.AddMissingComponent<PathTile>();
        }
    }
}
