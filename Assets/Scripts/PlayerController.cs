using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	//Player
	private Rigidbody rb;
	public float speed;
	public Player player;

	//UI
	public GameObject playCanvas;
	public GameObject gameOverCanvas;

	//Level
	public Text level1Text;
	public Text Level2Text;
	public GameObject level1;
	public GameObject openWall1;
	public GameObject level2;
	public GameObject openWall2;
	public GameObject bridge2;
	public GameObject closeWall2;
	public GameObject level3;
	public GameObject bridge3;
	public GameObject closeWall3;

	//HUD
	public Text scoreText;
	public Text healthText;

	//Counter
	public Text counterText;
	public float counter;
	public TimeSpan timePlaying;
	public string timePlayingStr;

	//Jump
	public int forceConst = 4;
	private bool contactWithGround = true;


	private void Start()
	{
		player = new Player();
		rb = GetComponent<Rigidbody>();
		scoreText.text = "";
		healthText.text = "Health: " + player.Health;
		counterText.text = "Count: 0";
		level1Text.text = "";
		Level2Text.text = "";
		playCanvas.SetActive(true);
		gameOverCanvas.SetActive(false);
		SetScoreText();
	}

	private void Update()
	{

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (contactWithGround)
			{
				rb.AddForce(0, forceConst, 0, ForceMode.Impulse);
			}
		}
		counter += Time.deltaTime;
		timePlaying = TimeSpan.FromSeconds(counter);
		timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
		counterText.text = timePlayingStr;
	}

	private void FixedUpdate()
	{
		var moveHorizontal = Input.GetAxis("Horizontal");
		var moveVertical = Input.GetAxis("Vertical");

		var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);

		if (player.Score == 8)
		{
			openWall1.SetActive(false);
			level2.SetActive(true);
		}

		if (player.Score >= 9)
		{
			openWall2.SetActive(false);
			level3.SetActive(true);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Damage50"))
		{
			var health = player.TakeDamage(50);
			healthText.text = "Health: " + player.Health;
			if (health == 0)
			{
				//TODO DIE
				healthText.text = "Health: 0";
				Debug.Log("Dead");
			}
		}
		else if (collision.gameObject.CompareTag("Ground"))
		{
			contactWithGround = true;
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			contactWithGround = false;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			player.IncreaseScore();
			SetScoreText();
		}
		else if (other.gameObject.CompareTag("LevelTrigger"))
		{
			other.gameObject.SetActive(false);

			switch (player.Level)
			{
				case 0:
					closeWall2.SetActive(true);
					level1.SetActive(false);
					bridge2.SetActive(false);
					break;
				case 1:
					closeWall3.SetActive(true);
					level2.SetActive(false);
					bridge3.SetActive(false);
					break;
				case 2:
					break;
			}

			player.NextLevel();
		}
	}

	private void SetScoreText()
	{
		scoreText.text = "Count: " + player.Score;
		if (player.Score >= 8)
		{
			level1Text.text = "Stage 1 clear!";
			Destroy(level1Text, 2);
		}

		scoreText.text = "Count: " + player.Score;
		if (player.Score >= 9)
		{
			Level2Text.text = "Stage 2 clear!";
			Destroy(Level2Text, 2);
		}
	}
}
