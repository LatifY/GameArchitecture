using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GameArchitecture
{
	public class GameManager : MonoBehaviour
	{
		#region Game State
		public enum GameState
		{
			DEFAULT,
			INGAME,
			PAUSED
		}
		private GameState _gameState;
		public GameState gameState
		{
			get
			{
				return _gameState;
			}
			set
			{
				_gameState = value;
				ChangeGameState();
			}
		}
		#endregion

		public Text pausedText;
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
			else
			{
				Instance = this;
			}

			ChangeGameState();
		}

		#region Game State
		private void ChangeGameState()
		{
			switch (_gameState)
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
					Debug.Log("ERROR: Unknown game state: " + gameState);
					break;
			}
			Debug.Log("GAMESTATE: Game state is: " + gameState);
		}
		public void GameStateChanger(int changeToIndex)
		{
			gameState = (GameState)changeToIndex;
		}
		#endregion

		#region Load Scene
		/// <summary>
		/// Pass -1 to index for loading active scene
		/// </summary>
		public void LoadScene(int index)
		{
			if (index == -1)
			{
				index = SceneManager.GetActiveScene().buildIndex;
			}
			GameObject[] transitionPanels = GameObject.FindGameObjectsWithTag("Transition");
			Time.timeScale = 1f;
			if (transitionPanels == null)
			{
				SceneManager.LoadScene(index);
			}
			else
			{
				StartCoroutine(LoadSceneEnum(index, transitionPanels[0].GetComponent<Animator>()));
			}
		}

		private IEnumerator LoadSceneEnum(int index, Animator anim)
		{
			anim.SetTrigger("end");
			yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
			SceneManager.LoadScene(index);
		}
		#endregion
	}

}

