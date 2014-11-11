using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class IndicatorControl : MonoBehaviour {

    public Sprite green, red;
    private bool isGreen;

    public bool Green {
        set {
            isGreen = value;

            if(isGreen) {
                GetComponent<SpriteRenderer>().sprite = green;
            } else {
                GetComponent<SpriteRenderer>().sprite = red;
            }
        }
        get {
            return isGreen;
        }
    }
}
