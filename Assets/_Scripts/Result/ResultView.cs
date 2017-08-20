using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultView : SingletonMonoBehavior<ResultView> {

	public GameObject Player1_Object;
	public GameObject Player2_Object;
	public GameObject Player3_Object;
	public GameObject Player4_Object;
	public GameObject Player5_Object;
	public GameObject ShowScorePartical;
	public GameObject TipsPartical;
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

	private bool canLeave;

	public void Init() {
		canLeave = false;
	}
	

	public void InitResultAssest () {
		Debug.Log ("Init Result Assest.");
		ResultModel.instance.CreatPlayerAssets ();
	}

	public void UpdateComera () {
		ResultModel.instance.UpdateCameraPos ();
	}

	public void ShowScore () {
		canLeave = true;
		ShowScorePartical.SetActive (true);
		TipsPartical.SetActive (true);
		switch (ResultModel.instance.Players.Count) {
		case 1:
			Player1_Object.SetActive (true);
			Player2_Object.SetActive (false);
			Player3_Object.SetActive (false);
			Player4_Object.SetActive (false);
			Player5_Object.SetActive (false);
			Player1_Score.text = ResultModel.instance.GetPlayerByON (1).score.ToString ();
			return;
			break;
		case 2:
			Player1_Object.SetActive (true);
			Player2_Object.SetActive (true);
			Player3_Object.SetActive (false);
			Player4_Object.SetActive (false);
			Player5_Object.SetActive (false);
			Player1_Score.text = ResultModel.instance.GetPlayerByON (1).score.ToString ();
			Player2_Score.text = ResultModel.instance.GetPlayerByON (2).score.ToString ();
			return;
			break;
		case 3:
			Player1_Object.SetActive (true);
			Player2_Object.SetActive (true);
			Player3_Object.SetActive (true);
			Player4_Object.SetActive (false);
			Player5_Object.SetActive (false);
			Player1_Score.text = ResultModel.instance.GetPlayerByON (1).score.ToString ();
			Player2_Score.text = ResultModel.instance.GetPlayerByON (2).score.ToString ();
			Player3_Score.text = ResultModel.instance.GetPlayerByON (3).score.ToString ();
			return;
			break;
		case 4:
			Player1_Object.SetActive (true);
			Player2_Object.SetActive (true);
			Player3_Object.SetActive (true);
			Player4_Object.SetActive (true);
			Player5_Object.SetActive (false);
			Player1_Score.text = ResultModel.instance.GetPlayerByON (1).score.ToString ();
			Player2_Score.text = ResultModel.instance.GetPlayerByON (2).score.ToString ();
			Player3_Score.text = ResultModel.instance.GetPlayerByON (3).score.ToString ();
			Player4_Score.text = ResultModel.instance.GetPlayerByON (4).score.ToString ();
			return;
			break;
		}
		Player1_Object.SetActive (true);
		Player2_Object.SetActive (true);
		Player3_Object.SetActive (true);
		Player4_Object.SetActive (true);
		Player5_Object.SetActive (true);
		Player1_Score.text = ResultModel.instance.GetPlayerByON (1).score.ToString ();
		Player2_Score.text = ResultModel.instance.GetPlayerByON (2).score.ToString ();
		Player3_Score.text = ResultModel.instance.GetPlayerByON (3).score.ToString ();
		Player4_Score.text = ResultModel.instance.GetPlayerByON (4).score.ToString ();
		Player5_Score.text = ResultModel.instance.GetPlayerByON (5).score.ToString ();


	}


	private void Update () {
		ResultModel.instance.CameraMotion ();
		if (ResultModel.instance.maxScore == ResultModel.instance.GetPlayerByON (1).score) {
			ShowScore ();
		}

		if (canLeave == true) {
			if (Input.GetKeyDown (KeyCode.Return)) {
				Destroy( GameObject.Find ("God"));
				SceneManager.LoadScene("Menu");
			}
		}
	}



}
