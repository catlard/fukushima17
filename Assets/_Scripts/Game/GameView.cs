using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : SingletonMonoBehavior<GameView> {

	public void Init() {
		print ("HILLLO");


	}

	public void BuildLevelFor(float xPosition) {
		//move the camera
		//make the platforms and the cats
		print(xPosition);
	}
}
