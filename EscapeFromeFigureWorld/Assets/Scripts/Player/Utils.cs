using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Vector3 ScreenToWorldPosition(Camera camera, Vector3 position)
    {
        position.z = camera.nearClipPlane;
        return camera.ScreenToWorldPoint(position);
    }
}
