using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
#if UNITY_EDITOR
	using UnityEditor;
#endif
using System.Linq;

public class SoundLibrary : SingletonMonoBehavior<SoundLibrary> {
	#if UNITY_EDITOR
		[ContextMenu ("Sort Sounds by Name")]
		public void SortSounds() {
			if (_allSounds == null)
				return;
			_allSounds = _allSounds.Where(x => x).ToArray();
			_allSounds = _allSounds.OrderBy(x => x.name).ToArray();   
			Debug.Log(_allSounds.Length + " sounds have been sorted alphabetically.");
		}
	#endif

	public AudioClip[] _allSounds;
	[HideInInspector] public List<PlayingSound> _playingSounds;
	private AudioListener _listener;
	public bool _mute;
	private bool _isInitted = false;

	public bool _debugSoundTriggers = true;

	private SoundParams _params;

	public void Init() {

		_isInitted = true;
		AudioListener mainCamList = Camera.main.GetComponent<AudioListener> ();
		if(mainCamList!=null) 
			GameObject.Destroy (mainCamList);
		_playingSounds = new List<PlayingSound> ();
		AddListener();
	}

	public void AddListener() {
		_listener = GetComponent<AudioListener> ();
		if(_listener == null)
			_listener = gameObject.AddComponent<AudioListener> ();
	}

	//todo pool audiosources.
	/// <summary>
	/// Play a sound by name.
	/// </summary>
	/// <param name="p">P.</param>
	public PlayingSound PlaySound(SoundParams p) {

		if (!_isInitted) {
			Init ();
		}
			
		AudioClip thisClip = null;
		foreach (AudioClip clip in _allSounds) {
			if (clip != null && clip.name == p._name) {
				thisClip = clip;
			}
		}
		if (thisClip == null) {
			Debug.LogWarning ("SOUND LIBRARY: No sound called " + p._name);
			return null;
		}

		AudioSource l = _listener.gameObject.AddComponent<AudioSource> ();
		l.clip = thisClip;
		l.volume = _mute ? 0 : p._volume;
		l.pitch = p._pitch;

		SoundParams pCopy = new SoundParams (p._name, p._pitch, p._volume, p._loops);


		pCopy._playedPitch = l.pitch;

		PlayingSound mySound = new PlayingSound (pCopy, l);
		_playingSounds.Add(mySound);
		l.Play ();

		StartCoroutine ("TryKillSound", mySound);
		return mySound;
	}

	private IEnumerator TryKillSound(PlayingSound s) {
		while(s != null && s._source != null) {yield return 0; }
		if (s == null || s._source == null) { //maybe it was destroyed while this was going on.
			KillSoundImmediately(s);
			yield break;
		}
		
		s._soundParams._loops--;
		if (s._soundParams._loops == 0) {
			KillSoundImmediately(s);
		} else {
			s._source.Play ();
			StartCoroutine ("TryKillSound", s);
		}
	}

	public void KillSoundImmediately(PlayingSound s) {
		GameObject.Destroy (s._source);
		_playingSounds.Remove (s);
	}

	/// <summary>
	/// Sets the volume percent of one sound.
	/// </summary>
	/// <param name="soundName">Sound name.</param>
	public void SetVolumePercent(string soundName, float percent) {
		PlayingSound s = GetPlayingSound (soundName);
		if (s == null) {
			Debug.LogWarning ("SOUND LIBRARY: " + soundName + " isn't playing, so can't set volume.");
			return;
		} else {
			s._source.volume = s._soundParams._volume * percent;
		}
	}

	/// <summary>
	/// Sets the volume percent of all sounds.
	/// </summary>
	public void SetVolumePercent(float percent) {
		foreach (PlayingSound s in _playingSounds) {
			s._source.volume = s._soundParams._volume * percent;
		}
	}

	public void TweenVolume(string soundName, float volumePercent = 1, float duration = 1) {
		PlayingSound s = GetPlayingSound (soundName);
		TweenVolume (s, volumePercent, duration);
	}

	public void TweenPitch(string soundName, float pitchPercent = 1, float duration = 1) {
		PlayingSound s = GetPlayingSound (soundName);
		TweenPitch (s, pitchPercent, duration);
	}

	public void TweenVolume(PlayingSound s, float volumePercent = 1, float duration = 1) {
		if (s == null) {
			Debug.LogError ("SOUNDLIBRARY: Received a null playingsound.");
			return;
		}

		if (_mute) return;
		if (s._tweens == null)
			s._tweens = new List<Tween> ();
		
		s._source.DOFade (volumePercent * s._soundParams._volume, duration);
	}



	public void TweenPitch(PlayingSound s, float pitchPercent = 1, float duration = 1) {
		if (_mute) return;

		if (s._tweens == null)
			s._tweens = new List<Tween> ();
		s._source.DOPitch (pitchPercent * s._soundParams._playedPitch, duration);
	}

	public PlayingSound GetPlayingSound(string name) {
		foreach (PlayingSound s in _playingSounds) {
			if (s._source.clip.name == name) {
				return s;
			}
		}
		return null;
	}

	public bool IsPlayingSound(string name) {
		PlayingSound s = GetPlayingSound (name);
		return s == null ? true : false;
	}
		
}

/// <summary>
/// Make sound parameters for playing sounds.
/// </summary>
[System.Serializable]
public class SoundParams {
	public string _name;
	public float _pitch = 1f;
	public float _volume = 1f;
	public int _loops = 1;
	[HideInInspector] public float _playedPitch;  // the pitch at which the pitch variance resolved to.

	public SoundParams (string name, float pitchVariance = 0, float volume = 1, int loops = 1) {
		_name = name; 
		_pitch = 1 + ((Random.value * pitchVariance) * (Random.value > .5f ? 1 : -1));
		_volume = volume; _loops = loops;
	}

	public SoundParams (float pitch, float volume, string name) {
		_name = name; _pitch = pitch; _volume = volume;
	}
}

[System.Serializable] 
public class PlayingSound {
	public SoundParams _soundParams;
	public AudioSource _source;
	public List<Tween> _tweens;

	public PlayingSound(SoundParams p, AudioSource s) {
		_soundParams = p; _source = s;
	}
}
