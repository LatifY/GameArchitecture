using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ChildEditor : MonoBehaviour
{
	public List<GameObject> childs;
	public string ScriptName;
}

#if UNITY_EDITOR
[CustomEditor(typeof(ChildEditor))]
[CanEditMultipleObjects]
public class ChildEditorGUI : Editor
{
	ChildEditor myScript;



	override public void OnInspectorGUI()
	{
		myScript = target as ChildEditor;

		#region Set Active
		EditorGUILayout.LabelField("Set Active", EditorStyles.boldLabel);
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Enable"))
		{
			DefineChilds();
			foreach (var obj in myScript.childs)
			{
				obj.SetActive(true);
			}
		}
		if (GUILayout.Button("Disable"))
		{
			DefineChilds();
			foreach (var obj in myScript.childs)
			{
				obj.SetActive(false);
			}
		}
		GUILayout.EndHorizontal();
		#endregion

		GUILayout.Space(20);

		#region Script Enable/Disable
		myScript.ScriptName = EditorGUILayout.TextField("Script Name", myScript.ScriptName);
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Enable"))
		{
			DefineChilds();
			string scriptName = myScript.ScriptName;
			foreach (var obj in myScript.childs)
			{
				var comp = obj.GetComponent(scriptName);
				Behaviour be = comp as Behaviour;
				if (be != null)
				{
					be.enabled = true;
				}
				else
				{
					Renderer rend = comp as Renderer;
					if (rend != null)
						rend.enabled = true;
				}
			}
		}
		if (GUILayout.Button("Disable"))
		{
			DefineChilds();
			string scriptName = myScript.ScriptName;
			foreach (var obj in myScript.childs)
			{
				var comp = obj.GetComponent(scriptName);
				Behaviour be = comp as Behaviour;
				if (be != null)
				{
					be.enabled = false;
				}
				else
				{
					Renderer rend = comp as Renderer;
					if (rend != null)
						rend.enabled = false;
				}
			}
		}
		GUILayout.EndHorizontal();
		#endregion
		serializedObject.ApplyModifiedProperties();
	}

	private void DefineChilds()
	{
		myScript.childs.Clear();
		for (int i = 0; i < myScript.transform.childCount; i++)
		{
			myScript.childs.Add(myScript.gameObject.transform.GetChild(i).gameObject);
		}
	}


}
#endif