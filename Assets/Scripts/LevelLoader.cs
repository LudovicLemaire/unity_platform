using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {
	public int thisLevel;
	private Selector selector;

	// Use this for initialization
	void Start () {
		selector = FindObjectOfType<Selector>();
	}
	
	// Update is called once per frame
	void Update () {
		if (selector.farthestLevel < (thisLevel - 1))
		{
			Destroy(gameObject);
			GetComponent<Renderer>().enabled = false;
		}
		else
		{
			GetComponent<Renderer>().enabled = true;
		}	
	}
}
