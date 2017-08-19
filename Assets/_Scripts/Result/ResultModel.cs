using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultModel : SingletonMonoBehavior<ResultModel> {

	private ResultDeta ResultDeta;
	[SerializeField]
	private bool IsStarted;


	public void Init() {
		IsStarted  = false;
	}

	public bool GetHaveResult () {
		if (GameObject.Find ("ResultDetaObject") != null) {
			ResultDeta = GameObject.Find ("ResultDetaObject").GetComponent<ResultDeta>();
			return true;
		} else {
			Debug.Log ("No Result Deta.");
			return false;
		}
	}

	public bool GetIsStarted () {
		return IsStarted;
	}

	public void SetIsStarted (bool _IsStarted) {
		IsStarted = _IsStarted;
	}

	public void LoadGameResult () {
		Debug.Log ("Load Game Result.");
	}

	public void InitResultAssest () {
		Debug.Log ("Init Result Assest.");
	}

	public void StartPlayResult () {
		Debug.Log ("Start Play Result.");
	}
}
