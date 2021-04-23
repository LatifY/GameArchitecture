using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ShakeText : MonoBehaviour
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

                    int vertexIndex = charInfo.vertexIndex;

                    Vector3 offset = Shake(Time.time + i);
                    vertices[vertexIndex] += offset;
                    vertices[vertexIndex + 1] += offset;
                    vertices[vertexIndex + 2] += offset;
                    vertices[vertexIndex + 3] += offset;
                }
            }
            mesh.vertices = vertices;
            tmpText.canvasRenderer.SetMesh(mesh);
        }
    }

    Vector2 Shake(float time)
    {
        return new Vector2(Mathf.Sin(time * 3.3f), Mathf.Cos(time * 2.5f));
    }
}