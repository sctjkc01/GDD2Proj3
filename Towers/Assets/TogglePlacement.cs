using UnityEngine;
using System.Collections;

public class TogglePlacement : MonoBehaviour {

    private UIButton sprite;
    public UILabel label;
    private bool toggOn = false;
    public Color OnColor, OffColor;

    void Start() {
        sprite = GetComponent<UIButton>();
    }


    public void Toggle()
    {
        toggOn = !toggOn;
        if (toggOn)
        {
            sprite.defaultColor = OnColor;
            label.text = "Click to stop\nbuying towers";
        }
        else
        {
            sprite.defaultColor = OffColor;
            label.text = "Click to\nbuy towers";
        }
    }
}
