using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SerializableManager", menuName = "ScriptableObjects/SerializableManager")]
public class SerializableManager : ScriptableObject
{
    public IReadOnlyList<TypeMovePlatform> MoveButtons => moveButtons;

    [field: SerializeField]
    private List<TypeMovePlatform> moveButtons;
}