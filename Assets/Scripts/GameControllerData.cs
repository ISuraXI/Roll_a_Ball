using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameControllerData
{
	public int passedLevel;
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
	}

}
