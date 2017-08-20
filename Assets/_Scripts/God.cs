using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour {
    public static God Static;

	public List<PlayerData> _players; 
	public int _fakePlayersAtStart = 0;


	public void Awake() {
        if (Static != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Static = this;
        }

		_players = new List<PlayerData> ();
		DontDestroyOnLoad (gameObject);
		if (_fakePlayersAtStart < 1)
			return;
		MakeFakePlayers (_fakePlayersAtStart);
	}


	public void MakeFakePlayers(int howMany) {
		_players = new List<PlayerData> ();

		for (int i = 0; i < howMany; i++) {
			PlayerData d = new PlayerData ();
			d.color = new Color (Random.value, Random.value, Random.value);
			d.player_code = (KeyCode) (i + 40);
			print ("GOD: Made fake player with code: " + d.player_code);
			d.score = Random.Range (1, 10);
			_players.Add (d);
		}
	}
}
