using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MultiLang : MonoBehaviour
{
	public static MultiLang instance;
	public static Dictionary<String, String> Fields;
	[SerializeField] private string defaultLang;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}

		LoadLanguage();
	}

	private void LoadLanguage()
	{
		if (Fields == null)
		{
			Fields = new Dictionary<string, string>();
		}

		//Truncate
		Fields.Clear();

		string lang = PlayerPrefs.GetString("language", defaultLang);

		if (PlayerPrefs.GetInt("language_index", -1) == -1)
			PlayerPrefs.SetInt("language_index", 0);

		string allTexts = (Resources.Load(@"Languages/" + lang) as TextAsset).text; //without (.txt)
		/*

		*/
		string[] lines = allTexts.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
		string key, value;

		for (int i = 0; i < lines.Length; i++)
		{
			if (lines[i].IndexOf("=") >= 0 && !lines[i].StartsWith("#"))
			{
				key = lines[i].Substring(0, lines[i].IndexOf("="));
				value = lines[i].Substring(lines[i].IndexOf("=") + 1,
					lines[i].Length - lines[i].IndexOf("=") - 1).Replace("\\n", Environment.NewLine);
				Fields.Add(key, value);
			}
		}
	}

	public static void AddLanguage(string value)
	{
		string fileName = @"Assets/Resources/Languages/"+value+".txt";
		if (File.Exists(fileName))
		{
			Debug.LogError("Language already exists!");
			return;
		}
		try
		{
			File.CreateText(fileName);
			Debug.Log($"'{value.ToUpper()}' Language has been successfully added.");
		}
		catch (Exception e)
		{
			Debug.LogError(e.ToString());
		}

	}

	public static void DeleteLanguage(string value)
	{
		string fileName = @"Assets/Resources/Languages/" + value + ".txt";
		if (!File.Exists(fileName))
		{
			Debug.LogError("No language found in this name!");
			return;
		}
		try
		{
			File.Delete(fileName);
			Debug.Log($"'{value.ToUpper()}' Language has been successfully deleted.");
		}
		catch (Exception e)
		{
			Debug.LogError(e.ToString());
		}

	}

	public static void ChangeLanguage(string value)
	{
		PlayerPrefs.SetString("language", value);
		Debug.Log("Language changed to " + PlayerPrefs.GetString("language").ToUpper());
	}

	public static List<string> GetAllLanguages()
	{
		DirectoryInfo directory = new DirectoryInfo(@"Assets/Resources/Languages"); ;
		FileInfo[] Files = directory.GetFiles("*.txt");

		List<string> langs = new List<string>();
		foreach (var item in Files)
		{
			string name = item.Name;
			name = name.Remove(name.Length - 4);
			langs.Add(name);
		}
		return langs;
	}

	public static string GetTranslation(string key)
	{

		if (!Fields.ContainsKey(key))
		{
			Debug.LogError("There is no key with name: [" + key + "] in your text files");
			return null;
		}

		return Fields[key];
	}
}
