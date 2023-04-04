using System.Collections.Generic;
using Gameplay.Platform;
using Gameplay.Player;
using UnityEngine;

namespace Player
{
	public class PlayerMovement : MonoBehaviour
	{
		private const float SPEED = 5f;

		[field: SerializeField]
		private Rigidbody2D Rigidbody2D { get; set; }
		
		private PlayerMovementToggle PlayerMovementToggle { get; set; }

		private Dictionary<MoveType, float> OperationMove = new();

		public void Initialize (PlayerMovementToggle playerMovementToggle)
		{
			PlayerMovementToggle = playerMovementToggle;
			PlayerMovementToggle.OnMoveChange += CheckCanMove;
			
			OperationMove.Add(MoveType.Left, 0f);
			OperationMove.Add(MoveType.Right, 0f);
			OperationMove.Add(MoveType.Space, 0f);
		}

		private void FixedUpdate ()
		{
			Move();
			Jump();
		}

		private void Move ()
		{
			var right = OperationMove[MoveType.Right] * (PlayerMovementToggle.InputActions.Movement.Right.IsPressed() ? 1f : 0f);
			var left = -1 * OperationMove[MoveType.Left] * (PlayerMovementToggle.InputActions.Movement.Left.IsPressed() ? 1f : 0f);
			
			Rigidbody2D.velocity = new Vector2(( right + left) * SPEED, Rigidbody2D.velocity.y);
		}

		private void Jump ()
		{
			
		}

		private void CheckCanMove (MoveType type, float enable)
		{
			OperationMove[type] = enable;
		}

		private void OnDestroy ()
		{
			PlayerMovementToggle.Deintialize();
			PlayerMovementToggle.OnMoveChange -= CheckCanMove;
		}
	}
}