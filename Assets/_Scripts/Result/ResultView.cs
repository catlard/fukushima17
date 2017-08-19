using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultView : SingletonMonoBehavior<ResultView> {

	public void Init() {

	}
	

	public void InitResultAssest () {
		Debug.Log ("Init Result Assest.");
		ResultModel.instance.CreatPlayerAssets ();
	}
		







}
