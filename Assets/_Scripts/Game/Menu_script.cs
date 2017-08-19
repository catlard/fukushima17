using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Menu_script : MonoBehaviour
{
    public bool alphabetlock = false;
	public List<PlayerData> _players = new List<PlayerData>();
    //public GameObject test_object;
    public GameObject destory_mouse;
    public List<GameObject> RemoveMouseList ;
    public string keyShow;
    public Text test;

    PlayerData data = new PlayerData();
    void Start()
    {
        _players = new List<PlayerData> ();
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
                    Debug.Log("enter");

                }
                if( (int)kcode>=97&&(int)kcode<=122)// only alphabet
                { 
				bool found = false;
                    keyShow = kcode.ToString();
                    for (int i = _players.Count -1; i > -1; i--) {//remove the mouse
					PlayerData p = _players [i];
                        if (p.player_code == kcode) {
                            //MouseFactory.instance.DestoryMouse(p.destory_mouse );
                            _players.Remove (p);
						found = true;
                    }
				}

				if (!found) {//spawn mouse
					PlayerData newPlayer = new PlayerData ();
					newPlayer.player_code = kcode;
                    newPlayer.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
                    newPlayer.UP_alphabet = keyShow;
                    _players.Add (newPlayer);
                        GameObject newMouse = MouseFactory.instance.makeMouse(newPlayer);
                        //[
                        // Instantiate(this.test_object);
                    }
                }
            }
        }
    }

    private void DestoryMouse(PlayerData playerData, object input)
    {
        throw new NotImplementedException();
    }
}


