using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using GameArchitecture;

[Serializable]
public class MyEvent : UnityEvent { }

public class Writer : MonoBehaviour
{
	[Header("Writer Options")]
	[SerializeField] private string[] sentenceKeys;
	[SerializeField] private float waitBetweenLetters;
	[SerializeField] private float waitBetweenSentences;
	[SerializeField] private float waitAtTheStart;
	[SerializeField] private bool writeOnActive = true;
	[SerializeField] private int soundIndex;
	[SerializeField] private bool playSoundEachLetter;
	[SerializeField] private float minPitch, maxPitch;
	[SerializeField] private bool clearAtTheEnd = true;

	[Header("Components")]
	[SerializeField] private Text writerText;

	[Header("After Event")]
	public MyEvent AfterEvent;
	[SerializeField] private bool playEvent = true;

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
			writerText.text = "";
			if (!playSoundEachLetter)
			{
				AudioManager.Instance.PlayClip(soundIndex);
			}
			string sentence = MultiLang.GetTranslation(key);
			foreach (var letter in sentence)
			{
				if (playSoundEachLetter)
				{
					AudioManager.Instance.PlayClipWithRandomPitch(soundIndex, minPitch, maxPitch);
				}
				writerText.text += letter;
				if (letter.ToString() == "." || letter.ToString() == "?" || letter.ToString() == "!")
				{
					yield return new WaitForSeconds(waitBetweenLetters * 3);
				}
				yield return new WaitForSeconds(waitBetweenLetters);
			}
			yield return new WaitForSeconds(waitBetweenSentences);
		}
		if (clearAtTheEnd)
		{
			writerText.text = "";
		}
		if (playEvent)
		{
			AfterEvent.Invoke();
		}
	}
}
