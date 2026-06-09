using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform p1;
    public Transform p2;

    public float minZoom = 5f;
    public float maxZoom = 10f;
    public float maxDistance = 20f;

    void LateUpdate()
    {
        Vector3 center = (p1.position + p2.position) / 2f;
        transform.position = new Vector3(center.x, center.y, -10f);

        float distance = Vector2.Distance(p1.position, p2.position);

        float t = Mathf.Clamp01(distance / maxDistance);
        t = t * t * (3f - 2f * t); // smoothstep

        float zoom = Mathf.Lerp(minZoom, maxZoom, t);

        Camera.main.orthographicSize =
            Mathf.Lerp(Camera.main.orthographicSize, zoom, 5f * Time.deltaTime);
    }
}