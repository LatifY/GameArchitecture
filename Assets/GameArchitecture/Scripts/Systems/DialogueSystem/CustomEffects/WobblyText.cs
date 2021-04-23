using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;

public class WobblyText : MonoBehaviour
{
	private TMP_Text tmpText;
	public List<string> indexs = new List<string>();

	private Mesh mesh;
	private Vector3[] vertices;

	private void Start()
	{
		tmpText = GetComponent<TMP_Text>();
	}

	public void AddStartIndex(int start)
	{
		indexs.Add(start.ToString() + ":");
	}

	public void AddEndIndex(int start, int end)
	{
		int index = Array.FindIndex(indexs.ToArray(), x => x.Contains(start.ToString()));
		indexs[index] += end.ToString();
	}

	public void ResetIndexs()
	{
		indexs.Clear();
	}


	private void LateUpdate()
	{
		tmpText.ForceMeshUpdate();

		if (indexs.Count > 0)
		{
			mesh = tmpText.mesh;
			vertices = mesh.vertices;
			foreach (var index in indexs)
			{
				string[] subs = index.Split(":".ToCharArray());
				int startIndex, endIndex;
				int.TryParse(subs[0], out startIndex);
				int.TryParse(subs[1], out endIndex);

				var textInfo = tmpText.textInfo;

				if (endIndex == 0)
				{
					endIndex = textInfo.characterCount;
				}
				else if (endIndex > textInfo.characterCount)
				{
					endIndex = textInfo.characterCount;
				}

				for (int i = startIndex; i < endIndex; i++)
				{
					var charInfo = textInfo.characterInfo[i];

					if (!charInfo.isVisible)
					{
						continue;
					}


					for (int j = 0; j < 4; j++)
					{
						var orig = vertices[charInfo.vertexIndex + j];
						vertices[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * 3f + orig.x * 0.01f) * 4f, 0);
					}
				}
				mesh.vertices = vertices;
				tmpText.canvasRenderer.SetMesh(mesh);
			}	
		}
	}

}