using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool IsDrag { get; set; }

    private void OnTriggerEnter2D (Collider2D col)
    {
        if (IsDrag == false && col.gameObject.CompareTag("NotPlatform"))
        {
            Destroy(this);
        }

        GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
