using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultController : SingletonMonoBehavior<ResultController> {


	void Start () {
		ResultModel.instance.Init ();
		ResultView.instance.Init ();
		if (ResultModel.instance.GetHaveResult () == true && ResultModel.instance.GetIsStarted() == false) {
			ResultModel.instance.InitResultAssest ();
			ResultModel.instance.StartPlayResult ();
			ResultModel.instance.SetIsStarted (true);
		}
	}


	void Update () {


	}


}
