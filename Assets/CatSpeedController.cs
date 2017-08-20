using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpeedController : MonoBehaviour {

	public float _speedMult = 1f;
	public Animator _animator;

	public void ChangeSpeed(float newSpeed) {
		_speedMult = newSpeed;
		_animator.SetFloat("speed", newSpeed);
	}

//
//	public void Update() {
//		ChangeSpeed (_speedMult);
//	}
//






}
