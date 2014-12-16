using UnityEngine;
using System.Collections;

public class TogglePlacement : MonoBehaviour {

    private UIButton sprite;
    public UILabel label;
    [HideInInspector]
    public bool toggOn = false;
    public Color OnColor, OffColor;

    void Start() {
        sprite = GetComponent<UIButton>();
    }


    public void Toggle() {
        toggOn = !toggOn;
        if(toggOn) {
            sprite.defaultColor = OnColor;
            label.text = "Click to stop\nbuying towers";
        } else {
            sprite.defaultColor = OffColor;
            label.text = "Click to\nbuy towers";
        }

        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        for(int i = 0; i < towers.Length; i++) {
            towers[i].GetComponent<CapsuleCollider>().enabled = !toggOn;
        }
    }
}
