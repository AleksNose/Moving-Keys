using Gameplay.Platform.Data;
using Gameplay.Player;
using Player;
using UI.Platform;
using UnityEngine;

namespace Gameplay
{
	public class GameManager : MonoBehaviour 
	{
		[field: SerializeField] 
		private PlatformDatabase PlatformDatabase { get; set; }

		[field: SerializeField] 
		private PlayerMovement PlayerMovement { get; set; }

		[field: SerializeField] 
		private UIManager UIManager { get; set; }

		private PlayerMovementToggle PlayerMovementToggle { get; set; }
		private PlatformController PlatformController { get; set; }

		private void Awake ()
		{
			Initialize();
		}
		
		private void Initialize ()
		{
			PlatformController = new();
			PlayerMovementToggle = new();
			PlatformController.SetupPlatformData(PlatformDatabase);
			PlayerMovementToggle.Initialize(PlatformController);
			PlayerMovement.Initialize(PlayerMovementToggle);

			foreach (var button in UIManager.PlatformButtonControllers)
			{
				button.Initialize(PlatformController);
			}
		}
	}
}