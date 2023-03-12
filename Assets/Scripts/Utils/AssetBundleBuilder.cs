using UnityEditor;
using UnityEngine;
using System.IO;

#if UNITY_EDITOR
public class AssetBundleBuilder
{
    const string DIR_PATH = "Assets/StreamingAssets";

	[MenuItem("Assets/Build AssetBundles")]
	static void BuildAssetBundlesAll()
	{
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(DIR_PATH);
        }
        BuildPipeline.BuildAssetBundles(DIR_PATH, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
	}
}
#endif