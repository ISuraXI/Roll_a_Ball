using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	//Player
	public Player player;
	public GameObject playerGameObject;
	public Resetter resetter;
	public UiMenuController uiMenuController;
	public SlidingNumber slidingNumber;

	//UI Canvas
	public GameObject playCanvas;
	public GameObject gameOverCanvas;
	public GameObject menuCanvas;
	public GameObject shopBallCanvas;
	public GameObject shopGroundCanvas;
	public GameObject levelCanvas;
	public GameObject pauseCanvas;
	public GameObject settingsCanvas;
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
	public GameObject scorePointsForLevel;
	public Text scorePointsForTimeBonusText;
	public GameObject scorePointsForTimeBonus;
	public Text levelCompleteText;
	public GameObject LevelCompletePanal;
	public Text godModeText;
	public Text coinsBallsText;
	public Text coinsGroundsText;
	public Text coinsPauseText;

	//Coins
	public int coins;

	//Damage
	public Transform greenHealthBar;
	public Transform redHealthBar;

	//Sound
	public float volume = 0.2f;
	public GameObject volumeSlider;
	public GameObject soundMangaer;

	//Level
	public GameObject level1_1;
	public GameObject closeWall1_1;
	public GameObject openWall1_1;
	public GameObject levelOutTrigger1_1;

	public GameObject level1_2;
	public GameObject bridge1_2;
	public GameObject closeWall1_2;
	public GameObject openWall1_2;
	public GameObject levelOutTrigger1_2;

	public GameObject level1_3;
	public GameObject bridge1_3;
	public GameObject closeWall1_3;
	public GameObject openWall1_3;
	public GameObject levelOutTrigger1_3;
	public GameObject godModeLevel1_3;

	public GameObject level1_4;
	public GameObject bridge1_4;
	public GameObject closeWall1_4;
	public GameObject openWall1_4;
	public GameObject levelOutTrigger1_4;

	public GameObject level1_5;
	public GameObject bridge1_5;
	public GameObject closeWall1_5;
	public GameObject openWall1_5;
	public GameObject rotateObject;
	public GameObject levelOutTrigger1_5;

	public GameObject goToLevel2;
	public GameObject goToLevel2Bridge;
	public GameObject goToLevel2CloseWall;

	public GameObject level2_0;
	public GameObject groundFillLevel2;
	public GameObject groundTrigger2;

	public GameObject level2_1;
	public GameObject bridge2_1;
	public GameObject closeWall2_1;
	public GameObject openWall2_1;
	public GameObject timelineLevel2_1;
	public GameObject levelOutTrigger2_1;

	public GameObject level2_2;
	public GameObject bridge2_2;
	public GameObject closeWall2_2;
	public GameObject openWall2_2;
	public GameObject levelOutTrigger2_2;
	public GameObject godModeLevel2_2;

	public GameObject level2_3;
	public GameObject bridge2_3;
	public GameObject closeWall2_3;
	public GameObject openWall2_3;
	public GameObject levelOutTrigger2_3;
	public GameObject level2_3Enemy;

	public GameObject level2_4;
	public GameObject bridge2_4;
	public GameObject closeWall2_4;
	public GameObject openWall2_4;
	public GameObject levelOutTrigger2_4;
	public GameObject mover1;
	public GameObject mover2;
	public GameObject godModeLevel2_4;

	public GameObject level2_5;
	public GameObject bridge2_5;
	public GameObject closeWall2_5;
	public GameObject openWall2_5;
	public GameObject levelOutTrigger2_5;
	public GameObject DamageCylinderLevel2_5;
	public GameObject DamageCylinder2Level2_5;

	public GameObject goToLevel3;
	public GameObject goToLevel3CloseWall;

	public GameObject level3_0;
	public GameObject groundFillLevel3;
	public GameObject groundTrigger3;

	public GameObject level3_1;
	public GameObject bridge3_1;
	public GameObject closeWall3_1;
	public GameObject openWall3_1;
	public GameObject levelOutTrigger3_1;

	public GameObject level3_2;
	public GameObject bridge3_2;
	public GameObject closeWall3_2;
	public GameObject openWall3_2;
	public GameObject levelOutTrigger3_2;
	public GameObject trigger3_2;

	public GameObject level3_3;
	public GameObject bridge3_3;
	public GameObject closeWall3_3;
	public GameObject openWall3_3;
	public GameObject levelOutTrigger3_3;

	//GameOver
	public Text gameOverScoreText;
	public Text gameOverCounterText;

	//Level
	public int highscoreLevel1;
	public int highscoreLevel2;
	public int highscoreLevel3;
	public int highscoreLevel4;
	public int highscoreLevel5;
	public int highscoreLevel6;
	public int highscoreLevel7;
	public int highscoreLevel8;
	public int highscoreLevel9;
	public int highscoreLevel10;
	public int passedLevel = 0;
	public bool level1 = true;
	public bool level2 = true;
	public bool level3 = true;
	/*public bool level4 = true; // Didi nicht löschen pls
	public bool level5 = true;*/
	public Text highscoreLevel1Text;
	public Text highscoreLevel2Text;
	public Text highscoreLevel3Text;
	public Text highscoreLevel4Text;
	public Text highscoreLevel5Text;
	public Text highscoreLevel6Text;
	public Text highscoreLevel7Text;
	public Text highscoreLevel8Text;
	public Text highscoreLevel9Text;
	public Text highscoreLevel10Text;

	//Shop
	public bool ball2Unlocked;
	public bool ball3Unlocked;
	public bool ball4Unlocked;
	public bool ball5Unlocked;
	public bool ball6Unlocked;
	public bool ball7Unlocked;
	public bool ball8Unlocked;

	public bool ground2Unlocked;
	public bool ground3Unlocked;
	public bool ground4Unlocked;
	public bool ground5Unlocked;

	public int groundStatus = 1;
	public int ballStatus = 1;

	//Timer
	private bool startTimerWinText;
	private float timerWinText = 2;
	private int timerWinTextInt;

	//God Mode
	public bool canTakeDamage = true;
	public GameObject godModePlayer;
	private float timerGodMode = 30f;

	//Counter
	private float counter;
	private TimeSpan timePlaying;
	private string timePlayingStr;
	public int activePickUps;
	public int collectedPickUps;

	public int level;

	//Level Spawn
	private readonly Vector3 level1BallSpawn = new Vector3(0, 0.55f, 0);
	private readonly Vector3 level1CamSpawn = new Vector3(0, 10, -10);

	private bool level2OnGo;
	private static readonly Vector3 level2BallSpawn = new Vector3(0.33f, 31.91f, 119.25f);
	private readonly Vector3 level2CamSpawn = level2BallSpawn + new Vector3(0, 10, -10);

	private bool level3OnGo;
	private static readonly Vector3 level3BallSpawn = new Vector3(39.92332f, 65.98216f, 239.0318f);
	private readonly Vector3 level3CamSpawn = level3BallSpawn + new Vector3(0, 10, -10);

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
	public RectTransform blueHealthBarRect;
	public GameObject greenHealthBarGameObject;
	public GameObject redHealthBarGameObject;
	public GameObject blueHealthBarGameObject;
	public Text lifeText;


	public RectTransform GreenHealthBarRect => greenHealthBarRect;
	public RectTransform RedHealthBarRect => redHealthBarRect;

	public bool GodMode { get; set; }
	public bool StartTimerRedHealth { get; set; }

	public float TimerRedHealth { get; set; } = 2;

	public bool StartTimerGameOverExplosion { get; set; }

	public float TimerGameOverExplosion { get; set; } = 2;


	public void Start()
	{
		LoadGameControllerData();
	}

	public void OnApplicationQuit()
	{
		SaveGameControllerData();
	}
	public void LoadGameControllerData()
	{
		GameControllerData data = SaveSystem.loadGameController();

		passedLevel = data.passedLevel;
		highscoreLevel1 = data.highscoreLevel1;
		highscoreLevel2 = data.highscoreLevel2;
		highscoreLevel3 = data.highscoreLevel3;
		highscoreLevel4 = data.highscoreLevel4;
		highscoreLevel5 = data.highscoreLevel5;
		highscoreLevel6 = data.highscoreLevel6;
		highscoreLevel7 = data.highscoreLevel7;
		highscoreLevel8 = data.highscoreLevel8;
		highscoreLevel9 = data.highscoreLevel9;
		highscoreLevel10 = data.highscoreLevel10;

		ball2Unlocked = data.ball2Unlocked;
		ball3Unlocked = data.ball3Unlocked;
		ball4Unlocked = data.ball4Unlocked;
		ball5Unlocked = data.ball5Unlocked;
		ball6Unlocked = data.ball6Unlocked;
		ball7Unlocked = data.ball7Unlocked;
		ball8Unlocked = data.ball8Unlocked;

		ground2Unlocked = data.ground2Unlocked;
		ground3Unlocked = data.ground3Unlocked;
		ground4Unlocked = data.ground4Unlocked;
		ground5Unlocked = data.ground5Unlocked;

		groundStatus = data.groundStatus;
		ballStatus = data.ballStatus;
		volume = data.volume;
		coins = data.coins;

		UnlockedGrounds();
		UnlockedBalls();
		SetHighscore();
		uiMenuController.GroundSetter();
		uiMenuController.BallSetter();
		SetCoins();

		if (volume == 0)
		{
			uiMenuController.KlickOnSoundMute();
		}
		else
		{
			uiMenuController.KlickOnSoundLoud();
		}
	}

	public void SaveGameControllerData()
	{
		SaveSystem.SaveGameController(this);
	}

	public void volumeOff()
	{
		volume = 0;
	}

	public void volumeOn()
	{
		volume = 0.2f;
	}

	/*public void AdjustVolume(float newVolume)
	{
		volume = newVolume;
	}*/

	public void StartGame() //TODO fix Timer + trigger + remove duplicateeees
	{
		uiMenuController.GroundSetter();
		GameStartLevelStatus();
		level = 0;
		counter = 0f;
		player.healthParticle.GetComponent<ParticleSystem>().playOnAwake = false;
		playerGameObject.GetComponent<Rigidbody>().isKinematic = true;

		GodMode = true;
		timerGodMode = 0;

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
		pickUpsText.text = "Items: " + collectedPickUps + "/" + activePickUps;
		counterText.text = "";
		levelText.text = "";
		levelCompleteText.text = "";
		godModeText.text = "";
		scorePointsForLevel.SetActive(false);
		scorePointsForTimeBonus.SetActive(false);
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
		else if (level3OnGo)
		{
			StartGameLevel3();
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

	private void StartGameLevel3()
	{
		Level3LevelStates();
		level = 11;
		playerGameObject.transform.position = level3BallSpawn;
		mainCam.transform.position = level3CamSpawn;
	}

	public void RestartGame()
	{
		mainCam.transform.Rotate(-45, 0 , 0);

		if (level >= 5 && level <= 11)
		{
			level2OnGo = true;
		}
		else if (level >= 11)
		{
			level3OnGo = true;
		}
		StartGame();
	}

	// Update is called once per frame
	private void Update()
	{
		SaveGameControllerData();
		SetCoins();

		soundMangaer.GetComponent<AudioSource>().volume = volume;
		volumeSlider.GetComponent<Slider>().value = volume;

		if (GodMode)
		{
			greenHealthBarGameObject.SetActive(false);
			redHealthBarGameObject.SetActive(false);
			canTakeDamage = false;
			timerGodMode -= Time.deltaTime;
			blueHealthBarGameObject.SetActive(true);
			blueHealthBarRect.sizeDelta = new Vector2(((timerGodMode / 3) *10 ) * 8, 40);
				lifeText.text = "Safe Mode";
			var timeGodModeFinal = TimeSpan.FromSeconds(timerGodMode);
			var timeGodModeFinalStr = "God Mode: " + timeGodModeFinal.ToString("ss");
			godModeText.text = timeGodModeFinalStr;
			godModePlayer.SetActive(true);
			godModeLevel1_3.SetActive(true);
			godModeLevel2_2.SetActive(true);
			godModeLevel2_4.SetActive(true);
			if (timerGodMode <= 0f)
			{
				greenHealthBarGameObject.SetActive(true);
				redHealthBarGameObject.SetActive(true);
				godModeText.text = "";
				godModePlayer.SetActive(false);
				godModeLevel1_3.SetActive(false);
				godModeLevel2_2.SetActive(false);
				godModeLevel2_4.SetActive(false);
				blueHealthBarGameObject.SetActive(false);
				lifeText.text = "Life";
				canTakeDamage = true;
				timerGodMode = 30f;
				GodMode = false;
			}
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
				scorePointsForLevel.SetActive(false);
				scorePointsForTimeBonus.SetActive(false);
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
		pickUpsText.text = "Items: " + collectedPickUps + "/" + activePickUps;
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
					levelOutTrigger1_1.SetActive(true);
					//levelText.text = "Stage 1";
					startTimerWinText = true;
					break;
				case 1:
					openWall1_2.SetActive(false);
					bridge1_3.SetActive(true);
					level1_3.SetActive(true);
					levelOutTrigger1_2.SetActive(true);
					//levelText.text = "Stage 2";
					startTimerWinText = true;
					break;
				case 2:
					openWall1_3.SetActive(false);
					bridge1_4.SetActive(true);
					level1_4.SetActive(true);
					levelOutTrigger1_3.SetActive(true);
					//levelText.text = "Stage 3";
					startTimerWinText = true;
					break;
				case 3:
					openWall1_4.SetActive(false);
					bridge1_5.SetActive(true);
					level1_5.SetActive(true);
					levelOutTrigger1_4.SetActive(true);
					//levelText.text = "Stage 4";
					startTimerWinText = true;
					break;
				case 4:
					openWall1_5.SetActive(false);
					goToLevel2Bridge.SetActive(true);
					goToLevel2.SetActive(true);
					levelOutTrigger1_5.SetActive(true);
					level2_0.SetActive(true);
					level2_1.SetActive(true);
					//levelText.text = "Stage 5";
					startTimerWinText = true;
					break;
				case 6 :
					openWall2_1.SetActive(false);
					bridge2_1.SetActive(true);
					level2_2.SetActive(true);
					levelOutTrigger2_1.SetActive(true);
					//levelText.text = "Stage 1";
					startTimerWinText = true;
					break;
				case 7 :
					openWall2_2.SetActive(false);
					bridge2_2.SetActive(true);
					level2_3.SetActive(true);
					levelOutTrigger2_2.SetActive(true);
					//levelText.text = "Stage 2";
					startTimerWinText = true;
					break;
				case 8 :
					openWall2_3.SetActive(false);
					bridge2_3.SetActive(true);
					level2_4.SetActive(true);
					levelOutTrigger2_3.SetActive(true);
					//levelText.text = "Stage 3";
					startTimerWinText = true;
					break;
				case 9 :
					openWall2_4.SetActive(false);
					bridge2_4.SetActive(true);
					level2_5.SetActive(true);
					levelOutTrigger2_4.SetActive(true);
					//levelText.text = "Stage 4";
					startTimerWinText = true;
					DamageCylinderLevel2_5.GetComponent<PathMover>().enabled = true;
					DamageCylinder2Level2_5.GetComponent<PathMover>().enabled = true;
					break;
				case 10 :
					openWall2_5.SetActive(false);
					bridge2_5.SetActive(true);
					goToLevel3.SetActive(true);
					levelOutTrigger2_5.SetActive(true);
					level3_0.SetActive(true);
					level3_1.SetActive(true);
					//levelText.text = "Stage 5";
					startTimerWinText = true;
					break;
				case 12 :
					openWall3_1.SetActive(false);
					bridge3_1.SetActive(true);
					level3_2.SetActive(true);
					levelOutTrigger3_1.SetActive(true);
					level3_2.SetActive(true);
					startTimerWinText = true;
					break;
				case 13 :
					//da keine Pickups in level3_2
					break;
			}
		}
	}

	public void CompleteStage()
	{
		score += CalculateLevelScore();
		slidingNumber.SetNumber(score);
		//scoreText.text = "Score: " + score;
		startScorePointAdd = true;
		CounterUI.SetActive(false);
		scorePointsForLevel.SetActive(true);
		scorePointsForTimeBonus.SetActive(true);
		scorePointsForLevelText.text = "Stage done + " + BaseScore;
		scorePointsForTimeBonusText.text = "Time Bonus  + " + (CalculateLevelScore() - BaseScore);
		if (level == 8)
		{
			level2_3Enemy.SetActive(false);
		}
	}

	public void IncreaseLevel() //TODO implement in a generic way
	{
		CalculateActivePickUpCount();
		CounterUI.SetActive(true);
		collectedPickUps = 0;
		pickUpsText.text = "Items: " + collectedPickUps + "/" + activePickUps;
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
				rotateObject.GetComponent<RotationLevel5>().enabled = false;
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
				level2_3Enemy.GetComponent<PathMover>().enabled = true;
				break;
			case 8:
				closeWall2_4.SetActive(true);
				level2_3Enemy.GetComponent<PathMover>().enabled = false;
				mover1.GetComponent<PathMover>().enabled = true;
				mover2.GetComponent<PathMover>().enabled = true;
				level2_3.SetActive(false);
				break;
			case 9:
				closeWall2_5.SetActive(true);
				level2_4.SetActive(false);
				mover1.GetComponent<PathMover>().enabled = false;
				mover2.GetComponent<PathMover>().enabled = false;
				break;
			case 10:
				goToLevel3CloseWall.SetActive(true);
				level2_5.SetActive(false);
				break;
			case 11:
				closeWall3_1.SetActive(true);
				level3_0.SetActive(false);
				break;
			case 12 :
				closeWall3_2.SetActive(true);
				level3_1.SetActive(false);
				openWall3_2.SetActive(false);
				bridge3_2.SetActive(true);
				levelOutTrigger3_2.SetActive(true);
				level3_3.SetActive(true);
				level3_3.SetActive(true);
				startTimerWinText = true;
				break;
			case 13 :
				closeWall3_3.SetActive(true);
				level3_2.SetActive(false);
				break;
		}


		level++;
	}

	public void PrintHighscore()
	{
		if (passedLevel == 1 && highscoreLevel1 <= score)
		{
			highscoreLevel1Text.text = "Highscore" + Environment.NewLine + score;
			highscoreLevel1 = score;
		}
		else if (passedLevel == 2 && highscoreLevel2 <= score)
		{
			highscoreLevel2Text.text = "Highscore" + Environment.NewLine + score;
			highscoreLevel2 = score;
		}
		else if (passedLevel == 3 && highscoreLevel3 <= score)
		{
			highscoreLevel3Text.text = "Highscore" + Environment.NewLine + score;
			highscoreLevel3 = score;
		}
		else if (passedLevel == 4 && highscoreLevel4 <= score)
		{
			highscoreLevel4Text.text = "Highscore" + Environment.NewLine + score;
			highscoreLevel4 = score;
		}
		else if (passedLevel == 5 && highscoreLevel5 <= score)
		{
			highscoreLevel5Text.text = "Highscore" + Environment.NewLine + score;
			highscoreLevel5 = score;
		}
	}

	public void SetHighscore()
	{
		highscoreLevel1Text.text = "Highscore" + Environment.NewLine + highscoreLevel1;
		highscoreLevel2Text.text = "Highscore" + Environment.NewLine + highscoreLevel2;
		highscoreLevel3Text.text = "Highscore" + Environment.NewLine + highscoreLevel3;
		highscoreLevel4Text.text = "Highscore" + Environment.NewLine + highscoreLevel4;
		highscoreLevel5Text.text = "Highscore" + Environment.NewLine + highscoreLevel5;
		highscoreLevel6Text.text = "Highscore" + Environment.NewLine + highscoreLevel6;
		highscoreLevel7Text.text = "Highscore" + Environment.NewLine + highscoreLevel7;
		highscoreLevel8Text.text = "Highscore" + Environment.NewLine + highscoreLevel8;
		highscoreLevel9Text.text = "Highscore" + Environment.NewLine + highscoreLevel9;
		highscoreLevel10Text.text = "Highscore" + Environment.NewLine + highscoreLevel10;
	}

	public void SetCoins()
	{
		coinsBallsText.text = "" + coins;
		coinsGroundsText.text = "" + coins;
		coinsPauseText.text = "" + coins;
	}


	public void UnlockedBalls()
	{
		if (ball2Unlocked)
		{
			uiMenuController.UnlockBall2();
		}
		if (ball3Unlocked)
		{
			uiMenuController.UnlockBall3();
		}
		if (ball4Unlocked)
		{
			uiMenuController.UnlockBall4();
		}
		if (ball5Unlocked)
		{
			uiMenuController.UnlockBall5();
		}
		if (ball6Unlocked)
		{
			uiMenuController.UnlockBall6();
		}
		if (ball7Unlocked)
		{
			uiMenuController.UnlockBall7();
		}
		if (ball8Unlocked)
		{
			uiMenuController.UnlockBall8();
		}
	}

	public void UnlockedGrounds()
	{
		if (ground2Unlocked)
		{
			uiMenuController.UnlockGround2();
		}
		if (ground3Unlocked)
		{
			uiMenuController.UnlockGround3();
		}
		if (ground4Unlocked)
		{
			uiMenuController.UnlockGround4();
		}
		if (ground5Unlocked)
		{
			uiMenuController.UnlockGround5();
		}
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

	public void SetScoreToZero()
	{
		score = 0;
		scoreText.text = "Score: " + score;
	}

	public void StartLevel1() //TODO use int which represents level
	{
		level2OnGo = false;
		level3OnGo = false;
		/*level4OnGo = false;
		level5OnGo = false;*/
	}

	public void StartLevel2()
	{
		level2OnGo = true;
		level3OnGo = false;
		/*level4OnGo = false;
		level5OnGo = false;*/
	}

	public void StartLevel3()
	{
		level2OnGo = false;
		level3OnGo = true;
		/*level4OnGo = false;
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
		groundTrigger2.SetActive(true);
		groundTrigger3.SetActive(true);
		level2_1.SetActive(false);
	}

	private void Level2LevelStates()
	{
		goToLevel2.SetActive(false);
		groundTrigger2.SetActive(false);
		level1_1.SetActive(false);
		level1_2.SetActive(false);
		level1_3.SetActive(false);
		level1_4.SetActive(false);
		level1_5.SetActive(false);
		level2_0.SetActive(true);

		CalculateActivePickUpCount(); // is there because to calculate the activePickups on spawn platform and there it is 0
		pickUpsText.text = "Items: " + collectedPickUps + "/" + activePickUps;

		level2_1.SetActive(true);
		groundFillLevel2.SetActive(true);
		timelineLevel2_1.SetActive(true);
		groundTrigger3.SetActive(true);
	}

	private void Level3LevelStates()
	{
		level1_1.SetActive(false);
		level1_2.SetActive(false);
		level1_3.SetActive(false);
		level1_4.SetActive(false);
		level1_5.SetActive(false);
		goToLevel2.SetActive(false);
		level2_0.SetActive(false);
		level2_1.SetActive(false);
		level2_2.SetActive(false);
		level2_3.SetActive(false);
		level2_4.SetActive(false);
		level2_5.SetActive(false);
		goToLevel3.SetActive(false);
		level3_0.SetActive(true);
		groundFillLevel3.SetActive(true);

		CalculateActivePickUpCount(); // is there because to calculate the activePickups on spawn platform and there it is 0
		pickUpsText.text = "Items: " + collectedPickUps + "/" + activePickUps;

		level3_1.SetActive(true);
		groundTrigger3.SetActive(false);
	}

	private void GameStartLevelStatus()
	{
		//TODO: Player gehört hier nicht hin
		var plus = new Vector3(0.76f,0.76f,0.76f);
		player.transform.localScale = plus;


		level1_1.SetActive(true);
		openWall1_1.SetActive(true);
		level1_2.SetActive(false);
		bridge1_2.SetActive(true);

		openWall1_2.SetActive(true);
		bridge1_3.SetActive(false);
		level1_3.SetActive(false);

		openWall1_3.SetActive(true);
		bridge1_4.SetActive(false);
		level1_4.SetActive(false);

		openWall1_4.SetActive(true);
		bridge1_5.SetActive(false);
		level1_5.SetActive(false);
		rotateObject.GetComponent<RotationLevel5>().enabled = false;
		rotateObject.transform.eulerAngles = new Vector3(90, 0, -90);

		openWall1_5.SetActive(true);
		goToLevel2Bridge.SetActive(false);
		goToLevel2.SetActive(false);
		groundFillLevel2.SetActive(false);
		level2_0.SetActive(false);
		level2_1.SetActive(false);
		bridge2_1.SetActive(false);

		openWall2_1.SetActive(true);
		bridge2_2.SetActive(false);
		level2_2.SetActive(false);

		openWall2_2.SetActive(true);
		bridge2_3.SetActive(false);
		level2_3.SetActive(false);
		level2_3Enemy.transform.position = new Vector3(-39.53668f, 39.71216f, 199.0818f);
		level2_3Enemy.GetComponent<PathMover>().enabled = false;
		level2_3Enemy.SetActive(true);

		openWall2_3.SetActive(true);
		bridge2_4.SetActive(false);
		level2_4.SetActive(false);
		mover1.GetComponent<PathMover>().enabled = false;
		mover2.GetComponent<PathMover>().enabled = false;
		mover1.GetComponent<PathMover>().SetCurrentToZero();
		mover2.GetComponent<PathMover>().SetCurrentToZero();
		mover1.transform.position = new Vector3(-7.926678f, 41.77216f, 207.1318f);
		mover2.transform.position = new Vector3(8.513323f, 41.77216f, 191.0318f);
		DamageCylinderLevel2_5.GetComponent<PathMover>().enabled = false;
		DamageCylinder2Level2_5.GetComponent<PathMover>().enabled = false;

		openWall2_4.SetActive(true);
		bridge2_5.SetActive(false);
		level2_5.SetActive(false);
		/*DamageCylinderLevel2_5.GetComponent<PathMover>().enabled = false;
		DamageCylinder2Level2_5.GetComponent<PathMover>().enabled = false;*/

		openWall2_5.SetActive(true);
		bridge2_5.SetActive(false);
		goToLevel3.SetActive(false);
		level3_0.SetActive(false);
		groundFillLevel3.SetActive(false);

		level3_1.SetActive(false);
		bridge3_1.SetActive(false);
		closeWall3_1.SetActive(false);
		openWall3_1.SetActive(true);

		level3_2.SetActive(false);
		//bridge3_2.SetActive(false);
		closeWall3_2.SetActive(false);
		openWall3_2.SetActive(true);

		level3_3.SetActive(false);
		bridge3_3.SetActive(false);
		closeWall3_3.SetActive(false);
		openWall3_3.SetActive(true);


		/*level3_4.SetActive(false);
		bridge3_4.SetActive(false);
		closeWall3_4.SetActive(false);
		openWall3_4.SetActive(true);*/
	}

	public void LevelOutTriggerTurnOff()
	{
		levelOutTrigger1_1.SetActive(false);
		levelOutTrigger1_2.SetActive(false);
		levelOutTrigger1_3.SetActive(false);
		levelOutTrigger1_4.SetActive(false);
		levelOutTrigger1_5.SetActive(false);
		levelOutTrigger2_1.SetActive(false);
		levelOutTrigger2_2.SetActive(false);
		levelOutTrigger2_3.SetActive(false);
		levelOutTrigger2_4.SetActive(false);
		levelOutTrigger2_5.SetActive(false);
		levelOutTrigger3_1.SetActive(false);
		levelOutTrigger3_2.SetActive(false);
		levelOutTrigger3_3.SetActive(false);
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