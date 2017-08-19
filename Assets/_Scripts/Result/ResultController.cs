using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResultController : SingletonMonoBehavior<ResultController> {


	void Start () {
		ResultModel.instance.Init ();
		ResultView.instance.Init ();
		if (ResultModel.instance.GetHaveResult () == true && ResultModel.instance.GetIsStarted() == false) {
			ResultModel.instance.LoadGameResult ();
			ResultView.instance.InitResultAssest ();
			ResultModel.instance.SetIsStarted (true);
		}
	}


	void Update () {
		foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKeyDown (kcode)) {
				ResultModel.instance.PlusCheese (kcode);
			}
		}

	}


}
