using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DestroyObstacle() {
		//Play animation?
		Destroy (this.gameObject);
	}
}
