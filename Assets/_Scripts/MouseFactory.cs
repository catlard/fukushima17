using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFactory : SingletonMonoBehavior<MouseFactory> {
	public GameObject _mousePrefab;
	public GameObject[] _mouseHatPrefab = new GameObject[5] ;
	//	public GameObject SpawnThePipe;
	public Sprite[] _hats = new Sprite[4];

	public List<CircleCollider2D> oldMouseColliders;

	public void init()
	{
		oldMouseColliders = new List<CircleCollider2D>();
	}

	public Mouse makeMouse(PlayerData input)
	{
		if (oldMouseColliders == null)
			init ();

		Vector3 position = new Vector3(Random.Range(-7.0f, 7.0f),8f, 0);
		//        GameObject SpawnPipe = GameObject.Instantiate(SpawnThePipe, new Vector3(position.x, 0, position.z), Quaternion.identity);//, position, Quaternion.identity);
		GameObject new_mouse = GameObject.Instantiate(_mousePrefab, new Vector3(position.x,position.y,position.z),Quaternion.identity);

		SpriteRenderer r = new_mouse.transform.Find("Sprite").GetComponent<SpriteRenderer>();
		TextMesh s = new_mouse.GetComponentInChildren<TextMesh>();
		Mouse m = new_mouse.GetComponent<Mouse> ();

		m._myData = input;

		//_mousePrefab = GameObject.FindGameObjectWithTag("LabelAlphabet").GetComponent<TextMesh>();
		r.color = input.color;
		s.text = input.UP_alphabet;

		switch (input.hatType) {
		case HatType.Gentlemen:
			m._hat.sprite = _hats [0];
			break;
		case HatType.Roma:
			m._hat.sprite = _hats [1];
			break;
		case HatType.Flower:
			m._hat.sprite = _hats [2];
			break;
		case HatType.Party:
			m._hat.sprite = _hats [3];
			break;
		}

		//Debug.Log(s);
		IgnoreCollisions(m.GetComponent<CircleCollider2D>());

		return m;
	}

	public void IgnoreCollisions(CircleCollider2D newCollider)
	{
		foreach (CircleCollider2D c in oldMouseColliders) {
			if (c != null && newCollider != c)
				Physics2D.IgnoreCollision (c, newCollider);
		}

		oldMouseColliders.Add(newCollider);

	}

}
