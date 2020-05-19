using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHazards : MonoBehaviour {
	private Player player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			player.soundDeathWater.Play();
			Instantiate(player.SteamSmoke, player.transform.position, player.transform.rotation);
			player.Death();
		}
	}
}
