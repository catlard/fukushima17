using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRandomizer : MonoBehaviour {

	public Sprite[] _arms;
	public Sprite[] _bodies;

	public void Start() {
		int rand = Random.Range (0, _arms.Length);
		int rand2 = Random.Range (0, _arms.Length);


		transform.Find ("Body").GetComponent<SpriteRenderer> ().sprite = _bodies [rand];
		transform.Find ("RightArm").GetComponent<SpriteRenderer> ().sprite = _arms [rand2];
		transform.Find ("LeftArm").GetComponent<SpriteRenderer> ().sprite = _arms [rand2];


	}

}
