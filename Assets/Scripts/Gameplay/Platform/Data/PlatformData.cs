using System;
using UnityEngine;

namespace Gameplay.Platform.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "MovePlatform/Platform/PlatformData")]
	public class PlatformData : ScriptableObject
	{
		[field: SerializeField]
		public MoveType Type { get; set; }

		[field: SerializeField] 
		public GameObject Platform { get; set; }

		public bool IsSpawn { get; set; }
		private GameObject SpawnedPlatform { get; set; }

		public void SpawnOrDestroyPlatform ()
		{
			if (IsSpawn == false)
			{
				SpawnedPlatform = Instantiate(Platform);
				IsSpawn = true;
			}
			else
			{
				Destroy(SpawnedPlatform);
				SpawnedPlatform = null;
				IsSpawn = false;
			}
		}
	}
}