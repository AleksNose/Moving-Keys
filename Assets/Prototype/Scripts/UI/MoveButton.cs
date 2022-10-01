using System;
using UnityEngine;

public class MoveButton : DefaultButton
{
    public event Action <bool> OnClickButton = delegate { };

    [field: SerializeField]
    public TypeMove Type { get; private set; }
    public GameObject Platform { get; set; }

    private bool isPlatform;

    public override void OnClick()
    {
        base.OnClick();
        OnPlatform();
    }

    public void OnPlatform()
    {
        if (!isPlatform)
        {
            Instantiate(Platform);
            return;
        }
    }
}