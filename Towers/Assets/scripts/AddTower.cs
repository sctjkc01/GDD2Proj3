using UnityEngine;
using System.Collections.Generic;

public class AddTower : MonoBehaviour {
    public static List<PathTile> PathTestBlacklist;
    public static Transform indicator;
    public static bool PlacingTowers = true;
    public Transform TowerPrefab;

    void Start() {
        if(indicator == null) {
            indicator = GameObject.Find("TowerPlace Indicator").transform;
        }
    }

    void OnMouseEnter() {
        if(PlacingTowers) {
            indicator.position = transform.position + new Vector3(-0.5f, 0.1f, -0.5f);

            IndicatorControl ic = indicator.GetComponent<IndicatorControl>();

            Collider[] colls = Physics.OverlapSphere(transform.position + new Vector3(-0.5f, 0.1f, -0.5f), 1f);
            if(colls.Length < 4) { // If this goes off the edge, not valid placement.
                Debug.Log("Fail: Off Edge");
                ic.Green = false;
                return;
            }
            PathTestBlacklist = new List<PathTile>();
            foreach(Collider alpha in colls) {
                if(alpha.GetComponent<PathTile>() == null) { // If this tile doesn't have a PathTile (aka isn't empty), not valid placement.
                    Debug.Log("Fail: Obstructed");
                    ic.Green = false;
                    return;
                }
                PathTestBlacklist.Add(alpha.GetComponent<PathTile>());
            }
            if(GameObject.Find("TileMap").GetComponent<TileMap>().FindPath(Enemy.start, Enemy.end, new List<PathTile>(), tile => !(PathTestBlacklist.Contains(tile)))) { // Don't care about getting the path, just check to see if a path exists
                Debug.Log("Pass");
                ic.Green = true; // Found a path around this new tower, allow placement
            } else {
                Debug.Log("Fail: Blocking");
                ic.Green = false; // Could not find path around new tower, not valid placement
            }
        }
    }

    void OnMouseExit() {
        indicator.position = new Vector3(0f, -1.1f, 0f);
    }

    void OnMouseUpAsButton() {
        if(PlacingTowers && indicator.GetComponent<IndicatorControl>().Green) {
            Invoke("SetTile", 0.1f);
        }
    }

    void SetTile() {
        Collider[] colls = Physics.OverlapSphere(transform.position + new Vector3(-0.5f, 0.1f, -0.5f), 1f);
        foreach(Collider alpha in colls) {
            Destroy(alpha.GetComponent<PathTile>());
        }

        TileMapRuntimeEditor.SetTile((int)transform.position.x, (int)transform.position.z, TowerPrefab, 0);

    }

}
