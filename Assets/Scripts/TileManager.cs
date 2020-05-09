using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public GameObject[] tilePrefabs;
	private Transform playerTransform;
	private float spawnZ = -6.0f;
	private float tileLength = 10.0f;
	private int noTilesOnScreen = 3;
	private float safeZone = 15.0f;

	private List<GameObject> activeTiles;

	// Use this for initialization
	void Start () {
		activeTiles = new List<GameObject> ();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		for (int i = 0; i < noTilesOnScreen; i++) {
			spawnTile ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTransform.position.z - safeZone > (spawnZ - noTilesOnScreen * tileLength)) {
			spawnTile ();
			deleteTile ();
		}
	}

	private void spawnTile(int prefabIndex = -1) {
		GameObject go;
		go = Instantiate (tilePrefabs [0]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
		activeTiles.Add (go);

	}

	private void deleteTile() {
		Destroy (activeTiles [0]);
		activeTiles.RemoveAt (0);
	}

}
