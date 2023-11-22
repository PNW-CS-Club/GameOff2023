using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class ColliderSnapper : MonoBehaviour
{
    [SerializeField] [Min(0.01f)] float increment = 0.5f;

    public void Snap() {

        PolygonCollider2D poly = transform.GetComponent<PolygonCollider2D>();

        for (int n = 0; n < poly.pathCount; n++) {
            Vector2[] path = poly.GetPath(n);

            for (int p = 0; p < path.Length; p++) {
                //shift each polygon point to be on the grid
                Vector2 v2 = path[p];
                float x = Mathf.Round(v2.x / increment) * increment;
                float y = Mathf.Round(v2.y / increment) * increment;
                path[p] = new Vector2(x, y);
            }

            poly.SetPath(n, path);
        }

        // the editor needs to know that we changed something
        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
    }
}


// allows us to make a button in the inspector
[CustomEditor(typeof(ColliderSnapper))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        ColliderSnapper snapperScript = (ColliderSnapper)target;
        // creates a button that calls the snap function
        if (GUILayout.Button("Snap")) {
            snapperScript.Snap();
        }
    }
}