using UnityEngine;
using System.Collections;

public class StopZoom : MonoBehaviour {

    void OnHover(bool isOver) {
        CameraControl.zoomOnScroll = !isOver;
    }

    void OnScroll(float delta)
    {
        GameObject.Find("Scroll View").GetComponent<UIScrollView>().Scroll(delta);
    }
}
