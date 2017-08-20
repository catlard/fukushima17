using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : SingletonMonoBehavior<GameController> {

	// Use this for initialization
	void Start () {
		print ("Start gamecontroller");
		GameModel.instance.Init ();
		GameView.instance.Init ();
	}
	
    private float Xpos  = 0;

	// Update is called once per frame
	void Update () {
		float newX = GameModel.instance.UpdateX ();

        GameView.instance.BuildLevelFor(newX);

        int level = GameModel.instance.getCurrentLevel();
        GameView.instance.displayLevel(level);
        GameView.instance.playerEdgeDetermination();
        GameModel.instance.runningStopTimer();

        Xpos = newX;
        testZone();


    }

    public void OnMakePlatform()
    {


        float spawnInWhere = GameModel.instance.getMostRightPointInPlatformsList();


        //spawn
        Transform newPlatform = PlatformFactory.instance.SinglePlatformsFactory(spawnInWhere);
         Transform cabinetTran =  GameModel.instance.getCabinetObjectTransform(newPlatform); //已取得櫃臺的transform
        float newCabinetHeight = GameModel.instance.getRandomHeight();
        cabinetTran.position = new Vector3(cabinetTran.position.x, newCabinetHeight, cabinetTran.position.z);

        GameModel.instance.registerNewPlatformToList(newPlatform);
        



        if (GameModel.instance.getListPlatformsList().Count > 5)
        {
            GameModel.instance.removeOldestPlatformToList();
        }

    }

	public void OnMakeMouse(Mouse m) {
		GameModel.instance._playerList.Add (m);
	}

    public void OnEnterCameraStopPoint()
    {
        //通 //work
        //Debug.Log("stop");
    }
    public void OnExitCameraStopPoint()
    {
        //work
        GameModel.instance.updateMostRightCameraStopPoint();
        GameModel.instance.updateCameraWaitingTime();
    }

    public void OnGameOver()
    {
        //通 //work
        Debug.Log("gameover");
        SceneManager.LoadScene(2);
    }

    void testZone()
    {
        /*
        if (Input.GetKeyDown((KeyCode)97)) 
        {
            SceneManager.LoadScene(0);
            //makePlatformEvent();
            print("diu u");
        }
        if (Input.GetKeyDown(KeyCode.L) )
        {
            //makePlatformEvent();
            GameModel.instance.setIsCameraStop(false);
            //print( GameModel.instance.getRandomHeight() );
        }
        */
    }



	}

/*
	public void OnMakePlatform(GameObject go) {
		GameModel.instance.OnMakePlatform (go);
	}

	public void OnMakeCat(GameObject go) {
		GameModel.instance.OnMakeCat (go);
	}
    */


