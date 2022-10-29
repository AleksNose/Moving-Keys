using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public TypeMove Type { get; private set; }

    public void PlatformMode(bool mode)
    {
        Catch(mode);
    }

    public void Move(Vector3 vector)
    {
        Debug.Log(vector);
        gameObject.transform.position = new Vector3(vector.x, vector.y, 0f);
        Catch(true);
    }

    public void Catch(bool isCatch)
    {
        var collider = GetComponent<Collider2D>();
        
        if (isCatch)
        {
            collider.isTrigger = true;
            return;
        }

        collider.isTrigger = false;
    }
}