using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CountdownManager : SingletonMonoBehavior<CountdownManager> {

	private  TextMesh _text;
	public int _maxCount = 3;
	private float _maxScale = 2;

	public void Start() {
		_text = transform.FindChild ("Text").GetComponent<TextMesh> ();
		_text.text = "";

	}


	public void StartCountdown() {
		StopCoroutine ("CountdownRoutine");
		StartCoroutine ("CountdownRoutine");
	}

	private IEnumerator CountdownRoutine() {
		print ("STARTED");
		_text.text = "";

		yield return new WaitForSeconds (3);

		for (int i = 0; i < _maxCount; i++) {
			_text.text = (_maxCount - i).ToString();
			_text.color = Color.green;
			yield return new WaitForSeconds (1);
		}

		_text.text = "!";
		_text.color = Color.red;
		yield return new WaitForSeconds (1);
		CountdownFinished ();
	}







	private void CountdownFinished() {

		print ("COUNTDOWN WAS FINISHED");

	}


	public void Update() {
		if (Input.GetKeyDown (KeyCode.A)) {
			StartCountdown ();
		}
	}


}
