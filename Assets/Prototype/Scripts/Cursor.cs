using System;
using UnityEditor.U2D.Path;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public bool isHolding { get; set; }
    public Vector2 Mouse { get; set; }
    
    [Header("Layers")]
    [SerializeField] private LayerMask everythingLayer;
    [SerializeField] private LayerMask paternLayer;
    
    private Camera camera;
    private MovePlatform platform;

    private void Awake()
    {
        camera = GetComponent<Camera>();
        camera.cullingMask = everythingLayer;
    }

    private void Update()
    {
        if (isHolding)
        {
            platform.Move(camera.ScreenToWorldPoint(Mouse));
        }

        CatchPlatform();
    }

    public void CatchPlatform()
    {
        var hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Mouse), Vector2.zero);

        if (hit.collider == null)
        {
            return;
        }

        if (hit.collider.TryGetComponent<MovePlatform>(out var platform))
        {
            this.platform = platform;
            camera.cullingMask = paternLayer;
            isHolding = true;
        }
    }

    public void UncatchPlatform()
    {
        isHolding = false;
    }
    
}
