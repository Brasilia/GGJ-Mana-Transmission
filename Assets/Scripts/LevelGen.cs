using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelGen : MonoBehaviour {

	public float dX = 2.0f;
	public float dY = 1.0f;
	public float maxHeight = 3.0f;
	public float minHeight = 0.0f;
	public float forwardSize = 20.0f;
	public float ceilingHeight = 10.0f;
	[Range(0.0f, 1.0f)]
	public float hazard;
	public float holeStartX = 30f;
	public float hazardStartX = 50f;
	public Transform parent;
	private float startX;


	public GameObject player;
	public GameObject platPrefab;
	public GameObject platPrefabUp;
	public GameObject platPrefabDown;
	public GameObject holePrefab;
	public GameObject obstacle;

	private float lastX = -1.0f;
	public float curY = 1.0f;
	private float offsetY;

	private int lastLevelChange = 0; //  0: straight, 1: up, 2: down, 3: buraco

	private float[,] probMatrix = new float[,] { { 60, 15, 15 }, { 45, 35, 10 }, { 40, 25, 25 }, { 25, 25, 25 } };

	// Use this for initialization
	void Start () {
		startX = player.transform.position.x;
		offsetY = player.transform.position.y - 5;
	}
	
	// Update is called once per frame
	void Update () {
		while(lastX < player.transform.position.x + forwardSize){ // não há plataformas suficientes à frente
			CreatePlatform();
			lastX += dX;
		}
	}

	private void CreatePlatform(){
		//Escolhe plataforma a instanciar
		float rand = Random.Range(0.0f, 100.0f);
		GameObject prefab;

		int lastLevelChangeAux = lastLevelChange;


		if (rand < probMatrix[lastLevelChange, 0]) { // reto
			prefab = platPrefab;
			lastLevelChange = 0;
		} else if (rand < probMatrix[lastLevelChange,0] + probMatrix[lastLevelChange,1]){ // sobe
			if (curY >= maxHeight){ // altura é máxima
				CreatePlatform ();
				return;
			} else {
				prefab = platPrefabUp;
				lastLevelChange = 1;
			}
		} else if (rand < probMatrix[lastLevelChange,0] + probMatrix[lastLevelChange,1] + probMatrix[lastLevelChange,2]){ // desce
			if (curY <= minHeight){ // altura é mínima
				CreatePlatform();
				return;
			} else {
				prefab = platPrefabDown;
				curY--;
				lastLevelChange = 2;
			}
		} else { // buraco
			if (lastX < holeStartX + startX){
				CreatePlatform ();
				return;
			}
			lastLevelChange = 3;
			prefab = null;
		}
		if (lastLevelChangeAux == 1){
			curY++;
		}
		//Cria plataforma
		if (prefab != null){
			GameObject plat = (GameObject)Instantiate(prefab, new Vector2(lastX+dX, curY + offsetY), Quaternion.identity);
			plat.transform.parent = parent;
			if (lastLevelChange == 0){
				//Obstacle
				if (Random.Range (0.0f, 1.0f) < hazard && lastX > hazardStartX + startX) {
					GameObject obst = Instantiate (obstacle, plat.transform);
					obst.transform.localPosition.Set (0, 0.5f, 0);
				}
			}
		} else { // buraco
			prefab = holePrefab;
			GameObject plat = (GameObject)Instantiate(prefab, new Vector2(lastX+dX, offsetY-5), Quaternion.identity);
			plat.transform.parent = parent;
		}
		//Cria teto
		GameObject ceiling = (GameObject)Instantiate(platPrefab, new Vector2(lastX+dX, offsetY+ceilingHeight), Quaternion.identity);
		ceiling.transform.parent = parent;	
			//Obstacle
		if (Random.Range(0.0f, 1.0f) < hazard && lastX >200f){
			GameObject obst2 = Instantiate(obstacle, ceiling.transform);
			obst2.transform.localPosition.Set (0, 0.5f, 0);
		}

		ceiling.transform.localScale = new Vector2 (1, -1);

	}

}
