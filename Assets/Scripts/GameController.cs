using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	[SerializeField] Platformer2DUserControl Player1;
	[SerializeField] Platformer2DUserControl Player2;
	[SerializeField] ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
		scoreManager = FindObjectOfType<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Starts the EndGame Coroutine
	public void EndGame() {
		StartCoroutine ("EndGameCo");
	}

	// Coroutine that handles the end of the game
	public IEnumerator EndGameCo() {
		// Update highscore
		scoreManager.increaseScore = false;
		scoreManager.UpdateHighScore ();

		// Disable players
		Player1.enabled = false;
		Player2.enabled = false;
		Player1.GetComponent<MagicUser> ().enabled = false;
		Player2.GetComponent<MagicUser> ().enabled = false;
		Player1.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		Player2.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		Player1.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
		Player2.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;

		yield return new WaitForSeconds (0.5f);
	}
}
