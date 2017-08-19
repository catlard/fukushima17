using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Menu_script : MonoBehaviour
{
    PlayerData data = new PlayerData();
    void Start()
    {
        data.player_code = new List<KeyCode>();
    }

    public void Update()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))//Get what key are you pressing
        {
            if (Input.GetKeyDown(kcode))
            {
                //print(kcode);
                data.player_code.Add(kcode);
                
                //Debug.Log(PlayerData.Static.player_code);
                //Debug.Log("KeyCode down: " + kcode);

            }
                //Debug.Log(kcode);
				data.player_code = kcode;

            }

        if (Input.GetMouseButtonDown(0))
        {
            foreach (var item in
            data.player_code)
            {
                item.ToString();
            }

        }

    }
    /*public void AllPlayerKey()
    {
        KeyData.Add(new PlayerData() { })
    }*/

}


