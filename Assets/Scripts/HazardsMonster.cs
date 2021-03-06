﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardsMonster : MonoBehaviour {
	private Player player;
	private GroundEnemy groundEnemy;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
		groundEnemy = FindObjectOfType<GroundEnemy>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			player.deathAudio.Play();
			Instantiate(player.Blood, player.transform.position, player.transform.rotation);
			player.Death();
		}
		else if (other.gameObject.tag == "Hazards")
		{
			player.soundDeathWater.Play();
			Instantiate(player.SteamSmoke, transform.position, transform.rotation);
			groundEnemy.KillMe();
		}
	}
}
