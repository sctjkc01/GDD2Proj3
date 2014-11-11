using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraControl : MonoBehaviour {

    private Camera cam;

    void Start() {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 translate = new Vector3(0, 0, -1) * Input.GetAxis("Horizontal") * cam.orthographicSize * 2.0f * Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? 2.0f : 1.0f);
        translate += new Vector3(1, 0, 0) * Input.GetAxis("Vertical") * cam.orthographicSize * 2.0f * Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? 2.0f : 1.0f);
        transform.Translate(translate, Space.World);

        cam.orthographicSize += Input.GetAxis("Mouse ScrollWheel") * -2.5f;
    }
}
