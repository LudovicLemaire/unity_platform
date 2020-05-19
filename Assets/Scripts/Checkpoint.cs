using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
	private Player player;
	public GameObject CheckpointParticles;
	public AudioSource soundCheckpoint;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateNewCheckpoint()
	{
		if (player.onGround && player.fireCollected > 4)
		{
			soundCheckpoint.Play();
			player.startx = player.transform.position.x;
			player.starty = player.transform.position.y;
			Instantiate(CheckpointParticles, new Vector3(player.startx, (player.starty -  0.50f), 0.60f), player.transform.rotation);
			player.fireCollected -= 5;
		}
	}
}
