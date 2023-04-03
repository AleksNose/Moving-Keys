using System.Collections.Generic;
using UnityEngine;

namespace Platform.Data
{
	public class PlatformController : MonoBehaviour
	{
		public MoveType Key { get; set; }
		public PlatformData CurrentPlatformData => platformDatabase[Key];
		
		[field: SerializeField] 
		private PlatformDatabase PlatformDatabase { get; set; }

		private Dictionary<MoveType, PlatformData> platformDatabase;

		private void Awake ()
		{
			SetupPlatformDataToDict();
		}

		private void SetupPlatformDataToDict ()
		{
			platformDatabase = new();
			
			AddPlatformDataToDict(PlatformDatabase.RightPlatformData);
			AddPlatformDataToDict(PlatformDatabase.SpacePlatformData);
			AddPlatformDataToDict(PlatformDatabase.LeftPlatformData);
		}

		private void AddPlatformDataToDict (PlatformData data)
		{
			platformDatabase.Add(data.Type, data);
		}
	}
}