using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Rigidbody2D rb;
	public int movespeed;
	public int jumppower;
	public int climbladderpower;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public LayerMask whatIsWater;
	public LayerMask whatIsLadder;
	public bool onGround;
	private bool onWater;
	private bool onLadder;
	public float distance;
	private Animator anim;
	private int facing;
	public int fireCollected;
	public AudioSource jumpAudio;
	public AudioSource footStepAudio;
	private bool canJump;
	public bool moveRight;
	public bool moveLeft;
	public float startx;
	public float starty;
	public GameObject Blood;
	public GameObject SteamSmoke;
	public AudioSource deathAudio;
	public AudioSource soundDeathWater;
	public bool waterDeath;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		facing = 1;
		canJump = true;
		startx = transform.position.x;
		starty = transform.position.y;
		fireCollected = PlayerPrefs.GetInt("totalFireCollected");
	}
	
	void FixedUpdate()
	{
		onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,
		whatIsGround);
		onWater = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,
		whatIsWater);
		onLadder = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
	}

	// Update is called once per frame
	void Update () {
		
		if (moveLeft || Input.GetKey(KeyCode.LeftArrow))
		{
			if (onGround)
				footStepAudio.UnPause();
			else
				footStepAudio.Pause();
			rb.velocity = new Vector2(-movespeed, rb.velocity.y);
			anim.SetBool("Walking", true);
			if (facing == 1)
			{
				transform.localScale = new Vector3(-1f, 1f, 1f);
				facing = 0;
			}
		}
		else if (moveRight || Input.GetKey(KeyCode.RightArrow))
		{
			if (onGround)
				footStepAudio.UnPause();
			else
				footStepAudio.Pause();
			rb.velocity = new Vector2(movespeed, rb.velocity.y);
			anim.SetBool("Walking", true);
			if (facing == 0)
			{
				transform.localScale = new Vector3(1f, 1f, 1f);
				facing = 1;
			}
		}
		else
		{
			footStepAudio.Pause();
			anim.SetBool("Walking", false);
		}
		if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
		{
			Jump();
		}
		else
			canJump = true;
	}

	public void Jump()
	{
		if (onGround && canJump)
		{
			jumpAudio.Play();
			rb.velocity = new Vector2(rb.velocity.x, jumppower);
			canJump = false;
		}
		else if (onWater)
			rb.velocity = new Vector2(rb.velocity.x, jumppower - 1.5f);
		else if (onLadder)
			rb.velocity = new Vector2(rb.velocity.x, climbladderpower);
	}

	public void SuperJump()
	{
		jumpAudio.Play();
		rb.velocity = new Vector2(rb.velocity.x, jumppower * 1.5F);
	}

	public void Death()
	{
		StartCoroutine("respawndelay");
	}

	public IEnumerator respawndelay()
	{
		enabled = false;
		GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds(2);
		transform.position = new Vector3(startx, starty, 0.5F);
		GetComponent<Renderer>().enabled = true;
		enabled = true;
	}
}
