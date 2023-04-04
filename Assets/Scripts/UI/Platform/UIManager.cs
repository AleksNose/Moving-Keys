using System.Collections.Generic;
using UnityEngine;

namespace UI.Platform
{
	public class UIManager : MonoBehaviour
	{
		[field: SerializeField] 
		public List<PlatformButtonController> PlatformButtonControllers { get; set; }
	}
}