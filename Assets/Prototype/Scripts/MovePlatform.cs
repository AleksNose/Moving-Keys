using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public TypeMove Type { get; private set; }

    private Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    public void Catch(bool isCatch)
    {
        if (isCatch)
        {
            collider.isTrigger = false;
            return;
        }

        collider.isTrigger = true;
    }
}