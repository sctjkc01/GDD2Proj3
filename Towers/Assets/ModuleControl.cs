using UnityEngine;
using System.Collections;

public class ModuleControl : UIDragDropItem {
    public FusedTemplate template;
    public FusedModule myModule;
    public bool isOriginal = false;
    public bool isBase = false;
    public bool installed = false;

    protected override void Start() {
        base.Start();
        if(template != null) {
            isOriginal = true;
            isBase = true;
            myModule = new FusedModule(template);
            myModule.tint = GetComponent<UI2DSprite>().color;
            myModule.name = gameObject.name;
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
        base.OnDragDropStart();
    }

    protected override void OnDragDropMove(Vector3 delta) {
        FuseButton.inst.RemoveModule(this);
        isOriginal = false;
        mCollider.enabled = false;
        if(installed) {
            installed = false;
            ModuleInstall.inst.tower.RemoveModule(myModule);
            transform.parent = UIDragDropRoot.root;
            NGUITools.MarkParentAsChanged(gameObject);
        }
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
        if(surface == null || (surface.name != "DropArea" && surface.name != "AttrMod") || surface.name == "Container") {
            if(isBase) {
                Destroy(gameObject);
            } else {
                surface = GameObject.Find("FusionGUI");
                mCollider.enabled = true;
                if(surface != null && surface.GetComponent<UIDragDropContainer>() != null) {
                    transform.parent = surface.GetComponent<UIDragDropContainer>().reparentTarget;
                    NGUITools.MarkParentAsChanged(gameObject);
                    mGrid = transform.parent.GetComponent<UIGrid>();
                    if(mGrid != null) mGrid.repositionNow = true;
                }
            }
        } else if(surface.name == "DropArea") {
            if(surface.transform.childCount == 3) {
                if(isBase) {
                    Destroy(gameObject);
                } else {
                    surface = GameObject.Find("FusionGUI");
                    mCollider.enabled = true;
                    if(surface != null && surface.GetComponent<UIDragDropContainer>() != null) {
                        transform.parent = surface.GetComponent<UIDragDropContainer>().reparentTarget;
                        NGUITools.MarkParentAsChanged(gameObject);
                        mGrid = transform.parent.GetComponent<UIGrid>();
                        if(mGrid != null) mGrid.repositionNow = true;
                    }
                }
            } else {
                transform.parent = surface.transform;
                NGUITools.MarkParentAsChanged(gameObject);
                mCollider.enabled = true;

                FuseButton.inst.AddModule(this);

            }
        } else if(surface.name == "AttrMod") {
            mCollider.enabled = true;
            transform.parent = surface.transform;
            NGUITools.MarkParentAsChanged(gameObject);
            installed = true;
            ModuleInstall.inst.tower.InstallModule(myModule);
        }
        transform.localRotation = Quaternion.identity;
    }
}
