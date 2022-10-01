using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DefaultButton: MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    private Button button;

    public virtual void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    public virtual void OnClick()
    {}

    public virtual void OnPointerEnter(PointerEventData eventData)
    {}

    public virtual void OnPointerExit(PointerEventData eventData)
    {}
}