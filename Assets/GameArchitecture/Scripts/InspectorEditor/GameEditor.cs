using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum PlayerPrefsState
{
	Int,
	Float,
	String
}

public class GameEditor : MonoBehaviour
{
	//PlayerPrefs
	public PlayerPrefsState playerPrefsState;
	public string editKey, learnKey, deleteKey;
	public int intValue;
	public float floatValue;
	public string stringValue;

	//Language
	public List<string> LangsList;
	public string addLanguage, deleteLanguage;

	private void Awake()
	{
		LangsList = MultiLang.GetAllLanguages();
	}
}

#if UNITY_EDITOR
[CustomEditor(typeof(GameEditor))]
[CanEditMultipleObjects]
public class GameEditorGUI : Editor
{
	GameEditor gameEditor;
	private List<string> LangsList;

	private GUIStyle infoText = new GUIStyle();
	private GUIStyle headerText = new GUIStyle();


	private void OnEnable()
	{
		LangsList = MultiLang.GetAllLanguages();
		infoText.fontSize = 12;
		infoText.normal.textColor = new Color(0.8f, 0.8f, 0.8f);

		headerText.fontSize = 20;
		headerText.normal.textColor = new Color(0.8f,0.8f,0.8f);
		headerText.richText = true;
		headerText.alignment = TextAnchor.UpperCenter;
	}

	override public void OnInspectorGUI()
	{
		gameEditor = target as GameEditor;
		#region PlayerPrefs
		GUILayout.Label("PlayerPrefs", headerText);
		#region PlayerPrefs Edit
		EditorGUILayout.LabelField("PlayerPrefs Edit", EditorStyles.boldLabel);
		gameEditor.playerPrefsState = (PlayerPrefsState)EditorGUILayout.EnumPopup("Mode",gameEditor.playerPrefsState);
		gameEditor.editKey = EditorGUILayout.TextField("Key Name", gameEditor.editKey);
		GUILayout.BeginHorizontal();
		if (gameEditor.playerPrefsState == PlayerPrefsState.Int)
		{
			gameEditor.intValue = EditorGUILayout.IntField("Value", gameEditor.intValue);
			if (GUILayout.Button($"Set '{gameEditor.editKey}' Key"))
			{
				PlayerPrefs.SetInt(gameEditor.editKey, gameEditor.intValue);
				Debug.Log($"{gameEditor.editKey} is {(PlayerPrefs.GetInt(gameEditor.editKey)).ToString()} now");
			}
		}
		else if (gameEditor.playerPrefsState == PlayerPrefsState.String)
		{
			gameEditor.stringValue = EditorGUILayout.TextField("Value", gameEditor.stringValue);

			if (GUILayout.Button($"Set '{gameEditor.editKey}' Key"))
			{
				PlayerPrefs.SetString(gameEditor.editKey, gameEditor.stringValue);
				Debug.Log($"{gameEditor.editKey} is {(PlayerPrefs.GetString(gameEditor.editKey)).ToString()} now");
			}
		}
		else if (gameEditor.playerPrefsState == PlayerPrefsState.Float)
		{
			gameEditor.floatValue = EditorGUILayout.FloatField("Value", gameEditor.floatValue);

			if (GUILayout.Button($"Set '{gameEditor.editKey}' Key"))
			{
				PlayerPrefs.SetFloat(gameEditor.editKey, gameEditor.floatValue);
				Debug.Log($"{gameEditor.editKey} is {(PlayerPrefs.GetFloat(gameEditor.editKey)).ToString()} now");
			}
		}
		GUILayout.EndHorizontal();
		#endregion
		GUILayout.Space(15);
		#region PlayerPrefs Learn
		EditorGUILayout.LabelField("PlayerPrefs Learn", EditorStyles.boldLabel);
		GUILayout.BeginHorizontal();

		gameEditor.learnKey = EditorGUILayout.TextField("Key Name", gameEditor.learnKey);

		GUILayout.Space(10);
		if (gameEditor.playerPrefsState == PlayerPrefsState.Int)
		{
			if (GUILayout.Button($"Learn '{gameEditor.learnKey}' Key"))
			{
				Debug.Log($"'{gameEditor.learnKey}' Key's value is '{(PlayerPrefs.GetInt(gameEditor.learnKey))}'");
			}
		}
		else if (gameEditor.playerPrefsState == PlayerPrefsState.String)
		{
			if (GUILayout.Button($"Learn '{gameEditor.learnKey}' Key"))
			{
				Debug.Log($"'{gameEditor.learnKey}' Key's value is '{(PlayerPrefs.GetString(gameEditor.learnKey))}'");
			}
		}
		else if (gameEditor.playerPrefsState == PlayerPrefsState.Float)
		{
			if (GUILayout.Button($"Learn '{gameEditor.learnKey}' Key"))
			{
				Debug.Log($"'{gameEditor.learnKey}' Key's value is '{(PlayerPrefs.GetFloat(gameEditor.learnKey))}'");
			}
		}
		GUILayout.EndHorizontal();
		#endregion
		GUILayout.Space(15);
		#region PlayerPrefs Delete
		EditorGUILayout.LabelField("PlayerPrefs Delete", EditorStyles.boldLabel);
		GUILayout.BeginHorizontal();
		gameEditor.deleteKey = EditorGUILayout.TextField("Key Name", gameEditor.deleteKey);

		if (GUILayout.Button("Delete Key"))
		{
			Debug.Log($"{gameEditor.deleteKey} Key Deleted");
			PlayerPrefs.DeleteKey(gameEditor.deleteKey);
		}
		GUILayout.EndHorizontal();

		GUILayout.Space(15);

		if (GUILayout.Button("Delete All Keys"))
		{
			Debug.Log("All Keys Deleted");
			PlayerPrefs.DeleteAll();
		}
		EditorGUILayout.HelpBox("Please be careful when pressing this button. It is an irreversible action.", MessageType.Warning);
		#endregion
		#endregion
		GUILayout.Space(20);
		#region Language
		GUILayout.Label("Language", headerText);
		#region Language Change
		GUILayout.Space(5);
		GUILayout.Label("Language Change", EditorStyles.boldLabel);
		CreateButtons();
		GUILayout.Label("Current Language: "+ PlayerPrefs.GetString("language").ToUpper(), infoText);
		#endregion
		GUILayout.Space(15);
		#region Language Add
		GUILayout.Label("Language Add", EditorStyles.boldLabel);
		GUILayout.BeginHorizontal();
		gameEditor.addLanguage = EditorGUILayout.TextField("Language Add", gameEditor.addLanguage);
		if (GUILayout.Button("Add"))
		{
			MultiLang.AddLanguage(gameEditor.addLanguage);
		}
		GUILayout.EndHorizontal();
		#endregion
		GUILayout.Space(15);
		#region Language Delete
		GUILayout.Label("Language Delete", EditorStyles.boldLabel);
		GUILayout.BeginHorizontal();
		gameEditor.deleteLanguage = EditorGUILayout.TextField("Language Delete", gameEditor.deleteLanguage);
		if (GUILayout.Button("Delete"))
		{
			MultiLang.DeleteLanguage(gameEditor.deleteLanguage);
		}
		GUILayout.EndHorizontal();
		#endregion
		#endregion
		serializedObject.ApplyModifiedProperties();
	}

	private void CreateButtons()
	{
		GUILayout.BeginHorizontal();
		for (int i = 0; i < LangsList.Count; i++)
		{
			string lang = LangsList[i];
			if (GUILayout.Button(lang.ToUpper()))
			{
				MultiLang.ChangeLanguage(lang);
			}
		}
		GUILayout.EndHorizontal();
	}
}
#endif