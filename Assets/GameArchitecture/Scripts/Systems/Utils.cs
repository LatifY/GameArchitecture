using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
	public static void SetActiveList(List<GameObject> list, bool setBool = false)
	{
		foreach (var item in list)
		{
			item.SetActive(setBool);
		}
	}

	public static void SetActiveArray(GameObject[] list, bool setBool = false)
	{
		foreach (var item in list)
		{
			item.SetActive(setBool);
		}
	}

	public static void SetActiveInChildren(GameObject parent, bool setBool = false)
	{
		for (int i = 0; i < parent.transform.childCount; i++)
		{
			parent.transform.GetChild(i).gameObject.SetActive(setBool);

		}
	}

	public static void ScriptActiveInChildren(GameObject parent, string scriptName, bool setBool = false)
	{
		for(int i = 0; i < parent.transform.childCount; i++)
		{
			GameObject obj = parent.transform.GetChild(i).gameObject;
			var comp = obj.GetComponent(scriptName);
			Behaviour be = comp as Behaviour;
			if (be != null)
			{
				be.enabled = setBool;
			}
			else
			{
				Renderer rend = comp as Renderer;
				if (rend != null)
					rend.enabled = setBool;
			}
		}
	}




}
