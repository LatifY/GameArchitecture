using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using GameArchitecture;
using TMPro;
using System.Text;
using System.Collections.Generic;

[Serializable]
public class MyEvent : UnityEvent { }

public class Writer : MonoBehaviour
{
	[Header("Writer Options")]
	[SerializeField] private string[] sentenceKeys;
	[SerializeField] private float waitBetweenLetters;
	[SerializeField] private float waitAtTheStart;
	[SerializeField] private bool writeOnActive = true;
	[SerializeField] private string soundName;
	[SerializeField] private bool playSound = true;
	[SerializeField] private bool playSoundEachLetter;
	[SerializeField] private float minPitch, maxPitch;

	[Header("Components")]
	[SerializeField] private TMP_Text writerText;
	private WobblyText wobblyText;
	private ShakeText shakeText;
	private JellyText jellyText;
	private GameObject resume;

	[Header("After Event")]
	public MyEvent AfterEvent;
	[SerializeField] private bool playEvent = true;

	private char[] stopperChars = { '.', ',', '?', '!' };

	private void Awake()
	{
		resume = transform.Find("Resume").gameObject;
		writerText.gameObject.TryGetComponent<WobblyText>(out wobblyText);
		writerText.gameObject.TryGetComponent<ShakeText>(out shakeText);
		writerText.gameObject.TryGetComponent<JellyText>(out jellyText);
	}

	private void OnEnable()
	{
		writerText.text = "";
		if (writeOnActive)
		{
			StartCoroutine(Write());
		}
	}


	public IEnumerator Write()
	{
		yield return new WaitForSeconds(waitAtTheStart);

		foreach (var key in sentenceKeys)
		{
			wobblyText.ResetIndexs();
			shakeText.ResetIndexs();
			jellyText.ResetIndexs();
			writerText.text = "";
			if (!playSoundEachLetter && playSound)
			{
				AudioManager.Instance.PlayClip(soundName);
			}
			string sentence = MultiLang.GetTranslation(key);
			List<string> tags = new List<string>();
			string tagName = "";
			bool tag = false;
			int wobblyStartIndex = 0;
			int shakeStartIndex = 0;
			int jellyStartIndex = 0;
			for (int i = 0; i < sentence.Length; i++)
			{
				char letter = sentence[i];
				if (playSoundEachLetter && playSound)
				{
					AudioManager.Instance.PlayClipWithRandomPitch(soundName, minPitch, maxPitch);
				}
				string letterStr = letter.ToString();
				if (tag)
				{
					tagName += letter;
					if (letter == '>')
					{
						tag = false;
						tags.Add(tagName);
						if (tagName.Contains("wobbly"))
						{
							int sumLen = 0;
							foreach (var item in tags)
							{
								sumLen += item.Length;
							}
							int lenOffset = i - sumLen + 1;
							if (!tagName.Contains("/"))
							{
								wobblyText.AddStartIndex(lenOffset);
								wobblyStartIndex = lenOffset;
							}
							else
							{
								wobblyText.AddEndIndex(wobblyStartIndex, lenOffset);
								wobblyStartIndex = 0;
							}
						}
						else if (tagName.Contains("shake"))
						{
							int sumLen = 0;
							foreach (var item in tags)
							{
								sumLen += item.Length;
							}
							int lenOffset = i - sumLen + 1;
							if (!tagName.Contains("/"))
							{
								shakeText.AddStartIndex(lenOffset);
								shakeStartIndex = lenOffset;
							}
							else
							{
								shakeText.AddEndIndex(shakeStartIndex, lenOffset);
								shakeStartIndex = 0;
							}
						}
						else if (tagName.Contains("jelly"))
						{
							int sumLen = 0;
							foreach (var item in tags)
							{
								sumLen += item.Length;
							}
							int lenOffset = i - sumLen + 1;
							if (!tagName.Contains("/"))
							{
								jellyText.AddStartIndex(lenOffset);
								jellyStartIndex = lenOffset;
							}
							else
							{
								jellyText.AddEndIndex(jellyStartIndex, lenOffset);
								jellyStartIndex = 0;
							}
						}
						else
						{
							writerText.text += tagName;
						}
						tagName = "";
					}
				}
				else
				{
					if (letter == '<')
					{
						tag = true;
						tagName += letter;
					}
					else
					{
						writerText.text += letter;
						if (letter.ToString().IndexOfAny(stopperChars) != -1)
						{
							yield return new WaitForSeconds(waitBetweenLetters * 3);
						}
						yield return new WaitForSeconds(waitBetweenLetters);
					}
				}
			}
			resume.SetActive(true);
			yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
			resume.SetActive(false);
		}
		resume.SetActive(true);
		yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
		resume.SetActive(false);
		if (playEvent)
		{
			AfterEvent.Invoke();
		}
	}
}