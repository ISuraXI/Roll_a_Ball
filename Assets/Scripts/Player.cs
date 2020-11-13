using UnityEngine;

public class Player
{
	private int level;
	private int score;

	public int Level => level;
	public int Score => score;

	public void NextLevel()
	{
		level++;
	}

	public void IncreaseScore()
	{
		score++;
	}
}
