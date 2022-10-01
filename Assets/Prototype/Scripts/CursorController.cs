using UnityEngine;

public class CursorController : MonoBehaviour
{
    private Vector2 mouseVector;

    private bool isCatchPlatform;
    private Camera camera;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        DetectPlatform();
    }

    private void DetectPlatform()
    {
        var ray = camera.ScreenPointToRay(mouseVector);
        var hits = Physics2D.GetRayIntersection(ray);

        if (hits.collider.gameObject.tag == "Platform")
        {
            isCatchPlatform = !isCatchPlatform;
        }
    }
}
