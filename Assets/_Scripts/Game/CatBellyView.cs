using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBellyView : MonoBehaviour {

	public float _currentPower;

	public float GetPower() {
		return transform.localScale.x;
	}



}
