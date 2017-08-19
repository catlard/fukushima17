using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonMonoBehavior<GameController> {

	// Use this for initialization
	void Start () {
		GameModel.instance.Init ();
		GameView.instance.Init ();
	}
	
	// Update is called once per frame
	void Update () {
		float newX = GameModel.instance.UpdateX ();
		GameView.instance.BuildLevelFor (newX);
	}
}
