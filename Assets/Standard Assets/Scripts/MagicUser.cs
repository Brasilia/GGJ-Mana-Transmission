﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MagicUser : MonoBehaviour {

	enum ElementalType {
		Ice=0,
		Fire=1
	}

	[SerializeField] private ElementalType elementalType;
	[SerializeField] private Transform projectileSpawn;
	[SerializeField] private GameObject magicProjectile;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Spawns the magic projectile on the correct spawn position
	public void Fire() {
		GameObject projectile = (GameObject) Instantiate (magicProjectile, projectileSpawn.position, projectileSpawn.rotation);
	}
}