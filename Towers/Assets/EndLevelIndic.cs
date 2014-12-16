using UnityEngine;
using System.Collections;

public class EndLevelIndic : MonoBehaviour {

	void Update () {
        gameObject.GetComponent<UILabel>().text = "" + GameManager.inst.level;
	}
}
