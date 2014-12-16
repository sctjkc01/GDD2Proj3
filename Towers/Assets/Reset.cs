using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

    public void DoReset() {
        Application.LoadLevel(0);
    }
}
