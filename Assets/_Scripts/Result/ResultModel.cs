using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultModel : SingletonMonoBehavior<ResultModel> {

	private ResultDeta ResultDeta;
	[SerializeField]
	private bool IsStarted;
	private int maxScore;

	[SerializeField]
	public List<PlayerData> Players;
	public List<GameObject> PlayerObject;
	public List<int> CurPlayerCheeseCount;

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
		PlayerObject.Clear ();
		Players.Clear ();
		Players = ResultDeta.players;
	}


	public void CreatPlayerAssets () {
		int curPlayerCount = 0;
		int maxSortingOrder = (ResultModel.instance.Players.Count / 8) + 2;
		for (int i = 0; i < ResultModel.instance.Players.Count; i++) {
			if ((curPlayerCount % 8) % 2 == 0) {
				if ((curPlayerCount / 8) % 2 == 0) {
					GameObject player = Instantiate(Players[i].StylePrefab, new Vector3((MOUSE_WIDTH/2f)+(MOUSE_WIDTH * (curPlayerCount % 8)/2f),(curPlayerCount / 8)*MOUSE_HIGHT + MOUSE_Y_OFFSET,0f),Quaternion.identity);
					PlayerObject.Add (player);
					player.GetComponent<SpriteRenderer> ().sortingOrder = maxSortingOrder - (curPlayerCount / 8);
				}else if((curPlayerCount / 8) % 2 == 1) {
					GameObject player = Instantiate(Players[i].StylePrefab, new Vector3((MOUSE_WIDTH * (curPlayerCount % 8)/2f),(curPlayerCount / 8)*MOUSE_HIGHT + MOUSE_Y_OFFSET,0f),Quaternion.identity);
					PlayerObject.Add (player);
					player.GetComponent<SpriteRenderer> ().sortingOrder = maxSortingOrder - (curPlayerCount / 8);
				}	
			}else if ((curPlayerCount % 8) % 2 == 1) {
				if ((curPlayerCount / 8) % 2 == 0) {
					GameObject player = Instantiate(Players[i].StylePrefab, new Vector3(0f-(MOUSE_WIDTH * (curPlayerCount % 8)/2f),(curPlayerCount / 8)*MOUSE_HIGHT + MOUSE_Y_OFFSET,0f),Quaternion.identity);
					PlayerObject.Add (player);
					player.GetComponent<SpriteRenderer> ().sortingOrder = maxSortingOrder - (curPlayerCount / 8);
				}else if((curPlayerCount / 8) % 2 == 1) {
					GameObject player = Instantiate(Players[i].StylePrefab, new Vector3(0f-(MOUSE_WIDTH * (curPlayerCount % 8)/2f)-(MOUSE_WIDTH/2f),(curPlayerCount / 8)*MOUSE_HIGHT + MOUSE_Y_OFFSET,0f),Quaternion.identity);
					PlayerObject.Add (player);
					player.GetComponent<SpriteRenderer> ().sortingOrder = maxSortingOrder - (curPlayerCount / 8);
				}	
			}
			curPlayerCount++;
		}
	}


	public void PlusCheese (KeyCode _kcode) {
		for (int i = 0; i < Players.Count; i++) {
			if (Players [i].player_code == _kcode) {
				if (Players [i].score < CurPlayerCheeseCount [i]) {
					//Create Cheese

				}
			}
		}
	}





	private const float MOUSE_WIDTH = 2.5f;
	private const float MOUSE_HIGHT = 1.0f;
	private const float MOUSE_Y_OFFSET = -2f;
	private const float CHEESE_HIGHT = 1.0f;
	private const float CHEESE_Y_OFFSET = 0.5f;
}
