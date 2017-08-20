using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultModel : SingletonMonoBehavior<ResultModel> {

	[SerializeField]
	private bool IsStarted;
	private Vector3 newCameraPos;

	[SerializeField]
	public List<PlayerData> Players;
	public List<GameObject> PlayerObject;
	public List<int> CurPlayerCheeseCount;
	public GameObject CheesePrefab;
	public Transform MainCameraPos;
	public int maxScore;
	public GameObject MousePrefab;
	public Sprite[] _hats = new Sprite[4];

	public void Init() {
		IsStarted  = false;
		newCameraPos = new Vector3 (0f, 1f, -10f);
	}

	public bool GetHaveResult () {
		if (GameObject.Find ("God") != null) {
			Debug.Log ("Have Result Deta.");
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
		Players = GameObject.Find("God").GetComponent<God>()._players;
	}


	public void CreatPlayerAssets () {
		int curPlayerCount = 0;
		int maxSortingOrder = (ResultModel.instance.Players.Count / 8) + 2;
		for (int i = 0; i < ResultModel.instance.Players.Count; i++) {
			if ((curPlayerCount % 8) % 2 == 0) {
				if ((curPlayerCount / 8) % 2 == 0) {
					GameObject player = Instantiate(MousePrefab, new Vector3((MOUSE_WIDTH/2f)+(MOUSE_WIDTH * (curPlayerCount % 8)/2f),(curPlayerCount / 8)*MOUSE_HIGHT + MOUSE_Y_OFFSET,0f),Quaternion.identity);
					PlayerObject.Add (player);
					CurPlayerCheeseCount.Add (0);
					player.GetComponent<Mouse> ()._myData = ResultModel.instance.Players [i];
					player.GetComponent<Mouse> ().Init ();
					player.transform.Find("Sprite").GetComponent<SpriteRenderer>().color = Players[i].color;
					player.GetComponent<Rigidbody2D> ().simulated = false;
					player.GetComponentInChildren<TextMesh>().text = Players[i].UP_alphabet;
					switch (Players[i].hatType) {
					case HatType.Gentlemen:
						player.GetComponent<Mouse>()._hat.sprite = _hats [1];
						break;
					case HatType.Roma:
						player.GetComponent<Mouse>()._hat.sprite = _hats [2];
						break;
					case HatType.Flower:
						player.GetComponent<Mouse>()._hat.sprite = _hats [3];
						break;
					case HatType.Party:
						player.GetComponent<Mouse>()._hat.sprite = _hats [4];
						break;
					}
				}else if((curPlayerCount / 8) % 2 == 1) {
					GameObject player = Instantiate(MousePrefab, new Vector3((MOUSE_WIDTH * (curPlayerCount % 8)/2f),(curPlayerCount / 8)*MOUSE_HIGHT + MOUSE_Y_OFFSET,0f),Quaternion.identity);
					PlayerObject.Add (player);
					CurPlayerCheeseCount.Add (0);
					player.GetComponent<Mouse> ()._myData = ResultModel.instance.Players [i];
					player.GetComponent<Mouse> ().Init ();
					player.transform.Find("Sprite").GetComponent<SpriteRenderer>().color = Players[i].color;
					player.GetComponent<Rigidbody2D> ().simulated = false;
					player.GetComponentInChildren<TextMesh>().text = Players[i].UP_alphabet;
					switch (Players[i].hatType) {
					case HatType.Gentlemen:
						player.GetComponent<Mouse>()._hat.sprite = _hats [1];
						break;
					case HatType.Roma:
						player.GetComponent<Mouse>()._hat.sprite = _hats [2];
						break;
					case HatType.Flower:
						player.GetComponent<Mouse>()._hat.sprite = _hats [3];
						break;
					case HatType.Party:
						player.GetComponent<Mouse>()._hat.sprite = _hats [4];
						break;
					}
				}	
			}else if ((curPlayerCount % 8) % 2 == 1) {
				if ((curPlayerCount / 8) % 2 == 0) {
					GameObject player = Instantiate(MousePrefab, new Vector3(0f-(MOUSE_WIDTH * (curPlayerCount % 8)/2f),(curPlayerCount / 8)*MOUSE_HIGHT + MOUSE_Y_OFFSET,0f),Quaternion.identity);
					PlayerObject.Add (player);
					CurPlayerCheeseCount.Add (0);
					player.GetComponent<Mouse> ()._myData = ResultModel.instance.Players [i];
					player.GetComponent<Mouse> ().Init ();
					player.transform.Find("Sprite").GetComponent<SpriteRenderer>().color = Players[i].color;
					player.GetComponent<Rigidbody2D> ().simulated = false;
					player.GetComponentInChildren<TextMesh>().text = Players[i].UP_alphabet;
					switch (Players[i].hatType) {
					case HatType.Gentlemen:
						player.GetComponent<Mouse>()._hat.sprite = _hats [1];
						break;
					case HatType.Roma:
						player.GetComponent<Mouse>()._hat.sprite = _hats [2];
						break;
					case HatType.Flower:
						player.GetComponent<Mouse>()._hat.sprite = _hats [3];
						break;
					case HatType.Party:
						player.GetComponent<Mouse>()._hat.sprite = _hats [4];
						break;
					}
				}else if((curPlayerCount / 8) % 2 == 1) {
					GameObject player = Instantiate(MousePrefab, new Vector3(0f-(MOUSE_WIDTH * (curPlayerCount % 8)/2f)-(MOUSE_WIDTH/2f),(curPlayerCount / 8)*MOUSE_HIGHT + MOUSE_Y_OFFSET,0f),Quaternion.identity);
					PlayerObject.Add (player);
					CurPlayerCheeseCount.Add (0);
					player.GetComponent<Mouse> ()._myData = ResultModel.instance.Players [i];
					player.GetComponent<Mouse> ().Init ();
					player.transform.Find("Sprite").GetComponent<SpriteRenderer>().color = Players[i].color;
					player.GetComponent<Rigidbody2D> ().simulated = false;
					player.GetComponentInChildren<TextMesh>().text = Players[i].UP_alphabet;
					switch (Players[i].hatType) {
					case HatType.Gentlemen:
						player.GetComponent<Mouse>()._hat.sprite = _hats [1];
						break;
					case HatType.Roma:
						player.GetComponent<Mouse>()._hat.sprite = _hats [2];
						break;
					case HatType.Flower:
						player.GetComponent<Mouse>()._hat.sprite = _hats [3];
						break;
					case HatType.Party:
						player.GetComponent<Mouse>()._hat.sprite = _hats [4];
						break;
					}
				}	
			}
			curPlayerCount++;
		}
	}


	public void PlusCheese (KeyCode _kcode) {
		for (int i = 0; i < Players.Count; i++) {
			if (Players [i].player_code == _kcode) {
				if (Players [i].score > CurPlayerCheeseCount [i]) {
					//Create Cheese
					Vector3 cheesePos = new Vector3(PlayerObject[i].transform.position.x,PlayerObject[i].transform.position.y - CHEESE_Y_OFFSET + CHEESE_HIGHT,PlayerObject[i].transform.position.z);
					Instantiate(CheesePrefab, cheesePos,Quaternion.identity).GetComponent<SpriteRenderer>().sortingOrder = CurPlayerCheeseCount[i];
					PlayerObject [i].transform.position = new Vector3 (PlayerObject [i].transform.position.x, PlayerObject [i].transform.position.y + CHEESE_Y_OFFSET + CHEESE_HIGHT, PlayerObject [i].transform.position.z);
					CurPlayerCheeseCount [i]++;
					if (CurPlayerCheeseCount [i] > maxScore) {
						maxScore = CurPlayerCheeseCount [i];
					}
				}
			}
		}
	}

	public void UpdateCameraPos () {
		if (maxScore > 3) {
			newCameraPos = new Vector3 (MainCameraPos.position.x, 1f + ( (CHEESE_HIGHT + CHEESE_Y_OFFSET) * (maxScore - 3)), MainCameraPos.position.z);
		}
	}

	public void CameraMotion () {
		MainCameraPos.position = Vector3.Lerp (MainCameraPos.position, newCameraPos, CHANGE_SPEED);
	}



	public PlayerData GetPlayerByON (int _PlayerON) {
		List<PlayerData> tempPlayerList = Players;
		PlayerData temp;
		for (int i = 1; i <= tempPlayerList.Count-1; i++) {    // 外層迴圈控制比較回數
			for (int j = 1; j <= tempPlayerList.Count - i; j++) {  // 內層迴圈控制每回比較次數            
				if (tempPlayerList[j].score > tempPlayerList[j - 1].score) {  // 比較鄰近兩個物件，右邊比左邊小時就互換。	       
					temp = tempPlayerList[j];
					tempPlayerList[j] = tempPlayerList[j - 1];
					tempPlayerList[j - 1] = temp;
				} 	
			}             
		}   
		return tempPlayerList [_PlayerON -1];
	}






	private const float MOUSE_WIDTH     = 2.5f;
	private const float MOUSE_HIGHT     = 1.0f;
	private const float MOUSE_Y_OFFSET  = -3f;
	private const float CHEESE_HIGHT    = 0.6f;
	private const float CHEESE_Y_OFFSET = 0.8f;
	private const float CHANGE_SPEED    = 0.65f;
}
