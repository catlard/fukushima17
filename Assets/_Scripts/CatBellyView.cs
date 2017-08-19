using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBellyView : MonoBehaviour {

	private float _currentPower;
	private float _breathingSpeed;
	private float _scaleUp = 5f;

	private Vector3 _startScale;
	private Vector3 _finishScale;



	public void Start() {
		Init (1);
	}

	public void Init(float breathingSpeed) {
		_breathingSpeed = breathingSpeed;
		_startScale = transform.localScale;
		_finishScale = _startScale * _scaleUp;
	}

	public void Update() {

		_currentPower += Time.deltaTime * _breathingSpeed * 1;

		//debug view;
		float wrapped = GetPower ();
		Vector3 s = Vector3.Lerp (_startScale, _finishScale, wrapped);
		transform.localScale = s;
	}

	public float GetPower() {
		float wrapped = _currentPower % 2;
		if (wrapped > 1)
			wrapped = 1 - (wrapped - 1);

		return wrapped;
	}


}
