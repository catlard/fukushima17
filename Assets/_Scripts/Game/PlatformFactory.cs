using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFactory : SingletonMonoBehavior<PlatformFactory> {

    public GameObject _singlePlatform;
    public GameObject _platform;
	public GameObject _cat;


	public void Init() {

	}

    public Transform SinglePlatformsFactory(float buildInWhere)
    {
        Vector3 spawnPoint = new Vector3(buildInWhere, 0, 0);
        Transform newPlatform = (Instantiate(_singlePlatform, spawnPoint, Quaternion.identity) as GameObject).transform;
        return newPlatform;
    }



    public GameObject MakePlatform() {
		GameObject go = (GameObject)GameObject.Instantiate (_platform);
		go.tag = "Floor";
		return go;
	}

	public GameObject MakeCat() {
		GameObject go = (GameObject)GameObject.Instantiate (_cat);
		go.tag = "CatBelly";
		return go;
	}
}
