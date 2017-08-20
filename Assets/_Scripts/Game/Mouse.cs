using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum MouseState { JUMPING, LANDED }

public class Mouse : MonoBehaviour {

	public MouseState _state;
	private Rigidbody2D _body;
	private Collider2D _collider;
	private SpriteRenderer _mouseSprite;
	public PlayerData _myData;

	private CatBellyView _lastBelly;

	public Sprite _sit;
	public Sprite _up;
	public Sprite _down;
	public Sprite _top;

	private bool _animatingTop = false;


	public void Start() {
		Init ();
	}

	public void Init() {
		
		_mouseSprite = transform.Find ("Sprite").GetComponent<SpriteRenderer> ();
		_collider = GetComponent<Collider2D> ();
		_state = MouseState.LANDED;
		_body = GetComponent<Rigidbody2D> ();

		_mouseSprite.sprite = _sit;
	}


	public void JumpToTarget(string tagName) {
		_body.bodyType = RigidbodyType2D.Dynamic;
		GameObject target = FindNextTarget (tagName);
		Vector2 data = GetRequiredForce (target);

//		bouncing off cat belly
		if (tagName == "Floor") {
			float power = _lastBelly.GetPower ();

			if (power > .9f)
				power = 1;

			data *= power;
			print ("Mouse landed on belly with " + _lastBelly.GetPower () + " % power.");
		}

		_mouseSprite.sprite = _up;
			
		_body.velocity = data;
	}

	public void Update() {

		string layer = LayerMask.LayerToName (gameObject.layer);

		if (layer == "Default" && _body.velocity.y > .01f) {
			gameObject.layer = LayerMask.NameToLayer ("UpwardMouse");
		} else if (layer == "UpwardMouse" && _body.velocity.y < -.01f) {
			gameObject.layer = LayerMask.NameToLayer ("Default");
		}

//		print (_state);
//		print (_animatingTop);
//		print (_body.velocity.y);
//		print ("0000000");
//
		if (_body.velocity.y < .5f && _body.velocity.y > 0 && !_animatingTop &&  _state == MouseState.JUMPING) {
			print ("DID TOP ANIM");
			StopCoroutine ("DoTopAnim");
			StartCoroutine ("DoTopAnim");
		}
			
		if (Input.GetKeyDown(_myData.player_code) && _state == MouseState.LANDED)
        {
            JumpToTarget("CatBelly");
            _state = MouseState.JUMPING;
        }


	}

	private IEnumerator DoTopAnim() {
		if (_animatingTop)
			yield break;
		_animatingTop = true;
		_mouseSprite.sprite = _top;
		yield return new WaitForSeconds(UnityEngine.Random.Range(.25f, .4f));
		_mouseSprite.sprite = _down;
		_animatingTop = false;
	}

	private Vector2 GetRequiredForce(GameObject target) {
		Vector3 myPos = transform.position;
		myPos.y -= (_mouseSprite.bounds.extents.y) * 1f;
//		myPos.x = GetComponent<SpriteRenderer> ().bounds.extents.x;
		Vector2 finish = PhysicsHelpers.GetParableInitialVelocity (myPos, target.transform.position);
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

    void OnLanded()
    {
		StopCoroutine ("DoTopAnim");
		_animatingTop = false;
        _state = MouseState.LANDED;
        _body.bodyType = RigidbodyType2D.Kinematic;
        _body.velocity = Vector2.zero;
        _body.transform.eulerAngles = Vector3.zero;
        _body.angularVelocity = 0;
		_mouseSprite.sprite = _sit;
    }

	public void OnCollisionEnter2D(Collision2D c) {

		Physics2D.IgnoreCollision (_collider, c.gameObject.GetComponent<Collider2D> ());

		string tag = c.gameObject.tag;
		if (tag == "Floor") {
            OnLanded();

        } else if(tag == "CatBelly") {
			_lastBelly = c.gameObject.GetComponent<CatBellyView> ();
			JumpToTarget ("Floor");
		}


	}

}
