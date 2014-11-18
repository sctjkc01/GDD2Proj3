using UnityEngine;
using System.Collections;

public class StopZoom : MonoBehaviour {

    void OnHover(bool isOver) {
        CameraControl.zoomOnScroll = !isOver;
    }
}
