using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	//UI
	public GameObject playCanvas;

	public GameObject gameOverCanvas;

	//Counter
	public Text counterText;
	private float counter;
	private TimeSpan timePlaying;
	private string timePlayingStr;

	//HUD
	public Text scoreText;
	public Text level1Text;
	public Text Level2Text;

	//HealthBar
	private float timerRedHealth = 2;
	private int timerRedHealthInt;
	private bool startTimer = false;

	//Damage
	public Transform greenHealthBar;
	public Transform redHealthBar;

	private RectTransform greenHealthBarRect;
	private RectTransform redHealthBarRect;

	//Level
	public GameObject level1;
	public GameObject openWall1;
	public GameObject level2;
	public GameObject bridge2;
	public GameObject closeWall2;

	public GameObject openWall2;

	//public GameObject level3;
	public GameObject bridge3;

	//public GameObject closeWall3;
	private int level;

	//GameOver
	public Text gameOverScoreText;
	public Text gameOverCounterText;


	//Player
	public Player player;

	public RectTransform GreenHealthBarRect => greenHealthBarRect;
	public RectTransform RedHealthBarRect => redHealthBarRect;

	public float TimerRedHealth
	{
		get => timerRedHealth;
		set => timerRedHealth = value;
	}

	public int TimerRedHealthInt
	{
		get => timerRedHealthInt;
		set => timerRedHealthInt = value;
	}

	public bool StartTimer
	{
		get => startTimer;
		set => startTimer = value;
	}


	private void Start()
	{
		SetUiSize();
		SetScoreText();
		counterText.text = "";
		level1Text.text = "";
		Level2Text.text = "";
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
		counter += Time.deltaTime;
		timePlaying = TimeSpan.FromSeconds(counter);
		timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
		counterText.text = timePlayingStr;
	}

	public void SetScoreText() //TODO rename
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
					level1Text.text = "Level 1";
					Destroy(level1Text, 2);
					break;
				case 1:
					openWall2.SetActive(false);
					bridge3.SetActive(true);
					//level3.SetActive(true);
					Level2Text.text = "Level 2";
					Destroy(Level2Text, 2);
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
				//closeWall3.SetActive(true);
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

	private void SetUiSize()
	{
		var screenWidth = Screen.width;
		var screenHeight = Screen.height;
	}
}