using System.IO;
using UnityEditor;
using UnityEngine;

public class TemplateMaker {

    [MenuItem("Assets/Create/Module Template")]
    static void CreateTemplate() {
        ScriptableObject asset = ScriptableObject.CreateInstance<FusedTemplate>();
        var path = AssetDatabase.GetAssetPath(Selection.activeObject);

        if(string.IsNullOrEmpty(path))
            path = "Assets";
        else if(Path.GetExtension(path) != "")
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
        else
            path += "/";

        var assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "ModuleTemplate.asset");
        AssetDatabase.CreateAsset(asset, assetPathAndName);
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
        asset.hideFlags = HideFlags.DontSave;
    }
}
