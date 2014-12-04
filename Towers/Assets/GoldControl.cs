using UnityEngine;
using System.Collections;

public class GoldControl : MonoBehaviour {
    private UILabel label;
    public bool isGold;

    void Start() {
        label = GetComponent<UILabel>();
    }

    void Update() {
        if(isGold) {
            label.text = GameManager.inst.cash + "";
        } else {
            label.text = GameManager.inst.lives + "";
        }

    }
}
