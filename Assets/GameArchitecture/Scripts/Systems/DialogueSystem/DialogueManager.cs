using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameArchitecture;

public class DialogueManager : MonoBehaviour
{
    private List<GameObject> Boxes = new List<GameObject>();
	private int index;

	private void Start()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			Boxes.Add(transform.GetChild(i).gameObject);
		}
		Dialogue();
	}

	private void Update()
	{
		/*
		if (Input.GetKeyDown(KeyCode.Space) && index < Boxes.Count-1)
		{
			Next();
		}
		*/
	}

	private void Dialogue()
	{
		Truncate();
		Boxes[index].SetActive(true);
	}

	private void Truncate()
	{
		foreach (var box in Boxes)
		{
			box.SetActive(false);
		}
	}

	#region Next
	public void Next()
	{
		StartCoroutine(NextEnum());
	}

	private IEnumerator NextEnum()
	{
		Animator boxAnim = Boxes[index].GetComponent<Animator>();
		boxAnim.SetTrigger("end");
		yield return new WaitForSeconds(boxAnim.GetCurrentAnimatorStateInfo(0).length);
		index++;
		Dialogue();
	}
	#endregion
	#region Finish
	public void Finish()
	{
		StartCoroutine(FinishEnum());
		
	}

	private IEnumerator FinishEnum()
	{
		Animator boxAnim = Boxes[index].GetComponent<Animator>();
		boxAnim.SetTrigger("end");
		yield return new WaitForSeconds(boxAnim.GetCurrentAnimatorStateInfo(0).length);
		Truncate();
		gameObject.SetActive(false);
	}
	#endregion
}
