using UnityEngine;
using System.Collections;
//using UnityEditor;

public class TileMapRuntimeEditor {
    public static bool SetTile(int x, int z, Transform prefab, int direction) {
        var tm = GameObject.Find("TileMap").GetComponent<TileMap>();

        var hash = tm.GetHash(x, z);
        var index = tm.hashes.IndexOf(hash);
        if(index >= 0) {
            //Replace existing tile
            tm.prefabs[index] = prefab;
            if(direction < 0)
                tm.directions[index] = Random.Range(0, 4);
            else
                tm.directions[index] = direction;
            return UpdateTile(index);
        } else if(prefab != null) {
            //Create new tile
            index = tm.prefabs.Count;
            tm.hashes.Add(hash);
            tm.prefabs.Add(prefab);
            if(direction < 0)
                tm.directions.Add(Random.Range(0, 4));
            else
                tm.directions.Add(direction);
            tm.instances.Add(null);
            return UpdateTile(index);
        } else
            return false;
    }

    private static bool UpdateTile(int index) {
        var tm = GameObject.Find("TileMap").GetComponent<TileMap>();

        //Destroy existing tile
        if(tm.instances[index] != null) {
#if UNITY_4_3
			Undo.DestroyObjectImmediate(tm.instances[index].gameObject);
#else
            GameObject.DestroyImmediate(tm.instances[index].gameObject);
#endif
        }

        //Check if prefab is null
        if(tm.prefabs[index] != null) {
            //Place the tile
            var instance = (Transform)GameObject.Instantiate(tm.prefabs[index]);
            instance.parent = tm.transform;
            instance.localPosition = tm.GetPosition(index);
            instance.localRotation = Quaternion.Euler(0, tm.directions[index] * 90, 0);
            tm.instances[index] = instance;
            return true;
        } else {
            //Remove the tile
            tm.hashes.RemoveAt(index);
            tm.prefabs.RemoveAt(index);
            tm.directions.RemoveAt(index);
            tm.instances.RemoveAt(index);
            return false;
        }
    }
}
