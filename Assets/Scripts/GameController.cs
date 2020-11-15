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
	private float counter;
	private TimeSpan timePlaying;
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
	private int level;

	//GameOver
	public Text gameOverScoreText;
	public Text gameOverCounterText;

	//Damage
	public Transform greenHealthBar;
	//public Transform redHealthBar;
	//public GameObject redHealt;

	//Player
	public Player player;

	public int Level => level;


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

	public void SetScoreText() //TODO implement in a generic way
	{
		scoreText.text = "Score: " + player.Score;
		if (player.Score >= 8) //TODO check for visible amount
		{
			openWall1.SetActive(false);
			level2.SetActive(true);
			level1Text.text = "Stage 1 clear!";
			Destroy(level1Text, 2);
		}
		else if (player.Score >= 9)
		{
			openWall2.SetActive(false);
			level3.SetActive(true);
			Level2Text.text = "Stage 2 clear!";
			Destroy(Level2Text, 2);
		}
	}

	public void IncreaseLevel()
	{
		switch (level) //TODO implement in a generic way
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
		}

		level++;
	}

	public void SetGameOver()
	{
		player.gameObject.SetActive(false);
		playCanvas.SetActive(false);
		gameOverCanvas.SetActive(true);

		//Set GameOver texts
		gameOverScoreText.text = "Score: " + player.Score;
		gameOverCounterText.text = timePlayingStr;
	}
}