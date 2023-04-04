using UnityEngine;

namespace Gameplay.Platform.Data
{
	[CreateAssetMenu(menuName = "MovePlatform/Platform/PlatformDatabase")]
	public class PlatformDatabase : ScriptableObject
	{
		[field: SerializeField]
		public PlatformData LeftPlatformData { get; set; }
		
		[field: SerializeField] 
		public PlatformData SpacePlatformData { get; set; }
		
		[field: SerializeField] 
		public PlatformData RightPlatformData { get; set; }
	}
}