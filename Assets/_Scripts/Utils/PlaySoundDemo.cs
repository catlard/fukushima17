using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundDemo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SoundLibrary.instance.Init ();
		SoundLibrary.instance.PlaySound(new SoundParams("mouse_3", .1f, 1, 1));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
