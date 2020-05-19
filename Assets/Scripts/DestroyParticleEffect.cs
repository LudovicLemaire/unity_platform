using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleEffect : MonoBehaviour {
	private ParticleSystem thisParticleSystem;
	private Player player;
	// Use this for initialization
	void Start () {
		thisParticleSystem = GetComponent<ParticleSystem>();
		player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (thisParticleSystem.isPlaying)
		{
			return;
		}
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
