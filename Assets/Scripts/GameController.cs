using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	//Player
	public Player player;

	//UI
	public GameObject playCanvas;
	public GameObject gameOverCanvas;

	//HUD
	public Text scoreText;
	public Text levelText;
	public Text counterText;

	//Damage
	public Transform greenHealthBar;
	public Transform redHealthBar;

	//Level
	public GameObject level1;
	public GameObject openWall1;

	public GameObject level2;
	public GameObject bridge2;
	public GameObject closeWall2;
	public GameObject openWall2;

	public GameObject level3;
	public GameObject bridge3;
	public GameObject closeWall3;
	public GameObject openWall3;

	public GameObject level4;
	public GameObject bridge4;
	public GameObject closeWall4;
	public GameObject openWall4;

	public GameObject level5;
	public GameObject bridge5;
	public GameObject closeWall5;
	public GameObject openWall5;

	//GameOver
	public Text gameOverScoreText;
	public Text gameOverCounterText;


	//Timer
	private bool startTimerWinText;
	private float timerWinText = 2;
	private int timerWinTextInt;

	//Counter
	private float counter;
	private TimeSpan timePlaying;
	private string timePlayingStr;

	private int level;

	//Health bar
	private RectTransform greenHealthBarRect;
	private RectTransform redHealthBarRect;


	public RectTransform GreenHealthBarRect => greenHealthBarRect;
	public RectTransform RedHealthBarRect => redHealthBarRect;

	public bool StartTimerRedHealth { get; set; }

	public float TimerRedHealth { get; set; } = 2;

	public bool StartTimerGameOverExplosion { get; set; }

	public float TimerGameOverExplosion { get; set; } = 2;

	private void Start()
	{
		UnlockNextLevel();
		counterText.text = "";
		levelText.text = "";
		playCanvas.SetActive(true);
		gameOverCanvas.SetActive(false);
		greenHealthBarRect = greenHealthBar.GetComponent<RectTransform>();
		greenHealthBarRect.sizeDelta = new Vector2((player.Health * 4), 30);
		redHealthBarRect = redHealthBar.GetComponent<RectTransform>();
		redHealthBarRect.sizeDelta = new Vector2((player.Health * 4), 30);
	}

	// Update is called once per frame
	private void Update()
	{
		if (startTimerWinText)
		{
			timerWinText -= Time.deltaTime;
			timerWinTextInt = (int) timerWinText;
			if (timerWinTextInt == 0)
			{
				levelText.text = "";
				timerWinText = 2;
				startTimerWinText = false;
			}
		}

		counter += Time.deltaTime;
		timePlaying = TimeSpan.FromSeconds(counter);
		timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
		counterText.text = timePlayingStr;
	}

	public void UnlockNextLevel()
	{
		scoreText.text = "Score: " + player.Score;

		var pickUps = FindObjectsOfType<PickUp>();
		var hasRemainingPickups = false;
		var i = 0;

		while (!hasRemainingPickups && i < pickUps.Length)
		{
			if (pickUps[i].isActiveAndEnabled)
			{
				hasRemainingPickups = true;
			}

			i++;
		}

		if (!hasRemainingPickups)
		{
			switch (level)
			{
				case 0:
					openWall1.SetActive(false);
					level2.SetActive(true);
					levelText.text = "Level 1";
					startTimerWinText = true;
					break;
				case 1:
					openWall2.SetActive(false);
					bridge3.SetActive(true);
					level3.SetActive(true);
					levelText.text = "Level 2";
					startTimerWinText = true;
					break;
				case 2:
					openWall3.SetActive(false);
					bridge4.SetActive(true);
					level4.SetActive(true);
					levelText.text = "Level 3";
					startTimerWinText = true;
					break;
				case 3:
					openWall4.SetActive(false);
					bridge5.SetActive(true);
					level5.SetActive(true);
					levelText.text = "Level 4";
					startTimerWinText = true;
					break;
				case 4:
					openWall5.SetActive(false);
					//bridge6.SetActive(true);
					//level6.SetActive(true);
					levelText.text = "Level 5";
					startTimerWinText = true;
					break;
			}
		}
	}

	public void IncreaseLevel() //TODO implement in a generic way
	{
		switch (level)
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
				closeWall4.SetActive(true);
				level3.SetActive(false);
				bridge4.SetActive(false);
				break;
			case 3:
				closeWall5.SetActive(true);
				level4.SetActive(false);
				bridge5.SetActive(false);
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