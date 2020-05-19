using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLevelUnknow : MonoBehaviour {
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
			GetComponent<Renderer>().enabled = true;

		}
		else
		{
			Destroy(gameObject);
			GetComponent<Renderer>().enabled = false;
		}	
	}
}
