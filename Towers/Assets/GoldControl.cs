using UnityEngine;
using System.Collections;

public class GoldControl : MonoBehaviour {
    private UILabel label;

    void Start() {
        label = GetComponent<UILabel>();
    }

    void Update() {
        label.text = GameManager.inst.cash + "";
    }
}
