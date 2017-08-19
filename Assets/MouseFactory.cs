﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFactory : SingletonMonoBehavior<MouseFactory> {
    public GameObject _mousePrefab;
    public void init()
    {

    }

    public GameObject makeMouse(PlayerData input)
    {
        Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0, 0);
        GameObject new_mouse = GameObject.Instantiate(_mousePrefab, position,Quaternion.identity);
        SpriteRenderer r = new_mouse.transform.Find("Sprite").GetComponent<SpriteRenderer>();
        TextMesh s = new_mouse.GetComponentInChildren<TextMesh>();
        //_mousePrefab = GameObject.FindGameObjectWithTag("LabelAlphabet").GetComponent<TextMesh>();
        r.color = input.color;
        s.text = input.UP_alphabet;
        //Debug.Log(s);
        return new_mouse;
    }

    public void DestoryMouse(GameObject input)
    {
        Destroy(input);
    }
}
