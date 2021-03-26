using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GameArchitecture
{
	public class GameManager : MonoBehaviour
	{
		public enum GameState {
			DEFAULT,
			INGAME,
			PAUSED
		}
		private GameState _state;
		public GameState state {
			get 
			{ 
				return _state; 
			}
			set 
			{
				_state = value;
				ChangeState();
			}
		}

		public Text pausedText, timescaleText;
		[SerializeField] private bool DontDestroy;
		public static GameManager Instance;

		private bool paused;

		private void Awake()
		{
			if (DontDestroy)
			{
				if (Instance != null)
				{
					Destroy(gameObject);
				}
				else
				{
					Instance = this;
					DontDestroyOnLoad(transform.gameObject);
				}
			}
			ChangeState();
		}

		private void ChangeState()
		{
			switch (_state)
			{
				case GameState.DEFAULT:
					break;
				case GameState.INGAME:
					paused = false;
					Time.timeScale = 1f;
					break;
				case GameState.PAUSED:
					paused = true;
					Time.timeScale = 0f;
					break;
				default:
					Debug.Log("ERROR: Unknown game state: " + state);
					break;
			}
			Debug.Log("GAMESTATE: Game state is: " + state); 
		}

		public void StateChanger(int changeToIndex)
		{
			state = (GameState)changeToIndex;
		}

		public void LoadScene(int index)
		{
			Time.timeScale = 1f;
			SceneManager.LoadScene(index);
		}

		public void Printer(string something)
		{
			print(something);
		}
	}
}

