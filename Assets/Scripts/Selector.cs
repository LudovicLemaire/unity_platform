using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector : MonoBehaviour {
	public bool moveLeft;
	public bool moveRight;
	private int nbLevels;
	private string levelChoice;
	public AudioSource backgroundMusic;
	public AudioSource sceneSelectedSound;
	public AudioSource selectRightSound;
	public AudioSource selectLeftSound;
	public AudioSource selectWrongSound;
	public AudioSource selectErrorSound;
	public int farthestLevel;

	// Use this for initialization
	void Start () {
		backgroundMusic.Play();
		nbLevels = 3;
		farthestLevel = PlayerPrefs.GetInt("farthestLevel");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > 0 && (moveLeft || Input.GetKeyDown(KeyCode.LeftArrow)))
		{
			selectLeftSound.Play();
			transform.position = new Vector2(transform.position.x - 5.5F, transform.position.y);
			moveLeft = false;
		}
		else if (transform.position.x < ((nbLevels - 1) * 5) && (moveRight || Input.GetKeyDown(KeyCode.RightArrow)))
		{
			selectRightSound.Play();
			transform.position = new Vector2(transform.position.x + 5.5F, transform.position.y);
			moveRight = false;
		}
		else if ((transform.position.x > ((nbLevels - 1) * 5) && (moveRight || Input.GetKeyDown(KeyCode.RightArrow))) || transform.position.x == 0  && (moveLeft || Input.GetKeyDown(KeyCode.LeftArrow)))
			selectWrongSound.Play();
		if (Input.GetKey(KeyCode.Space))
		{
			Select();
		}
	}
	
	public void Select()
	{
		if (levelChoice != "Level Unknow")
		{
			backgroundMusic.Pause();
			sceneSelectedSound.Play();
			SceneManager.LoadScene(levelChoice);
		}
		else
		{
			selectErrorSound.Play();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		levelChoice = other.name;
	}
}
