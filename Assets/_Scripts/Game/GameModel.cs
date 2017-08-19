using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : SingletonMonoBehavior<GameModel> {

	private float _currentXPosition = 0;

	public void Init() {

	}

	public float UpdateX() {
		_currentXPosition += (Time.deltaTime * 10);
		return _currentXPosition;
	}

}
