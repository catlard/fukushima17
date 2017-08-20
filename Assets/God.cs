using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : SingletonMonoBehavior<God> {

	public List<PlayerData> _players; 

	public void Start() {
		DontDestroyOnLoad (gameObject);
	}
}
