﻿using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	//Player
	public Player player;
	public GameObject playerGameObject;
	public Resetter resetter;

	//UI Canvas
	public GameObject playCanvas;
	public GameObject gameOverCanvas;
	public GameObject menuCanvas;
	public GameObject levelCanvas;
	public GameObject pauseCanvas;
	public GameObject skyboxController;
	public GameObject CounterUI;

	//Cam
	public GameObject mainCam;

	//HUD
	public Text pickUpsText;
	public Text scoreText;
	public Text levelText;
	public Text counterText;
	public Text scorePointsForLevelText;
	public Text scorePointsForTimeBonusText;

	//Damage
	public Transform greenHealthBar;
	public Transform redHealthBar;

	//Level
	public GameObject level1_1;
	public GameObject closeWall1_1;
	public GameObject openWall1_1;

	public GameObject level1_2;
	public GameObject bridge1_2;
	public GameObject closeWall1_2;
	public GameObject openWall1_2;

	public GameObject level1_3;
	public GameObject bridge1_3;
	public GameObject closeWall1_3;
	public GameObject openWall1_3;

	public GameObject level1_4;
	public GameObject bridge1_4;
	public GameObject closeWall1_4;
	public GameObject openWall1_4;

	public GameObject level1_5;
	public GameObject bridge1_5;
	public GameObject closeWall1_5;
	public GameObject openWall1_5;
	public GameObject rotateObject;

	public GameObject goToLevel2;
	public GameObject goToLevel2Bridge;
	public GameObject goToLevel2CloseWall;

	public GameObject level2_0;
	public GameObject groundFillLevel2;

	public GameObject level2_1;
	public GameObject bridge2_1;
	public GameObject closeWall2_1;
	public GameObject openWall2_1;
	public GameObject timelineLevel2_1;

	public GameObject level2_2;
	public GameObject bridge2_2;
	public GameObject closeWall2_2;
	public GameObject openWall2_2;

	public GameObject level2_3;
	public GameObject bridge2_3;
	public GameObject closeWall2_3;
	public GameObject openWall2_3;

	public GameObject level2_4;
	public GameObject bridge2_4;
	public GameObject closeWall2_4;
	public GameObject openWall2_4;

	public GameObject level2_5;
	public GameObject bridge2_5;
	public GameObject closeWall2_5;
	public GameObject openWall2_5;

	public GameObject goToLevel3;
	public GameObject goToLevel3CloseWall;

	public GameObject level3_0;
	public GameObject groundFillLevel3;

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
	public int activePickUps;
	public int collectedPickUps;

	public int level;

	//Level Spawn
	private readonly Vector3 level1BallSpawn = new Vector3(0, 1.1f, 0);
	private readonly Vector3 level1CamSpawn = new Vector3(0, 10, -10);

	private bool level2OnGo;
	private static readonly Vector3 level2BallSpawn = new Vector3(0.33f, 31.91f, 119.25f);
	private readonly Vector3 level2CamSpawn = level2BallSpawn + new Vector3(0, 10, -10);

	//Score
	private const int BaseScore = 10;
	private const int MaxTimeBonus = 10;
	private int score;
	private bool startScorePointAdd;
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

	public void StartGame() //TODO fix Timer + trigger + remove duplicateeees
	{
		GameStartLevelStatus();
		level = 0;
		counter = 0f;
		player.healthParticle.GetComponent<ParticleSystem>().playOnAwake = false;
		playerGameObject.GetComponent<Rigidbody>().isKinematic = true;

		playerGameObject.SetActive(true);
		player.explosionParticle.SetActive(false);
		player.gameObject.GetComponent<MeshRenderer>().enabled = true;
		player.gameObject.GetComponent<Rigidbody>().isKinematic = false;
		player.Reset();

		greenHealthBarRect = greenHealthBar.GetComponent<RectTransform>();
		greenHealthBarRect.sizeDelta = new Vector2((player.Health * 8), 40);
		redHealthBarRect = redHealthBar.GetComponent<RectTransform>();
		redHealthBarRect.sizeDelta = new Vector2((player.Health * 8), 40);

		resetter.ResetAll();
		CalculateActivePickUpCount();
		UnlockNextLevel();
		score = 0;
		scoreText.text = "Score: " + score;
		collectedPickUps = 0;
		pickUpsText.text = "Pick-ups: " + collectedPickUps + "/" + activePickUps;
		counterText.text = "";
		levelText.text = "";
		scorePointsForLevelText.text = "";
		scorePointsForTimeBonusText.text = "";

		playCanvas.SetActive(true);
		menuCanvas.SetActive(false);
		gameOverCanvas.SetActive(false);
		levelCanvas.SetActive(false);
		player.healthParticle.GetComponent<ParticleSystem>().playOnAwake = true;

		mainCam.transform.Rotate(45, 0 , 0);
		mainCam.GetComponent<CameraController>().enabled = true;

		skyboxController.SetActive(false);

		if (level2OnGo)
		{
			StartGameLevel2();
		}
		else
		{
			Level1LevelStates();
			playerGameObject.transform.position = level1BallSpawn;
			mainCam.transform.position = level1CamSpawn;
		}
	}

	private void StartGameLevel2()
	{
		Level2LevelStates();
		level = 5;
		playerGameObject.transform.position = level2BallSpawn;
		mainCam.transform.position = level2CamSpawn;
	}

	public void RestartGame()
	{
		mainCam.transform.Rotate(-45, 0 , 0);

		if (level >= 5)
		{
			level2OnGo = true;
		}
		StartGame();
	}

	// Update is called once per frame
	private void Update()
	{
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
				scorePointsForLevelText.text = "";
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

	private void CalculateActivePickUpCount()
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

		if (timeBonus <= MaxTimeBonus)
		{
			levelScore = BaseScore + timeBonus;
		}
		else
		{
			levelScore = BaseScore + MaxTimeBonus;
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
					openWall1_1.SetActive(false);
					level1_2.SetActive(true);
					levelText.text = "Stage 1";
					startTimerWinText = true;
					break;
				case 1:
					openWall1_2.SetActive(false);
					bridge1_3.SetActive(true);
					level1_3.SetActive(true);
					levelText.text = "Stage 2";
					startTimerWinText = true;
					break;
				case 2:
					openWall1_3.SetActive(false);
					bridge1_4.SetActive(true);
					level1_4.SetActive(true);
					levelText.text = "Stage 3";
					startTimerWinText = true;
					break;
				case 3:
					openWall1_4.SetActive(false);
					bridge1_5.SetActive(true);
					level1_5.SetActive(true);
					levelText.text = "Stage 4";
					startTimerWinText = true;
					break;
				case 4:
					openWall1_5.SetActive(false);
					goToLevel2Bridge.SetActive(true);
					goToLevel2.SetActive(true);
					level2_0.SetActive(true);
					level2_1.SetActive(true);
					levelText.text = "Stage 5";
					startTimerWinText = true;
					break;
				case 6 :
					openWall2_1.SetActive(false);
					bridge2_1.SetActive(true);
					level2_2.SetActive(true);
					levelText.text = "Stage 1";
					startTimerWinText = true;
					break;
				case 7 :
					openWall2_2.SetActive(false);
					bridge2_2.SetActive(true);
					level2_3.SetActive(true);
					levelText.text = "Stage 2";
					startTimerWinText = true;
					break;
				case 8 :
					openWall2_3.SetActive(false);
					bridge2_3.SetActive(true);
					level2_4.SetActive(true);
					levelText.text = "Stage 3";
					startTimerWinText = true;
					break;
				case 9 :
					openWall2_4.SetActive(false);
					bridge2_4.SetActive(true);
					level2_5.SetActive(true);
					levelText.text = "Stage 4";
					startTimerWinText = true;
					break;
				case 10 :
					openWall2_5.SetActive(false);
					bridge2_5.SetActive(true);
					goToLevel3.SetActive(true);
					level3_0.SetActive(true);
					// level3_1.SetActive(true);   //TODO: Gibt es noch nicht muss noch erstellt werden
					levelText.text = "Stage 5";
					startTimerWinText = true;
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
		scorePointsForLevelText.text = "+ Level done: " + BaseScore;
		scorePointsForTimeBonusText.text = "+ Time Bonus: " + (CalculateLevelScore() - BaseScore);
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
				closeWall1_2.SetActive(true);
				level1_1.SetActive(false);
				bridge1_2.SetActive(false);
				break;
			case 1:
				closeWall1_3.SetActive(true);
				level1_2.SetActive(false);
				bridge1_3.SetActive(false);
				break;
			case 2:
				closeWall1_4.SetActive(true);
				level1_3.SetActive(false);
				bridge1_4.SetActive(false);
				break;
			case 3:
				closeWall1_5.SetActive(true);
				level1_4.SetActive(false);
				bridge1_5.SetActive(false);
				rotateObject.GetComponent<RotationLevel5>().enabled = true;
				break;
			case 4:
				goToLevel2CloseWall.SetActive(true);
				level1_5.SetActive(false);
				goToLevel2Bridge.SetActive(false);
				break;
			case 5:
				closeWall2_1.SetActive(true);
				level2_0.SetActive(false);
				break;
			case 6:
				closeWall2_2.SetActive(true);
				level2_1.SetActive(false);
				break;
			case 7:
				closeWall2_3.SetActive(true);
				level2_2.SetActive(false);
				break;
			case 8:
				closeWall2_4.SetActive(true);
				level2_3.SetActive(false);
				break;
			case 9:
				closeWall2_5.SetActive(true);
				level2_4.SetActive(false);
				break;
			case 10:
				goToLevel3CloseWall.SetActive(true);
				level2_5.SetActive(false);
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

	public void StartLevel1() //TODO use int which represents level
	{
		level2OnGo = false;
		/*level3OnGo = false;
		level4OnGo = false;
		level5OnGo = false;*/
	}

	public void StartLevel2()
	{
		level2OnGo = true;
		/*level3OnGo = false;
		level4OnGo = false;
		level5OnGo = false;*/
	}

	private void Level1LevelStates()
	{
		level1_1.SetActive(true); //TODO hier wird jeders lavel rein kommen und false gesetzt
		closeWall1_1.SetActive(true);
		level1_2.SetActive(false);
		level1_3.SetActive(false);
		level1_4.SetActive(false);
		level1_5.SetActive(false);
		goToLevel2.SetActive(false);
		level2_0.SetActive(false);
		level2_1.SetActive(false);
	}

	private void Level2LevelStates()
	{
		goToLevel2.SetActive(false);
		level1_1.SetActive(false);
		level1_2.SetActive(false);
		level1_3.SetActive(false);
		level1_4.SetActive(false);
		level1_5.SetActive(false);
		level2_0.SetActive(true);

		CalculateActivePickUpCount(); // is there because to calculate the activePickups on spawn platform and there it is 0
		pickUpsText.text = "Pick-ups: " + collectedPickUps + "/" + activePickUps;

		level2_1.SetActive(true);
		groundFillLevel2.SetActive(true);
	}

	private void GameStartLevelStatus()
	{
		bridge1_2.SetActive(true);
		//bridge2.SetActive(false);

		level1_1.SetActive(true);
		openWall1_1.SetActive(true);
		level1_2.SetActive(false);

		openWall1_2.SetActive(true);
		bridge1_3.SetActive(false);
		level1_3.SetActive(false);

		openWall1_3.SetActive(true);
		bridge1_4.SetActive(false);
		level1_4.SetActive(false);

		openWall1_4.SetActive(true);
		bridge1_5.SetActive(false);
		level1_5.SetActive(false);

		openWall1_5.SetActive(true);
		goToLevel2Bridge.SetActive(false);
		goToLevel2.SetActive(false);
		level2_0.SetActive(false);
		level2_1.SetActive(false);
		bridge2_1.SetActive(false);

		openWall2_1.SetActive(true);
		bridge2_2.SetActive(false);
		level2_2.SetActive(false);

		openWall2_2.SetActive(true);
		bridge2_3.SetActive(false);
		level2_3.SetActive(false);

		openWall2_3.SetActive(true);
		/*bridge2_4.SetActive(false);
		level2_4.SetActive(false);*/

		/*openWall2_4.SetActive(true);
		bridge2_5.SetActive(false);
		level2_5.SetActive(false);*/
	}

	public void HackAllLevel()
	{
		openWall1_1.SetActive(false);
		level1_2.SetActive(true);

		openWall1_2.SetActive(false);
		bridge1_3.SetActive(true);
		level1_3.SetActive(true);

		openWall1_3.SetActive(false);
		bridge1_4.SetActive(true);
		level1_4.SetActive(true);

		openWall1_4.SetActive(false);
		bridge1_5.SetActive(true);
		level1_5.SetActive(true);

		openWall1_5.SetActive(false);
		goToLevel2Bridge.SetActive(true);
		goToLevel2.SetActive(true);

		level2_0.SetActive(true);
		level2_1.SetActive(true);
		openWall1_2.SetActive(false);
		openWall2_1.SetActive(false);
	}
}