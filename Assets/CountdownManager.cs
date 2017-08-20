using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CountdownManager : SingletonMonoBehavior<CountdownManager> {

	private  TextMesh _text;
	public int _maxCount = 3;
	private float _maxScale = 2;
	private float _moveDist;

	public void Start() {
		_text = transform.Find ("Text").GetComponent<TextMesh> ();
		_text.text = "";
		_moveDist = CameraUtils.OrthographicBounds (Camera.main).extents.x * 1.5f;

	}


	public void StartCountdown() {
		_text.GetComponent<MeshRenderer> ().sortingLayerName = "count";
		StopCountdown ();
		StartCoroutine ("CountdownRoutine");
	}

	private IEnumerator CountdownRoutine() {
		print ("STARTED");
		_text.text = "";

		yield return new WaitForSeconds (3);

		for (int i = 0; i < _maxCount; i++) {
			yield return StartCoroutine ("ChangeText", (_maxCount - i).ToString ());
		}

		yield return ChangeText ("GO!");
		CountdownFinished ();
	}


	private IEnumerator ChangeText(string newText) {
		_text.transform.DOMoveX (-_moveDist, .5f).SetEase (Ease.InBack);
		yield return new WaitForSeconds (.5f);
		_text.transform.position = new Vector3 (_moveDist, 0, 0);
		_text.text = newText;
		_text.color = newText == "GO!" ? Color.red : Color.green;
		_text.transform.DOMoveX (0, .5f).SetEase (Ease.OutBack);
		yield return new WaitForSeconds (.5f);
		SoundLibrary.instance.PlaySound (new SoundParams ("mouse_jump", .25f, 1, 1));
		_text.transform.DOPunchScale (Vector3.one * .3f, .5f).SetEase (Ease.OutCubic);
		yield return new WaitForSeconds (.5f);
	}





	private void CountdownFinished() {

		print ("COUNTDOWN WAS FINISHED");
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
