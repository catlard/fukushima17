using System.Collections;
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
		if (oldMouseColliders == null)
			init ();

        Vector3 position = new Vector3(Random.Range(-7.0f, 7.0f),8f, 0);
        GameObject new_mouse = GameObject.Instantiate(_mousePrefab, new Vector3(position.x,position.y,position.z),Quaternion.identity);
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
