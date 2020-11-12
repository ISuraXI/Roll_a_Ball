using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public Text scoreText;
	public Text level1Text;
	public Text Level2Text;
	public Text counterText;
	public GameObject playCanvas;
	public GameObject gameOverCanvas;
	private Rigidbody rb;
	public int score;
	public float counter;
	public GameObject level1;
	public GameObject openWall1;
	public GameObject level2;
	public GameObject openWall2;
	public GameObject bridge2;
	public GameObject closeWall2;
	public GameObject level3;
	public GameObject bridge3;
	public GameObject closeWall3;
	public TimeSpan timePlaying;


	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		score = 0;
		scoreText.text = "";
		counterText.text = "Count: 0";
		level1Text.text = "";
		Level2Text.text = "";
		playCanvas.SetActive(true);
		gameOverCanvas.SetActive(false);
		SetScoreText();
	}

	private void Update()
	{
		counter += Time.deltaTime;
		timePlaying = TimeSpan.FromSeconds(counter);
		var timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
		counterText.text = timePlayingStr;
	}

	private void FixedUpdate()
	{
		var moveHorizontal = Input.GetAxis("Horizontal");
		var moveVertical = Input.GetAxis("Vertical");

		var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);

		if (score >= 8)
		{
			openWall1.SetActive(false);
			level2.SetActive(true);
		}

		if (score >= 9)
		{
			openWall2.SetActive(false);
			level3.SetActive(true);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			score++;
			SetScoreText();
		}

		if (other.gameObject.CompareTag("Trigger2"))
		{
			closeWall2.SetActive(true);
			level1.SetActive(false);
			bridge2.SetActive(false);
		}

		if (other.gameObject.CompareTag("Trigger3"))
		{
			closeWall3.SetActive(true);
			level2.SetActive(false);
			bridge3.SetActive(false);
		}
	}

	private void SetScoreText()
	{
		scoreText.text = "Count: " + score.ToString();
		if (score >= 8)
		{
			level1Text.text = "Stage 1 clear!";
			Destroy(level1Text, 2);
		}

		scoreText.text = "Count: " + score.ToString();
		if (score >= 9)
		{
			Level2Text.text = "Stage 2 clear!";
			Destroy(Level2Text, 2);
		}
	}
}