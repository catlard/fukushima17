﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Menu_script : MonoBehaviour
{

	public List<PlayerData> _players;

	void Start()
    {
		_players = new List<PlayerData> ();
	}

    public void Update()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))//Get what key are you pressing
        {
			if (Input.GetKeyDown (kcode)) {

				bool found = false;

				for(int i = _players.Count -1; i > -1; i--) {
					PlayerData p = _players [i];
					if (p.player_code == kcode) {
						_players.Remove (p);
						found = true;
					}
				}

				if (!found) {
					PlayerData newPlayer = new PlayerData ();
					newPlayer.player_code = kcode;
					newPlayer._color = Color.red;
					_players.Add (newPlayer);
				}


			}

        }

//        if (Input.GetMouseButtonDown(0))
//        {
//            foreach (var item in
//            data.player_code)
//            {
//                item.ToString();
//            }
//
//        }

    }
 

}


