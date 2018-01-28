using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	private Collider2D coll2d;

	// Use this for initialization
	void Start () {
		coll2d = this.GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Detects collision, and if it's an obstacle, the player shall die
	void OnCollisionEnter2D(Collision2D otherColl) {
		if (otherColl.transform.parent.tag == "Obstacle" || otherColl.gameObject.tag == "Obstacle") {
			//Death animation

			FindObjectOfType<GameController>().EndGame();
		}
	}

}
