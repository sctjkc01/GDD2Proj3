using UnityEngine;
using System.Collections;

public class ModuleControl : UIDragDropItem {
    public FusedTemplate template;
    public FusedModule myModule;
    public bool isOriginal = true;
    public bool isBase = true;

    protected override void Start() {
        base.Start();
        if(template != null) {
            isOriginal = true;
            isBase = true;
            myModule = new FusedModule(template);
            template = null;
        }
    }

    void OnHover(bool isOver) {
        cloneOnDrag = isOriginal && isBase;
        if(isOver) {
            TooltipControl.Show(this.gameObject);
        } else {
            TooltipControl.Hide();
        }
    }

    //protected override void OnDragDropStart() {
    //    base.OnDragDropStart();
    //}

    protected override void OnDragDropMove(Vector3 delta) {
        isOriginal = false;
        mCollider.enabled = false;
        if(transform.parent.GetComponent<UIGrid>() != null) {
            transform.parent.GetComponent<UIGrid>().repositionNow = true;
            transform.parent = transform.parent.parent.parent;
        }
        if(gameObject.name.EndsWith("(Clone)")) {
            gameObject.name = gameObject.name.Remove(gameObject.name.Length - 7);
        }
        base.OnDragDropMove(delta);
    }

    protected override void OnDragDropRelease(GameObject surface) {
        if(surface == null || surface.name != "Fusion Plate") {
            if(isBase) {
                Destroy(gameObject);
            } else {
                if(surface == null) surface = GameObject.Find("ModuleGUI");
                mCollider.enabled = true;
                if(surface.GetComponent<UIDragDropContainer>() != null) {
                    transform.parent = surface.GetComponent<UIDragDropContainer>().reparentTarget;
                    mGrid = NGUITools.FindInParents<UIGrid>(transform.parent);
                    if(mGrid != null) mGrid.repositionNow = true;
                }
            }
        } else if(surface.name == "Fusion Plate") {
            transform.parent = surface.transform;
            mCollider.enabled = true;
            ModuleControl[] MCs = surface.transform.GetComponentsInChildren<ModuleControl>();
            if(MCs.Length == 2) {
                Debug.Log("Attempt fusion!");
                ModuleControl othermc = null;
                foreach(ModuleControl mc in MCs) {
                    if(mc != this) {
                        othermc = mc;
                    }
                }
                Debug.Log(othermc.gameObject.name, othermc.gameObject);
                Debug.Log((myModule != null) + ", " + (othermc.myModule != null));
                if(myModule != null && othermc.myModule != null) {
                    Debug.Log("Fusion!");
                    othermc.myModule = new FusedModule(myModule, othermc.myModule);
                    othermc.isBase = false;
                    othermc.gameObject.name = "Fused Module";
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
