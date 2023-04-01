using Platform;
using UnityEngine;

namespace UI.Platform
{
	public class PlatformButtonController : MonoBehaviour
	{
		[field: SerializeField] 
		private MoveType Type;
		
		[field: SerializeField]
		private PlatformController PlatformController { get; set; }

		public void OnClick ()
		{
			PlatformController.Key = Type;
			PlatformController.CurrentPlatformData.SpawnOrDestroyPlatform();
		}
	}
}