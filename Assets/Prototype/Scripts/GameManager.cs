using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SerializableManager manager;
    [SerializeField] private Transform parentMoveButtons;
    [SerializeField] private Cursor cursor;

    private Dictionary<TypeMove, GameObject> typePlatform;
    private InputManager input;

    private void Awake()
    {
        typePlatform = new Dictionary<TypeMove, GameObject>();
        SetupPlatforms();
        
        input = new InputManager();
       // input.OnMouseDown += cursor.CatchPlatform;
        input.OnMouseUp += cursor.UncatchPlatform;
    }

    private void Update()
    {
        cursor.Mouse = input.MousePosition;
    }

    private void SetupPlatforms()
    {
        foreach (var moveButton in manager.MoveButtons)
            typePlatform.Add(moveButton.Type, moveButton.Prefab);

        for (int i = 0; i < parentMoveButtons.childCount; i++)
        {
            var moveButton = parentMoveButtons.GetChild(i).gameObject.GetComponent<MoveButton>();
            moveButton.Platform = typePlatform[moveButton.Type];
        }
    }
}
