using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : SingletonMonoBehavior<GameView> {
    public GameObject singlePlatform;


    public void Init() {


	}

	public void BuildLevelFor(float xPosition) {
        //move the camera
        //make the platforms and the cats
        cameraMovement(xPosition);
        //buildSinglePlatforms(xPosition);

    }

    void cameraMovement(float xPosition) // here
    {
        //make camera move

        Camera.main.transform.position = new Vector3(xPosition, Camera.main.transform.position.y, Camera.main.transform.position.z);
    }



    public Transform SinglePlatformsFactory(float buildInWhere)
    {
        Vector3 spawnPoint = new Vector3(buildInWhere,0,0);
        Transform newPlatform =  (Instantiate(singlePlatform,spawnPoint,Quaternion.identity) as GameObject).transform;
        return newPlatform;
    }

    public void displayLevel(int level)
    {
        //display current Level
        print(level);
    }

}
