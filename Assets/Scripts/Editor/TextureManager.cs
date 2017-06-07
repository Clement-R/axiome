using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR

using UnityEditor;

public class TextureManager : EditorWindow {

    [MenuItem("Window/Texture Manager")]
    public static void ShowWindow() {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(TextureManager));
    }

    public void OnGUI() {
        string[] path = { "Assets/Assets/MotionDesign" };
        if (GUILayout.Button("Reimport textures")) {
            TextureImporterPlatformSettings androidSettings = new TextureImporterPlatformSettings();
            androidSettings.name = "Android";
            androidSettings.maxTextureSize = 512;
            androidSettings.overridden = true;

            string[] motionDesignTextures = AssetDatabase.FindAssets("Comp t:texture2D", path);
            foreach (var texture in motionDesignTextures) {
                TextureImporter textureSettings = TextureImporter.GetAtPath(AssetDatabase.GUIDToAssetPath(texture)) as TextureImporter;

                textureSettings.maxTextureSize = 512;
                textureSettings.mipmapEnabled = false;
                
                textureSettings.SetPlatformTextureSettings(androidSettings);
                textureSettings.SaveAndReimport();
            }
        }
    }
}

#endif