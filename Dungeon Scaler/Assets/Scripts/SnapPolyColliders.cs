using UnityEditor;
using UnityEngine;

public class MenuTest : MonoBehaviour
{
    [MenuItem("Custom Menu/Snap Polygon Colliders")]
    static void SnapPolyPaths() {
        var gos = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        var count = 0;

        for (var i = 0; i < gos.Length; i++) {
            var go = gos[i];
            var polys = go.GetComponentsInChildren<PolygonCollider2D>(true);

            foreach (var poly in polys) {
                for (var n = 0; n < poly.pathCount; n++) {
                    var path = poly.GetPath(n);

                    for (var p = 0; p < path.Length; p++) {
                        var v2 = path[p];
                        var x = Mathf.Round(v2.x * 2f) / 2f; // Snaps every 0.5f
                        var y = Mathf.Round(v2.y * 2f) / 2f; // Snaps every 0.5f

                        path[p] = new Vector2(x, y);
                    }

                    poly.SetPath(n, path);
                }

                count++;
            }
        }

        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());

        Debug.LogFormat("Snapped {0} poly colliders.", count);
    }

}
