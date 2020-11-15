using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	//UI
	public GameObject playCanvas;
	public GameObject gameOverCanvas;

	//HUD
	public Text scoreText;
	public Text level1Text;
	public Text Level2Text;

	//Counter
	public Text counterText;
	public float counter;
	public TimeSpan timePlaying;
	public string timePlayingStr;

	//Level
	public GameObject level1;
	public GameObject openWall1;
	public GameObject level2;
	public GameObject bridge2;
	public GameObject openWall2;
	public GameObject closeWall2;
	public GameObject level3;
	public GameObject bridge3;
	public GameObject closeWall3;

	//Damage
	public Transform greenHealthBar;
	//public Transform redHealthBar;
	//public GameObject redHealt;

	//Player
	public PlayerController player;


	// Start is called before the first frame update
	private void Start()
	{
		scoreText.text = "";
		counterText.text = "Count: 0";
		level1Text.text = "";
		Level2Text.text = "";
		playCanvas.SetActive(true);
		gameOverCanvas.SetActive(false);
		SetScoreText();
	}

	// Update is called once per frame
	private void Update()
	{
		counter += Time.deltaTime;
		timePlaying = TimeSpan.FromSeconds(counter);
		timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
		counterText.text = timePlayingStr;
	}

	private void FixedUpdate()
	{
		if (player.player.Score == 8)
		{
			openWall1.SetActive(false);
			level2.SetActive(true);
		}

		if (player.player.Score >= 9)
		{
			openWall2.SetActive(false);
			level3.SetActive(true);
		}
	}

	private void SetScoreText()
	{
		scoreText.text = "Score: " + player.player.Score;
		if (player.player.Score >= 8)
		{
			level1Text.text = "Stage 1 clear!";
			Destroy(level1Text, 2);
		}

		scoreText.text = "Score: " + player.player.Score;
		if (player.player.Score >= 9)
		{
			Level2Text.text = "Stage 2 clear!";
			Destroy(Level2Text, 2);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			var panelRectTransform = greenHealthBar.GetComponent<RectTransform>();
			player.player.RegenerateHealth(other.GetComponent<PickUp>().HealthRegeneration);
			panelRectTransform.sizeDelta = new Vector2((player.player.Health * 2), 15);
			other.gameObject.SetActive(false);
			player.player.IncreaseScore();
			// SetScoreText();
		}
		else if (other.gameObject.CompareTag("LevelTrigger"))
		{
			other.gameObject.SetActive(false);

			switch (player.player.Level)
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

			player.player.NextLevel();
		}
	}
}