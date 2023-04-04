using Gameplay.Platform;
using Gameplay.Platform.Data;
using UnityEngine;

namespace UI.Platform
{
	public class PlatformButtonController : MonoBehaviour
	{
		[field: SerializeField] 
		private MoveType Type { get; set; }

		private PlatformController PlatformController { get; set; }

		public void Initialize (PlatformController platformController)
		{
			PlatformController = platformController;
		}

		public void OnClick ()
		{
			PlatformController.Key = Type;
			PlatformController.PlatformDatabaseDict[Type].SpawnOrDestroyPlatform();
		}
	}
}