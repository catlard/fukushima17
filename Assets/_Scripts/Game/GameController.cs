using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonMonoBehavior<GameController> {

	// Use this for initialization
	void Start () {
		GameModel.instance.Init ();
		GameView.instance.Init ();
	}
	
    private float Xpos  = 0;

	// Update is called once per frame
	void Update () {
		float newX = GameModel.instance.UpdateX ();
		GameView.instance.BuildLevelFor (newX);

        int level = GameModel.instance.getCurrentLevel();
        GameView.instance.displayLevel(level);

        Xpos = newX;
        testZone();

        makePlatformEvent();
    }

    void makePlatformEvent()
    {
        Bounds b = CameraUtils.OrthographicBounds(Camera.main);
        if (GameModel.instance.getMostRightPointInPlatformsList() > b.max.x + 2)
        {
            return;
        }

        float spawnInWhere = GameModel.instance.getMostRightPointInPlatformsList();


        //spawn
        Transform newPlatform = GameView.instance.SinglePlatformsFactory(spawnInWhere);
            GameModel.instance.registerNewPlatformToList(newPlatform);
        



        if (GameModel.instance.getListPlatformsList().Count > 5)
        {
            GameModel.instance.removeOldestPlatformToList();
        }

    }

    void testZone()
    {
        if (Input.GetKeyDown(KeyCode.L) )
        {
            //makePlatformEvent();
        }
    }



}
