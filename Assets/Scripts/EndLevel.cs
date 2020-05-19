using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {
	public string nextLevel;
	public int levelValue;
	public AudioSource soundTeleport;
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
			soundTeleport.Play();
			SaveLevel(levelValue);
			SaveFireCollected(player.fireCollected);
			SceneManager.LoadScene(nextLevel);
		}
	}

	public void SaveLevel(int level)
	{
		if (level > PlayerPrefs.GetInt("farthestLevel"))
			PlayerPrefs.SetInt("farthestLevel", level);
	}

	public void SaveFireCollected(int fireCollected)
	{
		PlayerPrefs.SetInt("totalFireCollected", fireCollected);
	}
}
