﻿using System;
using UnityEngine;

namespace Platform
{
	[Serializable]
	[CreateAssetMenu(menuName = "MovePlatform/Platform/PlatformData")]
	public class PlatformData : ScriptableObject
	{
		[field: SerializeField]
		public MoveType Type { get; set; }

		[field: SerializeField] 
		public GameObject Platform { get; set; }

		private bool IsSpawn => SpawnedPlatform != null;
		private GameObject SpawnedPlatform { get; set; }

		public void SpawnOrDestroyPlatform ()
		{
			if (IsSpawn == false)
			{
				SpawnedPlatform = Instantiate(Platform);
			}
			else
			{
				Destroy(SpawnedPlatform);
				SpawnedPlatform = null;
			}
		}
	}
}