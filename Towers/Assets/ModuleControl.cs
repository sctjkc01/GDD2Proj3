using UnityEngine;
using System.Collections;

public class ModuleControl : UIDragDropItem {
    public FusedTemplate template;
    public FusedModule myModule;
    public bool isOriginal = false;
    public bool isBase = false;

    protected override void Start() {
        base.Start();
        if(template != null) {
            isOriginal = true;
            isBase = true;
            myModule = new FusedModule(template);
            template = null;
        }
        cloneOnDrag = isOriginal && isBase;
    }

    void OnHover(bool isOver) {
        if(isOver) {
            TooltipControl.Show(this.gameObject);
        } else {
            TooltipControl.Hide();
        }
    }

    protected override void OnDragDropStart() {
        if(FuseButton.inst.HasModule(this)) {
            FuseButton.inst.RemoveModule(this);
        }
        base.OnDragDropStart();
    }

    protected override void OnDragDropMove(Vector3 delta) {
        isOriginal = false;
        mCollider.enabled = false;
        if(transform.parent.GetComponent<UIGrid>() != null) {
            transform.parent.GetComponent<UIGrid>().repositionNow = true;
            transform.parent = UIDragDropRoot.root;
            NGUITools.MarkParentAsChanged(gameObject);
        }
        if(gameObject.name.EndsWith("(Clone)")) {
            gameObject.name = gameObject.name.Remove(gameObject.name.Length - 7);
        }
        TooltipControl.Hide();
        base.OnDragDropMove(delta);
    }

    protected override void OnDragDropRelease(GameObject surface) {
        if (surface != null && surface.transform.parent.gameObject.name == "DropArea") {
            surface = surface.transform.parent.gameObject;
        }
        if(surface == null || surface.name != "DropArea") {
            if(isBase) {
                Destroy(gameObject);
            } else {
                if(surface == null) surface = GameObject.Find("FusionGUI");
                mCollider.enabled = true;
                if(surface != null && surface.GetComponent<UIDragDropContainer>() != null) {
                    transform.parent = surface.GetComponent<UIDragDropContainer>().reparentTarget;
                    NGUITools.MarkParentAsChanged(gameObject);
                    mGrid = NGUITools.FindInParents<UIGrid>(transform.parent);
                    if(mGrid != null) mGrid.repositionNow = true;
                }
            }
        } else if(surface.name == "DropArea") {
            if(surface.transform.childCount == 3) {
                if(isBase) {
                    Destroy(gameObject);
                } else {
                    if(surface == null) surface = GameObject.Find("FusionGUI");
                    mCollider.enabled = true;
                    if(surface != null && surface.GetComponent<UIDragDropContainer>() != null) {
                        transform.parent = surface.GetComponent<UIDragDropContainer>().reparentTarget;
                        NGUITools.MarkParentAsChanged(gameObject);
                        mGrid = NGUITools.FindInParents<UIGrid>(transform.parent);
                        if(mGrid != null) mGrid.repositionNow = true;
                    }
                }
            } else {
                transform.parent = surface.transform;
                NGUITools.MarkParentAsChanged(gameObject);
                mCollider.enabled = true;

                FuseButton.inst.AddModule(this);

            }


            //ModuleControl[] MCs = surface.transform.GetComponentsInChildren<ModuleControl>();
            //if(MCs.Length == 2) {
            //    Debug.Log("Attempt fusion!");
            //    ModuleControl othermc = null;
            //    foreach(ModuleControl mc in MCs) {
            //        if(mc != this) {
            //            othermc = mc;
            //        }
            //    }
            //    Debug.Log(othermc.gameObject.name, othermc.gameObject);
            //    Debug.Log((myModule != null) + ", " + (othermc.myModule != null));
            //    if(myModule != null && othermc.myModule != null) {
            //        Debug.Log("Fusion!");
            //        othermc.myModule = new FusedModule(myModule, othermc.myModule);
            //        othermc.isBase = false;
            //        othermc.gameObject.name = "Fused Module";
            //        Destroy(this.gameObject);
            //    }
            //}
        }
    }
}
