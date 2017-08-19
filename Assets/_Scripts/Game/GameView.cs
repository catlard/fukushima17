using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : SingletonMonoBehavior<GameView> {


	private float _spaceBetweenPlatforms = 6;
	private float _spaceBetweenCats = 6;

	public void Init() {
		PlatformFactory.instance.Init ();

	}

	public void BuildLevelFor(float xPosition) {
		//move the camera
		Vector3 currPos = Camera.main.transform.position;
		Vector3 newPos = currPos;
		newPos.x = xPosition;
		Camera.main.transform.position = Vector3.Lerp (currPos, newPos, .5f);


		//make the platforms and the cats
		Bounds b = CameraUtils.OrthographicBounds(Camera.main);

		//find edge of screen
		float edgeOfScreen = b.max.x + (b.extents.x * 1.5f);



		while (GameModel.instance.GetLastPlatformX () < edgeOfScreen) {
			GameObject newPlatform = PlatformFactory.instance.MakePlatform ();
			newPlatform.transform.position = new Vector3 (GameModel.instance.GetLastPlatformX () + _spaceBetweenPlatforms, 0, 0);
			GameController.instance.OnMakePlatform (newPlatform);
		}

		while (GameModel.instance.GetLastCatX () < edgeOfScreen) {
			GameObject newCat = PlatformFactory.instance.MakeCat ();
			newCat.transform.position = new Vector3 (GameModel.instance.GetLastCatX () + _spaceBetweenPlatforms, 0, 0);
			GameController.instance.OnMakeCat (newCat);
		}
	}
}
