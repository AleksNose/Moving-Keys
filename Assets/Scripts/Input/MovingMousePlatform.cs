using UnityEngine;
using UnityEngine.InputSystem;

public class MovingMousePlatform : MonoBehaviour
{
	private const float SPEED = 80f;
	[field: SerializeField] private Camera Camera;

	private InputActions InputAction;
	private GameObject dragObject;

	private bool isDrag { get; set; }

	public void Awake ()
	{
		InputAction = new InputActions();
		InputAction.Enable();
	}

	private void FixedUpdate ()
	{
		DragObject();

		if (dragObject != null)
		{
			MoveObject(dragObject);
		}
	}

	private void DragObject ()
	{
		RaycastHit2D hit2D = Physics2D.Raycast(Camera.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero);
		if (hit2D.collider != null && hit2D.collider.gameObject.tag == "Platform")
		{
			dragObject = hit2D.collider.gameObject;
			isDrag = true;
		}
	}

	private void MoveObject (GameObject gameObject)
	{
		if (isDrag && InputAction.Platform.Mouse.IsPressed())
		{
			Vector3 mousePos = Camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
			gameObject.transform.position = new Vector3((int) mousePos.x, (int)mousePos.y, 0f);
		}
		else
		{
			isDrag = false;
		}
		
		gameObject.GetComponent<BoxCollider2D>().isTrigger = isDrag;
		gameObject.GetComponent<Platform>().IsDrag = isDrag;
	}
}