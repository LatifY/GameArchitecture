using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

#region States
public enum CameraState
{
	AlwaysTarget,
	AlwaysTargetWithLimit,
	Interactive_Beta
}

public enum TrackState
{
	XY,
	X,
	Y
}
#endregion

public class CameraManager : MonoBehaviour
{
	public CameraState cameraState;
	public TrackState trackState;
	private Camera cam;

	public Transform cameraTarget;
	public float smoothness = 1f;

	//Always Target With Limit
	public float minX,minY,maxX,maxY;

	//Interactive
	public float minSize, maxSize;

	private void Awake()
	{
		cam = GetComponent<Camera>();
	}

	private void Update()
	{
		if (!IsSimilar(transform.position.x, cameraTarget.transform.position.x) && !IsSimilar(transform.position.y, cameraTarget.transform.position.y))
		{
			if (cameraState == CameraState.AlwaysTarget)
			{
				Vector3 cameraPos = GetPos();
				transform.position = Vector3.Lerp(transform.position, cameraPos, smoothness);
			}
			else if (cameraState == CameraState.AlwaysTargetWithLimit)
			{
				Vector3 cameraPos = GetPosWithLimit();
				transform.position = Vector3.Lerp(transform.position, cameraPos, smoothness);
			}
			else if (cameraState == CameraState.Interactive_Beta)
			{
				Vector3 cameraPos = GetPosWithLimit();
				transform.position = Vector3.Lerp(transform.position, cameraPos, smoothness);
				StartCoroutine(ChangeCameraSize(maxSize));
			}
		}
		else
		{
			if (cameraState == CameraState.Interactive_Beta)
			{
				StartCoroutine(ChangeCameraSize(minSize));
			}
		}
	}

	private IEnumerator ChangeCameraSize(float value)
	{
		if (!IsSimilar(cam.orthographicSize, value))
		{
			if (cam.orthographicSize < value)
			{
				cam.orthographicSize += Time.deltaTime * 0.5f;
			}
			else if (cam.orthographicSize > value)
			{
				cam.orthographicSize -= Time.deltaTime * 0.5f;
			}
		}
		else
		{
			yield break;
		}
		yield return new WaitForSeconds(0.01f);
		StartCoroutine(ChangeCameraSize(value));
	}

	private bool IsSimilar(float x, float y)
	{
		if (x >= y-0.05f && x <= y+0.05f)
		{
			return true;
		}
		return false;
	}

	private Vector3 GetPos()
	{
		Vector3 cameraPos = new Vector3(0, 0, 0);
		if (trackState == TrackState.XY)
		{
			cameraPos = new Vector3(cameraTarget.position.x, cameraTarget.position.y, -10);
		}
		else if (trackState == TrackState.X)
		{
			cameraPos = new Vector3(cameraTarget.position.x, transform.position.y, -10);
		}
		else if (trackState == TrackState.Y)
		{
			cameraPos = new Vector3(transform.position.x, cameraTarget.position.y, -10);
		}
		return cameraPos;
	}

	private Vector3 GetPosWithLimit()
	{
		Vector3 cameraPos = new Vector3(0, 0, 0);
		if (trackState == TrackState.XY)
		{
			cameraPos = new Vector3(cameraTarget.position.x, cameraTarget.position.y, -10);
			cameraPos.x = Mathf.Clamp(cameraTarget.position.x, minX, maxX);
			cameraPos.y = Mathf.Clamp(cameraTarget.position.y, minY, maxY);
		}
		else if (trackState == TrackState.X)
		{
			cameraPos = new Vector3(cameraTarget.position.x, transform.position.y, -10);
			cameraPos.x = Mathf.Clamp(cameraTarget.position.x, minX, maxX);
		}
		else if (trackState == TrackState.Y)
		{
			cameraPos = new Vector3(transform.position.x, cameraTarget.position.y, -10);
			cameraPos.y = Mathf.Clamp(cameraTarget.position.y, minY, maxY);
		}
		return cameraPos;
	}

}

#if UNITY_EDITOR
[CustomEditor(typeof(CameraManager))]
[CanEditMultipleObjects]
public class CameraManagerEditor : Editor
{

	SerializedProperty cameraTarget;

	private void OnEnable()
	{
		cameraTarget = serializedObject.FindProperty("cameraTarget");
	}

	CameraManager myScript;

	override public void OnInspectorGUI()
	{
	    myScript = target as CameraManager;
		EditorGUILayout.ObjectField(cameraTarget);
		myScript.smoothness = EditorGUILayout.FloatField("Camera Smoothness",myScript.smoothness);
		EditorGUILayout.HelpBox("Camera Smoothness gives us smooth camera tracking. Default value is 1", MessageType.Info);
		GUILayout.Space(20);
		myScript.cameraState = (CameraState)EditorGUILayout.EnumPopup("Camera Type",myScript.cameraState);
		myScript.trackState = (TrackState)EditorGUILayout.EnumPopup("Camera Tracking Coordinates", myScript.trackState);
		GUILayout.Space(30);
		if (myScript.cameraState == CameraState.AlwaysTargetWithLimit || myScript.cameraState == CameraState.Interactive_Beta)
		{
			EditorGUILayout.LabelField("Camera Pos Limit", EditorStyles.boldLabel);
			if (myScript.trackState == TrackState.XY)
			{
				OpenPosLimitX();
				GUILayout.Space(5);
				OpenPosLimitY();
			}
			else if (myScript.trackState == TrackState.X)
			{
				OpenPosLimitX();
			}
			else if (myScript.trackState == TrackState.Y)
			{
				OpenPosLimitY();
			}
			GUILayout.Space(10);
		}
		if (myScript.cameraState == CameraState.Interactive_Beta)
		{
			EditorGUILayout.LabelField("Camera Size Limit", EditorStyles.boldLabel);
			OpenSizeLimit();
			GUILayout.Space(10);
		}
		serializedObject.ApplyModifiedProperties();
	}

	#region Open PosLimit
	private void OpenPosLimitX()
	{
		myScript.minX = EditorGUILayout.FloatField("Minimum X", myScript.minX);
		myScript.maxX = EditorGUILayout.FloatField("Maximum X", myScript.maxX);
	}
	private void OpenPosLimitY()
	{
		myScript.minY = EditorGUILayout.FloatField("Minimum Y", myScript.minY);
		myScript.maxY = EditorGUILayout.FloatField("Maximum Y", myScript.maxY);
	}
	#endregion

	private void OpenSizeLimit()
	{
		myScript.minSize = EditorGUILayout.FloatField("Minimum X", myScript.minSize);
		myScript.maxSize = EditorGUILayout.FloatField("Maximum X", myScript.maxSize);
	}
}
#endif