using UnityEngine;
using UnityEngine.InputSystem;

public class MovingMousePlatform : MonoBehaviour
{
	private const float SPEED = 5f;
	[field: SerializeField] 
	private Camera Camera;
	
	private InputActions InputAction;

	public void Awake ()
	{
		InputAction = new InputActions();
		InputAction.Enable();
	}

	private void FixedUpdate ()
	{
		RaycastHit2D hit2D = Physics2D.Raycast(Camera.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero);
		GameObject gameObject = hit2D.collider.gameObject;

		gameObject.TryGetComponent<Rigidbody2D>(out var rigid);

		while (InputAction.Platform.Mouse.IsPressed())
		{
			Vector3 mousePos = Camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
			mousePos.z = 0f;

			Vector3.MoveTowards(gameObject.transform.position, mousePos, 1f);
			Vector2 direction = (Vector2)(mousePos - gameObject.transform.position);
			direction.Normalize();
			rigid.velocity = direction * SPEED;
		}
	}
}