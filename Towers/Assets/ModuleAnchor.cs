using UnityEngine;
using System.Collections;

public class ModuleAnchor : MonoBehaviour {
    private Camera main;
    public TogglePlacement toggPlacementButton;
    public GameObject moduleWindow;
    private Tower t;

    void Start() {
        main = GameObject.Find("World Camera").GetComponent<Camera>();
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
            } else {
                t = null;
            }
        }
    }

    void Update() {
        if(toggPlacementButton.toggOn) t = null;

        if(t != null) {
            Vector2 loc = (Vector2)main.WorldToScreenPoint(t.transform.FindChild("Sphere").position);
            loc.x /= 0.75f;
            loc.y /= 0.75f;
            moduleWindow.transform.localPosition = loc - new Vector2(600, 500);
        } else {
            moduleWindow.transform.localPosition = new Vector3(-1024, 0, 0);
        }
    }
}
