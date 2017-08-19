using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : SingletonMonoBehavior<GameView> {
    public GameObject singlePlatform;



	private float _spaceBetweenPlatforms = 6;
	private float _spaceBetweenCats = 6;

	public void Init() {
		PlatformFactory.instance.Init ();
    }

 public void BuildLevelFor(float xPosition) {
        //move the camera
        //make the platforms and the cats
        cameraMovement(xPosition);
        buildPlatforms();
    }

    void buildPlatforms()
    {
        Bounds b = CameraUtils.OrthographicBounds(Camera.main);
        if (GameModel.instance.getMostRightPointInPlatformsList() <= b.max.x + 6)
        {
            GameController.instance.OnMakePlatform();
        }
    }

    void cameraMovement(float xPosition) // here
    {
        //make camera move

        Camera.main.transform.position = new Vector3(xPosition, Camera.main.transform.position.y, Camera.main.transform.position.z);
    }





    public void displayLevel(int level)//work
    {
        //display current Level
        //print(level);
    }
    /*
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
>>>>>>> 76d3febc2ae5b603ee0c6a8b5137eea50d582411
*/
}
