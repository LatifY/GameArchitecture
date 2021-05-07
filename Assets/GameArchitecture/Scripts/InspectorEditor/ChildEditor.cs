using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ChildEditor : MonoBehaviour
{
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
			Utils.SetActiveInChildren(myScript.gameObject, true);

		}
		if (GUILayout.Button("Disable"))
		{
			Utils.SetActiveInChildren(myScript.gameObject, false);
		}
		GUILayout.EndHorizontal();
		#endregion

		GUILayout.Space(20);

		#region Script Enable/Disable
		myScript.ScriptName = EditorGUILayout.TextField("Script Name", myScript.ScriptName);
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Enable"))
		{
			Utils.ScriptActiveInChildren(myScript.gameObject, myScript.ScriptName, true);
		}
		if (GUILayout.Button("Disable"))
		{
			Utils.ScriptActiveInChildren(myScript.gameObject, myScript.ScriptName, false);
		}
		GUILayout.EndHorizontal();
		#endregion
		serializedObject.ApplyModifiedProperties();
	}
}
#endif