using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CountdownManager : SingletonMonoBehavior<CountdownManager> {

	private  SpriteRenderer _text;
	public int _maxCount = 1;
	private float _maxScale = 2;
	public float _moveDist;

	public Sprite[] _images;

	public void Start() {
		_text = transform.Find ("Text").GetComponent<SpriteRenderer> ();
		_text.sprite = null;
		_moveDist = CameraUtils.OrthographicBounds (Camera.main).extents.x * 1.5f;

	}


	public void StartCountdown() {
//		_text.GetComponent<SpriteRenderer> ().sortingLayerName = "count";
		StopCountdown ();
		StartCoroutine ("CountdownRoutine");
	}

	private IEnumerator CountdownRoutine() {
//		print ("STARTED");
		_text.sprite = null;

		yield return new WaitForSeconds (3);

		for (int i = 0; i < _maxCount; i++) {
			yield return StartCoroutine ("ChangeText", i);
		}

		yield return ChangeText (3);
		CountdownFinished ();
	}


	private IEnumerator ChangeText(int newText) {
		_text.transform.DOMoveX (-_moveDist, .5f).SetEase (Ease.InBack);
		yield return new WaitForSeconds (.5f);
		_text.transform.position = new Vector3 (_moveDist, 0, 0);
		_text.sprite = _images[newText];
//		_text.color = newText == "GO!" ? Color.red : Color.green;
		_text.transform.DOMoveX (0, .5f).SetEase (Ease.OutBack);
		yield return new WaitForSeconds (.5f);
		SoundLibrary.instance.PlaySound (new SoundParams ("mouse_jump", .25f, 1, 1));
		_text.transform.DOPunchScale (Vector3.one * .3f, .5f).SetEase (Ease.OutCubic);
		yield return new WaitForSeconds (.5f);
	}





	private void CountdownFinished() {

//		print ("COUNTDOWN WAS FINISHED");
		SceneManager.LoadScene("Game");

	}

	public void StopCountdown() {
		StopCoroutine ("CountdownRoutine");
		StopCoroutine ("ChangeText");
	}


	public void Update() {
		if (Input.GetKeyDown (KeyCode.A)) {
			StartCountdown ();
		}
	}


}
