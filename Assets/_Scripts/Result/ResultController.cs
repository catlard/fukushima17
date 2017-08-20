using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResultController : SingletonMonoBehavior<ResultController> {

	private float timer;

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
//		foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
//		{
//			if (Input.GetKeyDown (kcode)) {
//				ResultModel.instance.PlusCheese (kcode);
//				ResultView.instance.UpdateComera ();
//			}
//		}


		if (timer > 0.2f) {
			foreach(PlayerData data in ResultModel.instance.Players)
			{
				ResultModel.instance.PlusCheese (data.player_code);
				ResultView.instance.UpdateComera ();
			}
			timer = 0f;
		}
		timer += Time.deltaTime;

	}


}
