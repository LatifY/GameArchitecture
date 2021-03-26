using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArchitecture
{
    public class AudioManager : MonoBehaviour
    {
		[Header("Audio Clips")]
		[SerializeField] private Sound[] sounds;

		[Header("Settings")]
		[SerializeField] private bool DontDestroy;
		public static AudioManager Instance;

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
			DontDestroyOnLoad(gameObject);

			foreach (Sound s in sounds)
			{
				s.source = gameObject.AddComponent<AudioSource>();
				s.source.clip = s.clip;
			}
		}

		#region PlayClip
		public void PlayClip(int index)
		{
			Sound s = sounds[index];
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;

			s.source.Play();
		}

		public void PlayClip(string name)
		{
			Sound s = Array.Find(sounds, item => item.name == name);
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;

			s.source.Play();
		}
		#endregion
		#region PlayClipWithRandomPitch
		public void PlayClipWithRandomPitch(int index, float minPitch, float maxPitch)
		{
			float randomPitch = UnityEngine.Random.Range(minPitch,maxPitch);

			Sound s = sounds[index];
			s.source.volume = s.volume;
			s.source.pitch = randomPitch;

			s.source.Play();
		}

		public void PlayClipWithRandomPitch(string name, float minPitch, float maxPitch)
		{
			float randomPitch = UnityEngine.Random.Range(minPitch, maxPitch);

			Sound s = Array.Find(sounds, item => item.name == name);
			s.source.volume = s.volume;
			s.source.pitch = randomPitch;

			s.source.Play();
		}
		#endregion
		#region PlayClipWithRandomVolume
		public void PlayClipWithRandomVolume(int index, float minVolume, float maxVolume)
		{
			float randomVolume = UnityEngine.Random.Range(minVolume, maxVolume);

			Sound s = sounds[index];
			s.source.volume = randomVolume;
			s.source.pitch = s.pitch;

			s.source.Play();
		}

		public void PlayClipWithRandomVolume(string name, float minVolume, float maxVolume)
		{
			float randomVolume = UnityEngine.Random.Range(minVolume, maxVolume);

			Sound s = Array.Find(sounds, item => item.name == name);
			s.source.volume = randomVolume;
			s.source.pitch = s.pitch;

			s.source.Play();
		}
		#endregion

	}
}

