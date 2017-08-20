using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : SingletonMonoBehavior<GameView> {
    public GameObject singlePlatform;

    public Transform spawnPoint;
    public Transform spawnPointRight;


    public List< Sprite > sprites;
    public GameObject cheese;

    public void Init() {
		PlatformFactory.instance.Init ();

		buildAllPlayer();
        resetAllPlayerPos();

		SoundLibrary.instance.PlaySound (new SoundParams("BGM", 0, .05f, -1));
    }

	public void buildAllPlayer()
    {
		foreach (PlayerData d in God.Static._players)
        {
			Mouse m = (MouseFactory.instance.makeMouse(d));
			GameController.instance.OnMakeMouse (m);
        }


        
    }

    public void resetAllPlayerPos()
    {
        foreach (Mouse m in GameModel.instance._playerList)
        {
            float randomX = Random.Range(spawnPointRight.position.x , spawnPoint.position.x) ;

            m.transform.position =new Vector3(randomX,spawnPoint.position.y,spawnPoint.position.z);
        }
    }

    public void BuildLevelFor(float xPosition) {
        //move the camera
        //make the platforms and the cats
        cameraMovement(xPosition);
        GameModel.instance.checkCameraPos();
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


        if (GameModel.instance.getIsCameraStop() )
        {
            return;
        }

        Camera.main.transform.position = new Vector3(xPosition, Camera.main.transform.position.y, Camera.main.transform.position.z);
    }

    public void playerEdgeDetermination()
    {
        if (GameModel.instance.getPlayerList().Count <= 0)
        {
            return;
        }
		foreach (Mouse m in GameModel.instance.getPlayerList() )
        {
            if (checkPlayerOutOffCameraEdge(m) )
            {
                destroyPlayerMice(m);
                Debug.Log("del player : " + m.gameObject);
                gameoverDetermination();
                return;
                //ondelPlayer
            }
        }
    }

    public bool gameoverDetermination()
    {
        if (GameModel.instance.getPlayerList().Count > 0)
        {
            // not gameover
            return false;
        }

        //yes no player left
        GameController.instance.OnGameOver();
        return true;
    }

    bool checkPlayerOutOffCameraEdge(Mouse m)
    {
        Bounds b = CameraUtils.OrthographicBounds(Camera.main);
		if (m.transform.position.x < b.min.x - 1.5 || m.transform.position.y < b.min.y - 1.5)
        {
            return true;
        }

        return false;
    }

    private void destroyPlayerMice(Mouse m)
    {
        //移除玩家
        GameModel.instance.removePlayerRegister(m);
		Destroy(m.gameObject);
		SoundLibrary.instance.PlaySound (new SoundParams ("mouse_dead", .1f, 1, 1));
		
    }

    public void updateCatAniSpeed()
    {
        CatSpeedController catSpeedSetUp = GameModel.instance.getListPlatformsList()[GameModel.instance.getListPlatformsList().Count-1].gameObject.GetComponentInChildren<CatSpeedController>();
        if (catSpeedSetUp != null)
        {
            float newSpeed =  (GameModel.instance.getCurrentLevel()*(0.25f+(Random.Range(-5,5)/10.0f) ) ); //speedhere
            catSpeedSetUp.ChangeSpeed(newSpeed);
            print("get!");
        }
    }

    public void buildCheese(Transform spawnpoint)
    {
        GameObject cheeseObject = Instantiate(cheese, spawnpoint);
        cheeseObject.transform.localPosition = new Vector3();
    }

    private void InitializedAllPlayer()
    {
        //PlayerData PD = playerDataBaseObject.GetComponent<PlayerData>();

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
