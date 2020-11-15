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
	private string timePlayingStr;

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

	public string TimePlayingStr => timePlayingStr;


	// Start is called before the first frame update
	private void Start()
	{
		scoreText.text = "Score: 0";
		counterText.text = "";
		level1Text.text = "";
		Level2Text.text = "";
		playCanvas.SetActive(true);
		gameOverCanvas.SetActive(false);
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

	public void SetScoreText()
	{
		scoreText.text = "Score: " + player.player.Score;
		if (player.player.Score >= 8)
		{
			level1Text.text = "Stage 1 clear!";
			Destroy(level1Text, 2);
		}

		if (player.player.Score >= 9)
		{
			Level2Text.text = "Stage 2 clear!";
			Destroy(Level2Text, 2);
		}
	}
}