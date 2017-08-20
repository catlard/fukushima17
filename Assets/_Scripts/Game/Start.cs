using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour {

    public Button ExitStart;

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

	public void Update() {
		if (Input.anyKeyDown) {
			ExitToMenu ();
		}
	}
}
