using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_script : MonoBehaviour
{
    public bool alphabetlock = false;
	public List<PlayerData> _players = new List<PlayerData>();
    public string keyShow;
	public List<Mouse> _mice;

	void Start()
    {
        _players = new List<PlayerData> ();
		_mice = new List<Mouse> ();
    }

	public void RemoveMouseWithKeycode(KeyCode k) {
		for (int i = _mice.Count -1; i >= 0; i--) {
			if (_mice [i]._myData.player_code == k) {
				GameObject.Destroy (_mice [i].gameObject);
				_mice.RemoveAt (i);
			}
		}
	}

    public void Update()
    {
        
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))//Get what key are you pressing
        {
			if (Input.GetKeyDown (kcode))
           {
                //Debug.Log(keyShow);
                if((int)kcode==27)//get escape key
                {
                    Debug.Log("esc");
                }

                if((int)kcode==13)//get enter key
                {
					

					God.instance._players = _players; // tell god about your problems;
					SceneManager.LoadScene("Game");


                }

				//search for keycodes.
				if ((int)kcode >= 97 && (int)kcode <= 122) {// only alphabet 
					bool found = false;
					keyShow = kcode.ToString ();
					for (int i = _players.Count - 1; i > -1; i--) {//remove the mouse
						PlayerData p = _players [i];
						if (p.player_code == kcode) {
							_players.Remove (p);
							found = true;
							RemoveMouseWithKeycode (kcode);
						

						}
					}

					//we didn't have this keycode yet!
					if (!found) {//spawn mouse
						PlayerData newPlayer = new PlayerData ();
						newPlayer.player_code = kcode;
						newPlayer.color = new Color (UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
						newPlayer.UP_alphabet = keyShow;
						_players.Add (newPlayer);
						Mouse newMouse = MouseFactory.instance.makeMouse (newPlayer);
						_mice.Add (newMouse);
					}
				}
            }
        }
    }
}


