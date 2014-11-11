using UnityEngine;
using System.Collections;

public class AddTower : MonoBehaviour {
    public Transform TowerPrefab;

    void OnMouseUpAsButton() {
        Invoke("SetTile", 0.1f);
    }

    void SetTile() {
        TileMapRuntimeEditor.SetTile((int)transform.position.x, (int)transform.position.z, TowerPrefab, 0);
    }

}
