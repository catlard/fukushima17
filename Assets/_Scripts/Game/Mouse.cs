using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum MouseState { JUMPING, LANDED }

public class Mouse : MonoBehaviour {

	public MouseState _state;
	public Rigidbody2D _body;

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
		Vector4 data = GetRequiredForce (target);
		_body.velocity = new Vector2(data.x, data.y);



	}

	public void Update() {
		if (Input.GetMouseButtonDown (0) && _state == MouseState.LANDED) {
			JumpToTarget ("CatBelly");
			_state = MouseState.JUMPING;
		}
	}

	private Vector4 GetRequiredForce(GameObject target) {

		Vector2 finish = PhysicsHelpers.GetParableInitialVelocity (transform.position, target.transform.position);
		return new Vector4 (finish.x, finish.y, 0,0);
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

			print (possibleTarget.transform.name + " " + dist);
			if (dist < bestDist) {
				bestDist = dist;
				target = possibleTarget;
			}
		}

		return target;

	}

	public void OnCollisionEnter2D(Collision2D c) {
		print (c.gameObject.tag);
		string tag = c.gameObject.tag;
		if (tag == "Floor") {
			_state = MouseState.LANDED;
			_body.bodyType = RigidbodyType2D.Kinematic;
			_body.velocity = Vector2.zero;
			_body.transform.eulerAngles = Vector3.zero;
			_body.angularVelocity = 0;
		} else if(tag == "CatBelly") {
			print ("GOT THERE");
			JumpToTarget ("Floor");
		}


	}

}
