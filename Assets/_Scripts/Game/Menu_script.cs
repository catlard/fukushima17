using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Menu_script : MonoBehaviour
{
<<<<<<< HEAD
    public bool alphabetlock = false;
	public List<PlayerData> _players;
    public GameObject test_object;

=======
    PlayerData data = new PlayerData();
>>>>>>> 0cf2bb9bb665de4924a12d39676e10aeb95d3253
    void Start()
    {
        data.player_code = new List<KeyCode>();
    }

    public void Update()
    {

        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))//Get what key are you pressing
        {
<<<<<<< HEAD
			if (Input.GetKeyDown (kcode))
           {
                if((int)kcode==27)//get escape key
                {
                    Debug.Log("esc");
                }

                if((int)kcode==13)//get enter key
                {
                    Debug.Log("enter");

                }
                if( (int)kcode>97&&(int)kcode<122)// only alphabet
                { 
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

=======
            if (Input.GetKeyDown(kcode))
            {
                //print(kcode);
                data.player_code.Add(kcode);
                
                //Debug.Log(PlayerData.Static.player_code);
                //Debug.Log("KeyCode down: " + kcode);
                /*if (kcode!= PlayerData.Static.player_code)
                {
                    Debug.Log("19");
                }*/

            }
            }

        if (Input.GetMouseButtonDown(0))
        {
            foreach (var item in data.player_code)
            {
                item.ToString();
>>>>>>> 0cf2bb9bb665de4924a12d39676e10aeb95d3253
            }

        }

    }
<<<<<<< HEAD

=======
    /*public void AllPlayerKey()
    {
        KeyData.Add(new PlayerData() { })
    }*/
>>>>>>> 0cf2bb9bb665de4924a12d39676e10aeb95d3253

}


