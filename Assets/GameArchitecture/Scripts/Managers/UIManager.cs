using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameArchitecture
{
	public class UIManager : MonoBehaviour
	{
		[SerializeField] private GameObject PausePanel;
		public void Pause()
		{
			print("lol");
			PausePanel.SetActive(true);
		}

		public void Resume()
		{
			print("lol2");
			PausePanel.SetActive(false);
		}
	}

}