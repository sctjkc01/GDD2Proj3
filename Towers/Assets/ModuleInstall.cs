using UnityEngine;
using System.Collections;

public class ModuleInstall : MonoBehaviour {

    public static ModuleInstall inst;

    public ModuleAnchor anchor;
    public Tower tower;

    // Use this for initialization
    void Start() {
        inst = this;
    }
}
