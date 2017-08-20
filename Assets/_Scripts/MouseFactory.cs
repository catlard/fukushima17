﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFactory : SingletonMonoBehavior<MouseFactory> {
    public GameObject _mousePrefab;

	public List<CircleCollider2D> oldMouseColliders;

    public void init()
    {
		oldMouseColliders = new List<CircleCollider2D>();
    }

    public Mouse makeMouse(PlayerData input)
    {
<<<<<<< HEAD
		if (oldMouseColliders == null)
			init ();

        Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0, 0);
=======
        Vector3 position = new Vector3(Random.Range(-5.0f, 5.0f), 5f, 0);
>>>>>>> 9fac6f85566a060f1a23bb9b41b94cc31dbabc8b
        GameObject new_mouse = GameObject.Instantiate(_mousePrefab, position,Quaternion.identity);
        SpriteRenderer r = new_mouse.transform.Find("Sprite").GetComponent<SpriteRenderer>();
        TextMesh s = new_mouse.GetComponentInChildren<TextMesh>();
		Mouse m = new_mouse.GetComponent<Mouse> ();

		m._myData = input;

		//_mousePrefab = GameObject.FindGameObjectWithTag("LabelAlphabet").GetComponent<TextMesh>();
        r.color = input.color;
        s.text = input.UP_alphabet;
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
