using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Menu_script : MonoBehaviour
{
    public Text test_Text;
    public KeyCode player_code; // press down keycode
    public List<PlayerData> data= new List<PlayerData>();
    public void Update()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))//Get what key are you pressing
        {
            if (Input.GetKeyDown(kcode))
            {
                //Debug.Log("KeyCode down: " + kcode);
                //Debug.Log(kcode);
                player_code = kcode;
            }
        }
    }
    
    //DetectKeyPress();
}

        /*public void DetectKeyPress()
        {
            if (Input.anyKeyDown)
            {
                Debug.Log("keypress");
            }
        }*/

