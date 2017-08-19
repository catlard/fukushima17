using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SoundController : SingletonMonoBehavior<SoundController>  
{
	float interval = 0.1f;

	void Start()
	{
		SoundLibrary.instance.Init ();
		PlayCatSnore ();
	}

	public void PlayCatSnore(bool isLoop = true)
	{
		StartCoroutine (CatSnoreRoutine(isLoop));
	}

	public void PlayMouseNormal(bool isLoop = false)
	{
		StartCoroutine (MouseNormalSoundRoutine(isLoop));
	}

	public void StopCatSnore()
	{
		StopCoroutine (CatSnoreRoutine());
	}

	public void StopMouseNormal()
	{
		StopCoroutine (MouseNormalSoundRoutine());
	}
	public void StopAllSound()
	{
		StopCoroutine (CatSnoreRoutine());
		StopCoroutine (MouseNormalSoundRoutine());
	}

	public void PlayMouseIsDead()
	{
		SoundLibrary.instance.PlaySound (new SoundParams("mouse_6", 0.1f, 1, 1));
	}

	IEnumerator MouseNormalSoundRoutine(bool isLoop = false)
	{
		PlayingSound sound = SoundLibrary.instance.PlaySound (new SoundParams("mouse_3", 0.1f, 1, 1));
		yield return new WaitForSeconds(sound._source.clip.length + interval);
		sound = SoundLibrary.instance.PlaySound (new SoundParams("mouse_5", 0.1f, 1, 1));
		yield return new WaitForSeconds(sound._source.clip.length+ interval);

		if (isLoop) {
			yield return new WaitForSeconds (1);
			StartCoroutine (MouseNormalSoundRoutine (isLoop));
		}
	}

	IEnumerator CatSnoreRoutine(bool isLoop = true)
	{
		PlayingSound sound = SoundLibrary.instance.PlaySound (new SoundParams("snore_1", 0.1f, 1, 1));
		yield return new WaitForSeconds(sound._source.clip.length + interval);
		sound = SoundLibrary.instance.PlaySound (new SoundParams("snore_2", 0.1f, 1, 1));
		yield return new WaitForSeconds(sound._source.clip.length + interval);
		sound = SoundLibrary.instance.PlaySound (new SoundParams("snore_3", 0.1f, 1, 1));
		yield return new WaitForSeconds(sound._source.clip.length + interval);
		if (isLoop) {
			yield return new WaitForSeconds (1);
			StartCoroutine (CatSnoreRoutine (isLoop));
		}
	}
}
