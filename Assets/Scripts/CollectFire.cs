using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFire : MonoBehaviour {
	public GameObject Spark;
	private Player player;
	public AudioSource collectFireAudio;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			collectFireAudio.Play();
			player.fireCollected++;
			Instantiate(Spark, gameObject.transform.position, gameObject.transform.rotation);
			Destroy(gameObject);
		}
	}
}
