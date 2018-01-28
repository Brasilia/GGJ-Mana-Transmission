﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Allows to load a scene via index
/// </summary>
public class LoadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadSceneByIndex(int index) {
		SceneManager.LoadScene (index);
	}

	public void Quit() {
		Application.Quit ();
	}
}
