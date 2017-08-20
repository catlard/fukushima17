using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HatType {
	Gentlemen,
	Roma,
	Flower,
	Party
}


[System.Serializable]
public struct PlayerData
{
	public int score;
	public KeyCode player_code;// press down keycode list
    public Color color;
	public HatType hatType;
    public string UP_alphabet;

}


