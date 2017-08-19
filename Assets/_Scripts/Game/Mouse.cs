using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum MouseState { JUMPING, LANDED }

public class Mouse : MonoBehaviour {

	public MouseState _state;
	public Rigidbody2D _body;

	public CatBellyView _lastBelly;

	public void Start() {
		Init ();
	}

	public void Init() {
		_state = MouseState.LANDED;
		_body = GetComponent<Rigidbody2D> ();
	}


	public void JumpToTarget(string tagName) {
		_body.bodyType = RigidbodyType2D.Dynamic;
		GameObject target = FindNextTarget (tagName);
		Vector2 data = GetRequiredForce (target);

		//bouncing off cat belly
		if (tagName == "Floor") {
			data *= _lastBelly.GetPower ();
			print ("Mouse landed on belly with " + _lastBelly.GetPower () + " % power.");
		}


		_body.velocity = data;
	}

	public void Update() {
		if (Input.GetMouseButtonDown (0) && _state == MouseState.LANDED) {
			JumpToTarget ("CatBelly");
			_state = MouseState.JUMPING;
		}
	}

	private Vector2 GetRequiredForce(GameObject target) {

		Vector2 finish = PhysicsHelpers.GetParableInitialVelocity (transform.position, target.transform.position);
		return finish;
	}

	//find the next gameobject on the x axis with a tag "CatBelly".
	private GameObject FindNextTarget(string tagName) {
		GameObject[] targets = GameObject.FindGameObjectsWithTag (tagName);
		if (targets.Length == 0)
			print ("ERROR: No obj with tag: " + tagName + " found.");
		GameObject target = targets [0];
		float bestDist = Mathf.Infinity;
		foreach (GameObject possibleTarget in targets) {
			float dist = possibleTarget.transform.position.x - transform.position.x;

			if (dist < 0)
				continue;

			if (dist < bestDist) {
				bestDist = dist;
				target = possibleTarget;
			}
		}

		return target;

	}

	public void OnCollisionEnter2D(Collision2D c) {

		string tag = c.gameObject.tag;
		if (tag == "Floor") {
			_state = MouseState.LANDED;
			_body.bodyType = RigidbodyType2D.Kinematic;
			_body.velocity = Vector2.zero;
			_body.transform.eulerAngles = Vector3.zero;
			_body.angularVelocity = 0;
		} else if(tag == "CatBelly") {
			_lastBelly = c.gameObject.GetComponent<CatBellyView> ();
			JumpToTarget ("Floor");
		}


	}

}
