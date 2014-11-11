using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    // Update is called once per frame
    void Update() {
        transform.Translate(new Vector3(0, 0, -1) * Input.GetAxis("Horizontal") * 15.0f * Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? 2.0f : 1.0f), Space.World);
    }
}
