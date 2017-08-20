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
    public GameObject SpawnThePipe;
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
							SoundLibrary.instance.PlaySound(new SoundParams("mouse_dead", .25f, .25f, 1));

						}
					}

					//we didn't have this keycode yet!
					if (!found) {//spawn mouse
						SoundLibrary.instance.PlaySound(new SoundParams("mouse_" + UnityEngine.Random.Range(1, 6), .25f, 1, 1));
                        //GameObject SpawnPipe = GameObject.Instantiate(SpawnThePipe, new Vector3(position.x, 0, position.z), Quaternion.identity);
                        PlayerData newPlayer = new PlayerData ();
						newPlayer.player_code = kcode;
						newPlayer.color = new Color (UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
						newPlayer.UP_alphabet = keyShow;
						_players.Add (newPlayer);
						Mouse newMouse = MouseFactory.instance.makeMouse (newPlayer);
						_mice.Add (newMouse);
					}
				}

				if (_players.Count > 1) {
					GameObject.Find ("God").GetComponent<God> ()._players = _players; // tell god about your problems;
					CountdownManager.instance.StartCountdown ();
				} else {
					CountdownManager.instance.StopCountdown ();
				}

            }


        }
    }
}


