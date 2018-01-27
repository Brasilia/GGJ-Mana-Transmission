using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Magic projectile.
/// </summary>
public class MagicProjectile : MonoBehaviour {

	[SerializeField] private float speed; // Speed with which the projectile is fired.

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().AddForce (new Vector2(speed, 0));

		// The projectile is destroyed after some time
		Destroy (this.gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
	}
		

	void OnCollisionEnter2D(Collision2D coll) {
		// In case an obstacle is hit, calls the method to destroy it
		if (coll.gameObject.tag == "Obstacle") {
			coll.gameObject.SendMessage ("DestroyObstacle");
		}

		// Destroy the projectile if it hits something
		Destroy (this.gameObject);
	}
}