using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameModel : SingletonMonoBehavior<GameModel> {

	private float _currentXPosition = 0;
	public List<GameObject> _platforms;
	public List<GameObject> _cats;


	public void Init() {
		_platforms = GameObject.FindGameObjectsWithTag ("Floor").ToList<GameObject> ();
		_cats = GameObject.FindGameObjectsWithTag ("CatBelly").ToList<GameObject> ();

	}

	public float UpdateX() {
		_currentXPosition += (Time.deltaTime * .5f);
		return _currentXPosition;
	}


	public void OnMakePlatform(GameObject platform) {
		_platforms.Add (platform);
	}

	public float GetLastPlatformX() {
		GameObject latest = _platforms [_platforms.Count - 1];
		return latest.GetComponent<SpriteRenderer> ().bounds.max.x;
	}

	public void OnMakeCat(GameObject cat) {
		_cats.Add (cat);

	}

	public float GetLastCatX() {
		GameObject latest = _cats [_cats.Count - 1];
		return latest.GetComponent<SpriteRenderer> ().bounds.max.x;
	}

}
