using Gameplay.Platform.Data;
using UnityEngine;

namespace Gameplay
{
	public class GameManager : MonoBehaviour 
	{
		[field: SerializeField] 
		private PlatformDatabase PlatformDatabase { get; set; }
		
		private PlatformController PlatformController { get; set; }

		private void Awake ()
		{
			Initialize();
		}
		
		private void Initialize ()
		{
			PlatformController = new();
			PlatformController.SetupPlatformData(PlatformDatabase);
		}
	}
}