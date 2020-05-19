using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	float randX;
	Vector2 whereToSpawn;
	public float spawnRate;
	float nextSpawn;

	// Use this for initialization
	void Start () {
		spawnRate = 2f;
		nextSpawn = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn)
		{
			nextSpawn = Time.time + spawnRate;
			randX = Random.Range(transform.position.x,transform.position.x);
			whereToSpawn = new Vector2 (randX, transform.position.y);
			Instantiate (enemy, whereToSpawn, Quaternion.identity);
		}
	}
}
