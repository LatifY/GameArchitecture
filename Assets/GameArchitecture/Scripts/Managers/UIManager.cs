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
			PausePanel.SetActive(true);
			GameManager.Instance.GameStateChanger(2);
		}

		public void Resume()
		{
			PausePanel.SetActive(false);
			GameManager.Instance.GameStateChanger(1);

		}
	}

}