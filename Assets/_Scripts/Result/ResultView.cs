using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultView : SingletonMonoBehavior<ResultView> {

	public GameObject Player1_Object;
	public GameObject Player2_Object;
	public GameObject Player3_Object;
	public GameObject Player4_Object;
	public GameObject Player5_Object;
	public Text Player1_Score;
	public Text Player2_Score;
	public Text Player3_Score;
	public Text Player4_Score;
	public Text Player5_Score;
	public Image Player1_Image;
	public Image Player2_Image;
	public Image Player3_Image;
	public Image Player4_Image;
	public Image Player5_Image;


	public void Init() {

	}
	

	public void InitResultAssest () {
		Debug.Log ("Init Result Assest.");
		ResultModel.instance.CreatPlayerAssets ();
	}

	public void UpdateComera () {
		ResultModel.instance.UpdateCameraPos ();
	}


	private void Update () {
		ResultModel.instance.CameraMotion ();
	}

}
