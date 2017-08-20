using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFactory : SingletonMonoBehavior<MouseFactory> {
    public GameObject _mousePrefab;

    public List<GameObject> mouses;

    public void init()
    {
        mouses = new List<GameObject>();
    }

    public Mouse makeMouse(PlayerData input)
    {
        Vector3 position = new Vector3(Random.Range(-5.0f, 5.0f), 5f, 0);
        GameObject new_mouse = GameObject.Instantiate(_mousePrefab, position,Quaternion.identity);
        SpriteRenderer r = new_mouse.transform.Find("Sprite").GetComponent<SpriteRenderer>();
        TextMesh s = new_mouse.GetComponentInChildren<TextMesh>();
		Mouse m = new_mouse.GetComponent<Mouse> ();
        mouses.Add(new_mouse);

		m._myData = input;

		//_mousePrefab = GameObject.FindGameObjectWithTag("LabelAlphabet").GetComponent<TextMesh>();
        r.color = input.color;
        s.text = input.UP_alphabet;
        //Debug.Log(s);
        igroneCollsoin();

        return m;
    }

    public void igroneCollsoin()
    {
        foreach (var itemx in mouses)
        {
            foreach (var itemy in mouses)
            {
                if (itemx != itemy &&( itemx != null && itemy != null ) )
                {
                    Physics2D.IgnoreCollision(itemx.GetComponent<CircleCollider2D>(), itemy.GetComponent<CircleCollider2D>(),false);
                }
            }
        }
    }

}
