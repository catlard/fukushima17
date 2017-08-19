using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFactory : SingletonMonoBehavior<PlatformFactory> {

	public GameObject _platform;
	public GameObject _cat;


	public void Init() {

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
