using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	//Player
	public Player player;
	public GameObject playerGameObject;

	//UI Canvas
	public GameObject playCanvas;
	public GameObject gameOverCanvas;
	public GameObject menuCanvas;
	public GameObject levelCanvas;
	public GameObject skyboxController;

	//Cam
	public GameObject mainCam;

	//HUD
	public Text pickUpsText;
	public Text scoreText;
	public Text levelText;
	public Text counterText;
	public Text scorePonitsForLevelText;
	public Text scorePointsForTimeBonusText;

	//Damage
	public Transform greenHealthBar;
	public Transform redHealthBar;

	//Level Spawn
	public Vector3 camRotation = new Vector3(45, 0, 0);
	public Vector3 level1BallSpawn = new Vector3(0, 0.55f, 0);
	public Vector3 level1CamSpawn = new Vector3(0, 10, -10);

	public bool level2Load;
	private static readonly Vector3 Level2BallSpawn = new Vector3(0.33f, 31.91f, 119.25f);
	public Vector3 level2CamSpawn = Level2BallSpawn + new Vector3(0, 10, -10);

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
	public GameObject rotateObject;

	public GameObject goToLevel2;
	public GameObject goToLevel2Bridge;
	public GameObject goToLevel2CloseWall;

	public GameObject level2_0;
	public GameObject groundFill;

	public GameObject Level2_1;
	public GameObject bridge2_1;
	public GameObject closeWall2_1;
	public GameObject openWall2_1;
	public GameObject timelineLevel2_1;

	//GameOver
	public Text gameOverScoreText;
	public Text gameOverCounterText;

	//Timer
	private bool startTimerWinText;
	private float timerWinText = 2;
	private int timerWinTextInt;

	//Counter
	public GameObject CounterUI;
	private float counter;
	private TimeSpan timePlaying;
	private string timePlayingStr;
	public int activePickUps;
	public int collectedPickUps;

	public int level;

	//Score
	private const int baseScore = 10;
	private const int maxTimeBonus = 10;
	public int score = 0;
	private bool startScorePointAdd = false;
	private float timerScoreAdd = 2;
	private int timeBonus;

	//Health bar
	private RectTransform greenHealthBarRect;
	private RectTransform redHealthBarRect;


	public RectTransform GreenHealthBarRect => greenHealthBarRect;
	public RectTransform RedHealthBarRect => redHealthBarRect;

	public bool StartTimerRedHealth { get; set; }

	public float TimerRedHealth { get; set; } = 2;

	public bool StartTimerGameOverExplosion { get; set; }

	public float TimerGameOverExplosion { get; set; } = 2;

	public float TimeTelportForce { get; set; } = 1;

	public bool TimerTeleportStart { get; set; }

	private void Start()
	{
		//player.gameObject.transform.position = new Vector3(0.33f, 31.91f, 119.25f);
		scoreText.text = "Score: " + score;
		CalculateActivePickUpCount();
		UnlockNextLevel();

		pickUpsText.text = "Pick-ups: " + collectedPickUps + "/" + activePickUps;
		counterText.text = "";
		levelText.text = "";
		scorePonitsForLevelText.text = "";
		scorePointsForTimeBonusText.text = "";

		greenHealthBarRect = greenHealthBar.GetComponent<RectTransform>();
		greenHealthBarRect.sizeDelta = new Vector2((player.Health * 8), 40);
		redHealthBarRect = redHealthBar.GetComponent<RectTransform>();
		redHealthBarRect.sizeDelta = new Vector2((player.Health * 8), 40);
	}


	// Update is called once per frame
	private void Update()
	{
		if (level2Load)
		{
			StartLevel2();
		}

		if (startTimerWinText)
		{
			timerWinText -= Time.deltaTime;
			if (timerWinText <= 0f)
			{
				levelText.text = "";
				timerWinText = 2;
				startTimerWinText = false;
			}
		}

		if (startScorePointAdd)
		{
			timerScoreAdd -= Time.deltaTime;
			if (timerScoreAdd <= 0f)
			{
				scorePonitsForLevelText.text = "";
				scorePointsForTimeBonusText.text = "";
				timerScoreAdd = 2;
				startScorePointAdd = false;
			}
		}

		counter += Time.deltaTime;
		timePlaying = TimeSpan.FromSeconds(counter);
		timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss");
		counterText.text = timePlayingStr;
	}

	public void CalculateActivePickUpCount()
	{
		var pickUps = FindObjectsOfType<PickUp>();
		activePickUps = 0;

		foreach (var pickUp in pickUps)
		{
			if (pickUp.isActiveAndEnabled)
			{
				activePickUps++;
			}
		}
	}

	/// <summary>
	/// Calculates the score for each level individually
	/// </summary>
	/// <returns>The score of each level</returns>
	private int CalculateLevelScore()
	{
		timeBonus = (int) Math.Round((1 / (counter * 1.5)) * 100);
		int levelScore;

		if (timeBonus <= maxTimeBonus)
		{
			levelScore = baseScore + timeBonus;
		}
		else
		{
			levelScore = baseScore + maxTimeBonus;
		}

		return levelScore;
	}

	public void PickUpCollected()
	{
		collectedPickUps++;
		pickUpsText.text = "Pick-ups: " + collectedPickUps + "/" + activePickUps;
	}

	public void UnlockNextLevel()
	{
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
					levelText.text = "Stage 1";
					startTimerWinText = true;
					break;
				case 1:
					openWall2.SetActive(false);
					bridge3.SetActive(true);
					level3.SetActive(true);
					levelText.text = "Stage 2";
					startTimerWinText = true;
					break;
				case 2:
					openWall3.SetActive(false);
					bridge4.SetActive(true);
					level4.SetActive(true);
					levelText.text = "Stage 3";
					startTimerWinText = true;
					break;
				case 3:
					openWall4.SetActive(false);
					bridge5.SetActive(true);
					level5.SetActive(true);
					levelText.text = "Stage 4";
					startTimerWinText = true;
					break;
				case 4:
					openWall5.SetActive(false);
					goToLevel2Bridge.SetActive(true);
					goToLevel2.SetActive(true);
					level2_0.SetActive(true);
					Level2_1.SetActive(true);
					levelText.text = "Stage 5";
					startTimerWinText = true;
					break;
				case 5:
					openWall2_1.SetActive(true);
					bridge2_1.SetActive(true);
					break;
			}
		}
	}

	public void CompleteStage()
	{
		score += CalculateLevelScore();
		scoreText.text = "Score: " + score;
		startScorePointAdd = true;
		CounterUI.SetActive(false);
		scorePonitsForLevelText.text = "+ Level done: " + baseScore;
		scorePointsForTimeBonusText.text = "+ Time Bonus: " + (CalculateLevelScore() - baseScore);
	}

	public void IncreaseLevel() //TODO implement in a generic way
	{
		CalculateActivePickUpCount();
		CounterUI.SetActive(true);
		collectedPickUps = 0;
		pickUpsText.text = "Pick-ups: " + collectedPickUps + "/" + activePickUps;
		counter = 0;

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
				rotateObject.GetComponent<RotationLevel5>().enabled = true;
				break;
			case 4:
				goToLevel2CloseWall.SetActive(true);
				level5.SetActive(false);
				goToLevel2Bridge.SetActive(false);
				break;
			case 5:
				closeWall2_1.SetActive(true);
				level2_0.SetActive(false);
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
		gameOverScoreText.text = "Score: " + score;
		gameOverCounterText.text = timePlayingStr;
	}

	private void StartLevel2()
	{
		player.gameObject.transform.position = Level2BallSpawn;
		level = 5;
		goToLevel2.SetActive(false);
		level1.SetActive(false);
		level2_0.SetActive(true);
		Level2_1.SetActive(true);
		groundFill.SetActive(true);
		level2Load = false;
	}

	public void GameStartLevelStatus()
	{
		bridge2.SetActive(true);

		level1.SetActive(true);
		openWall1.SetActive(true);
		level2.SetActive(false);

		openWall2.SetActive(true);
		bridge3.SetActive(false);
		level3.SetActive(false);

		openWall3.SetActive(true);
		bridge4.SetActive(false);
		level4.SetActive(false);

		openWall4.SetActive(true);
		bridge5.SetActive(false);
		level5.SetActive(false);

		openWall5.SetActive(true);
		goToLevel2Bridge.SetActive(false);
		goToLevel2.SetActive(false);
		level2_0.SetActive(false);
		Level2_1.SetActive(false);

		openWall2_1.SetActive(false);
		bridge2_1.SetActive(false);
	}

	public void HackAllLevel()
	{
		openWall1.SetActive(false);
		level2.SetActive(true);

		openWall2.SetActive(false);
		bridge3.SetActive(true);
		level3.SetActive(true);

		openWall3.SetActive(false);
		bridge4.SetActive(true);
		level4.SetActive(true);

		openWall4.SetActive(false);
		bridge5.SetActive(true);
		level5.SetActive(true);

		openWall5.SetActive(false);
		goToLevel2Bridge.SetActive(true);
		goToLevel2.SetActive(true);

		level2_0.SetActive(true);
		Level2_1.SetActive(true);
		openWall2.SetActive(false);
		openWall2_1.SetActive(false);
	}
}