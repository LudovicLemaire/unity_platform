using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	Text fireCollected;
	private Player player;
	// Use this for initialization
	void Start () {
		fireCollected = GetComponent<Text>();
		player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		fireCollected.text = ": " + player.fireCollected;
	}
}
