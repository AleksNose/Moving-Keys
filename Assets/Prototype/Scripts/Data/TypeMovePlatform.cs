using System;
using UnityEngine;

[Serializable]
public class TypeMovePlatform
{
    [field: SerializeField]
    public TypeMove Type { get; private set; }

    [field: SerializeField]
    public GameObject Prefab { get; private set; }

    public bool CanMove { get; set; }
}