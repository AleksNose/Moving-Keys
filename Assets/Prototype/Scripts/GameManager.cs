using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SerializableManager manager;
    [SerializeField] private Transform parentMoveButtons;
    [SerializeField] private GameObject pattern;

    private Dictionary<TypeMove, GameObject> TypePlatform;

    private void Awake()
    {
        TypePlatform = new Dictionary<TypeMove, GameObject>();
        SetupPlatforms();
    }

    private void SetupPlatforms()
    {
        foreach (var moveButton in manager.MoveButtons)
            TypePlatform.Add(moveButton.Type, moveButton.Prefab);

        for (int i = 0; i < parentMoveButtons.childCount; i++)
        {
            var moveButton = parentMoveButtons.GetChild(i).gameObject.GetComponent<MoveButton>();
            moveButton.Platform = TypePlatform[moveButton.Type];
        }
    }

    private void OnPattern(bool canMovePlatform)
    {
        pattern.SetActive(canMovePlatform);
    }
}
