using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

// Output the build size or a failure depending on BuildPlayer.

public class BuildPlayer : MonoBehaviour
{
    [MenuItem("Build/Build AOS")]
    public static void MyBuild_AOS()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/GameScene2.unity" };
        buildPlayerOptions.locationPathName = $"Builds/AOS_{PlayerSettings.bundleVersion}.apk";//ºôµåÅ×½ºÆ®
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }
}