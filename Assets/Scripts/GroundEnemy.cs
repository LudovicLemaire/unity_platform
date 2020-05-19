using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour {
	private Player player;
 	private int facing;
 	public float enemySpeed;
	private bool chaseIsOn;
	public int attackRange;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool onGround;
	public Transform enemySightStart;
	public Transform enemySightEnd;
	public Rigidbody2D rb;
	public int jumppower;

	

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.x > player.transform.position.x)
 		{
 			gameObject.transform.position = new Vector2(gameObject.transform.position.x - enemySpeed, gameObject.transform.position.y);
 			if (facing == 0)
 			{
 				facing = 1;
 				transform.localScale = new Vector3(1f, 1f, 1f);
 			}
 		}
 		if (gameObject.transform.position.x < player.transform.position.x)
 		{
			gameObject.transform.position = new Vector2(gameObject.transform.position.x + enemySpeed, gameObject.transform.position.y);
 			if (facing == 1)
 			{
 				facing = 0;
 				transform.localScale = new Vector3(-1f, 1f, 1f);
 			}
 		}
		if (Physics2D.Linecast(enemySightStart.position, enemySightEnd.position, whatIsGround))
		{
 			Jump();
 		}
		Debug.DrawLine(enemySightStart.position, enemySightEnd.position, Color.red);
 	}

	void FixedUpdate()
 	{
 		onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
 	}

	public void KillMe()
	{
		Destroy(gameObject);
	}

	private void Jump()
	{
		if (onGround)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumppower);
		}
	}
}
