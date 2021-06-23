using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicManager : MonoBehaviour
{
	[Header("Musics")]
	[SerializeField] private Music[] musics;

	[Header("Settings")]
	[SerializeField] private bool dontDestroy;
	public static MusicManager Instance;


	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		if (dontDestroy)
		{
			DontDestroyOnLoad(gameObject);
		}

		foreach (Music m in musics)
		{
			m.source = gameObject.AddComponent<AudioSource>();
			m.source.playOnAwake = m.playOnAwake;
			m.source.loop = m.loop;
			m.source.clip = m.clip;
			if (m.source.playOnAwake)
			{
				m.source.Play();
			}
		}
	}

	public void PlayMusic(int index)
	{
		StopAll();
		musics[index].source.Play();
	}

	public void PlayMusic(string name)
	{
		StopAll();
		Music m = Array.Find(musics, item => item.name == name);
		m.source.Play();
	}

	public void StopAll()
	{
		foreach (Music m in musics)
		{
			m.source.Stop();
		}
	}

}
