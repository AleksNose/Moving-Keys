using System;
using Gameplay.Platform;
using Gameplay.Platform.Data;
using UnityEngine.InputSystem;

namespace Gameplay.Player
{
	public class PlayerMovementToggle
	{
		public event Action<MoveType, float> OnMoveChange = delegate { };
		private InputActions InputActions { get; set; }
		private PlatformController PlatformController { get; set; }

		public void Initialize ()
		{
			InputActions = new();
			InputActions.Enable();
			AttachEvents();
		}

		private void AttachEvents ()
		{
			InputActions.Movement.Left.performed += MoveLeft;
			InputActions.Movement.Right.performed += MoveRight;
			InputActions.Movement.Up.performed += MoveSpace;
		}

		private void MoveLeft(InputAction.CallbackContext inputAction) => CheckCanMove(MoveType.Left);
		private void MoveRight(InputAction.CallbackContext inputAction) => CheckCanMove(MoveType.Right);
		private void MoveSpace(InputAction.CallbackContext inputAction) => CheckCanMove(MoveType.Space);

		private void CheckCanMove (MoveType type)
		{
			float resultat = PlatformController.PlatformDatabaseDict[type].IsSpawn == false ? 1f : 0f;
			OnMoveChange(type, resultat);
		}

		private void DetachEvents ()
		{
			InputActions.Movement.Left.performed -= MoveLeft;
			InputActions.Movement.Right.performed -= MoveRight;
			InputActions.Movement.Up.performed -= MoveSpace;
		}

		public void Deintialize ()
		{
			DetachEvents();
			InputActions.Disable();
		}
	}
}
