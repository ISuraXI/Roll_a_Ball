using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameControllerData
{
	public int passedLevel;
	public int highscoreLevel1 = 0;
	public int highscoreLevel2 = 0;
	public int highscoreLevel3 = 0;
	public int highscoreLevel4 = 0;
	public int highscoreLevel5 = 0;
	public int highscoreLevel6 = 0;
	public int highscoreLevel7 = 0;
	public int highscoreLevel8 = 0;
	public int highscoreLevel9 = 0;
	public int highscoreLevel10 = 0;

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

	public int groundStatus;
	public int ballStatus;
	public float volume = 0.2f;
	public int coins = 0;
	public int levelStartSafe = 0;
	public bool level2Bool = false;
	public bool level3Bool = false;
	public bool levelIntroOnGo;


	public GameControllerData(GameController gameController)
	{
		passedLevel = gameController.passedLevel;
		highscoreLevel1 = gameController.highscoreLevel1;
		highscoreLevel2 = gameController.highscoreLevel2;
		highscoreLevel3 = gameController.highscoreLevel3;
		highscoreLevel4 = gameController.highscoreLevel4;
		highscoreLevel5 = gameController.highscoreLevel5;
		highscoreLevel6 = gameController.highscoreLevel6;
		highscoreLevel7 = gameController.highscoreLevel7;
		highscoreLevel8 = gameController.highscoreLevel8;
		highscoreLevel9 = gameController.highscoreLevel9;
		highscoreLevel10 = gameController.highscoreLevel10;

		ball2Unlocked = gameController.ball2Unlocked;
		ball3Unlocked = gameController.ball3Unlocked;
		ball4Unlocked = gameController.ball4Unlocked;
		ball5Unlocked = gameController.ball5Unlocked;
		ball6Unlocked = gameController.ball6Unlocked;
		ball7Unlocked = gameController.ball7Unlocked;
		ball8Unlocked = gameController.ball8Unlocked;

		ground2Unlocked = gameController.ground2Unlocked;
		ground3Unlocked = gameController.ground3Unlocked;
		ground4Unlocked = gameController.ground4Unlocked;
		ground5Unlocked = gameController.ground5Unlocked;

		groundStatus = gameController.groundStatus;
		ballStatus = gameController.ballStatus;
		volume = gameController.volume;
		coins = gameController.coins;
		levelStartSafe = gameController.levelStartSafe;
		level2Bool = gameController.level2Bool;
		level3Bool = gameController.level3Bool;
		levelIntroOnGo = gameController.levelIntroOnGO;
	}

}
