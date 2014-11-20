using UnityEngine;
using System.Collections;

public class TogglePlacement : MonoBehaviour {

    private UIButton sprite;
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
        }
        else
        {
            sprite.defaultColor = OffColor;
        }
    }
}
