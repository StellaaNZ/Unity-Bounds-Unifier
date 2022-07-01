using UnityEditor;
using UnityEngine;

public class BoundsUnifier : EditorWindow
{
    GameObject parentObject;
    SkinnedMeshRenderer mainMesh;
    bool includeInactive = true;

    [MenuItem("Tools/Bounds Unifier")]
    public static void ShowWindow()
    {
        GetWindow(typeof(BoundsUnifier));
    }

    private void OnGUI()
    {
        GUILayout.Label("Bounds Unifier", EditorStyles.boldLabel);
        parentObject = EditorGUILayout.ObjectField("Parent Object", parentObject, typeof(GameObject), true) as GameObject;
        mainMesh = EditorGUILayout.ObjectField("Bounds to copy", mainMesh, typeof(SkinnedMeshRenderer), true) as SkinnedMeshRenderer;
        includeInactive = EditorGUILayout.Toggle("Include Inactive", includeInactive);

        if (GUILayout.Button("GO"))
        {
            ChangeBounds();
        }
    }

    private void ChangeBounds()
    {
        Vector3 mainExtents = mainMesh.localBounds.extents;
        Vector3 mainCenter = mainMesh.localBounds.center;

        Bounds mainBounds = mainMesh.localBounds;

        SkinnedMeshRenderer[] skinnedMeshes;
        
        if (includeInactive)
            skinnedMeshes = parentObject.GetComponentsInChildren<SkinnedMeshRenderer>(true);
        else
            skinnedMeshes = parentObject.GetComponentsInChildren<SkinnedMeshRenderer>(false);

        Debug.Log("Main Extends: (" + mainExtents.x.ToString() + ", " + mainExtents.y.ToString() + ", " + mainExtents.z.ToString() + ")");
        Debug.Log("Main Center: (" + mainCenter.x.ToString() + ", " + mainCenter.y.ToString() + ", " + mainCenter.z.ToString() + ")");

        foreach (SkinnedMeshRenderer skinnedMesh in skinnedMeshes)
        {
            if (skinnedMesh != mainMesh)
                skinnedMesh.localBounds = mainBounds;
        }

        Debug.Log("All Enabled Mesh Bounds Changed");
    }
}
