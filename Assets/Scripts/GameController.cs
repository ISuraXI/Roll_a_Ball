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

	private RectTransform greenHealthBarRect;
	//public Transform redHealthBar;
	//public GameObject redHealt;

	//Player
	public Player player;

	public RectTransform GreenHealthBarRect => greenHealthBarRect;

	private void Start()
	{
		SetScoreText();
		counterText.text = "";
		level1Text.text = "";
		Level2Text.text = "";
		playCanvas.SetActive(true);
		gameOverCanvas.SetActive(false);
		greenHealthBarRect = greenHealthBar.GetComponent<RectTransform>();
		greenHealthBarRect.sizeDelta = new Vector2((player.Health * 2), 15);
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
					level1Text.text = "Stage 1 clear!";
					Destroy(level1Text, 2);
					break;
				case 1:
					openWall2.SetActive(false);
					level3.SetActive(true);
					Level2Text.text = "Stage 2 clear!";
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