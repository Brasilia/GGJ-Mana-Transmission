using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		transform.position = player.transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position; 
	}

	void OnTriggerExit2D(Collider2D other){
		Destroy (other.gameObject);
	}
}
