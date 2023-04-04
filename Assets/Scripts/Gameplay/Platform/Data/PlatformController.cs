using System.Collections.Generic;

namespace Gameplay.Platform.Data
{
	public class PlatformController
	{
		public MoveType Key { get; set; }
		public PlatformData CurrentPlatformData => PlatformDatabaseDict[Key];
		public Dictionary<MoveType, PlatformData> PlatformDatabaseDict { get; set; }
		
		public void SetupPlatformData (PlatformDatabase PlatformDatabase)
		{
			PlatformDatabaseDict = new();
			
			AddPlatformDataToDict(PlatformDatabase.RightPlatformData);
			AddPlatformDataToDict(PlatformDatabase.SpacePlatformData);
			AddPlatformDataToDict(PlatformDatabase.LeftPlatformData);
		}

		private void AddPlatformDataToDict (PlatformData data)
		{
			PlatformDatabaseDict.Add(data.Type, data);
		}
	}
}