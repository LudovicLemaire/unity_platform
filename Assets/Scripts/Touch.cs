using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {
	private Player player;
	private Checkpoint checkpoint;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
		checkpoint = FindObjectOfType<Checkpoint>();
	}
	
	public void PressLeftArrow()
	{
		player.moveLeft = true;
		player.moveRight = false;
	}

	public void PressRightArrow()
	{
		player.moveLeft = false;
		player.moveRight = true;
	}

	public void ReleaseLeftArrow()
	{
		player.moveLeft = false;
	}

	public void ReleaseRightArrow()
	{
		player.moveRight = false;
	}

	public void Jump()
	{
		player.Jump();
	}

	public void Checkpoint()
	{
		checkpoint.CreateNewCheckpoint();
	}
}
