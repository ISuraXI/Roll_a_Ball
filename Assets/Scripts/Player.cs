using System;
using UnityEngine;

public class Player
{
	private int level;
	private int score;
	private int health;

	public Player()
	{
		health = 50;
	}

	public int Level => level;
	public int Score => score;
	public int Health => health;

	public int TakeDamage(int damage)
	{
		if (health - damage > 0)
		{
			health -= damage;
		}
		else
		{
			health = 0;
		}

		return health;
	}

	public int RegenerateHealth(int amount)
	{
		if (health + amount <= 100)
		{
			health += amount;
		}
		else
		{
			health = 100;
		}

		return health;
	}

	public void NextLevel()
	{
		level++;
	}

	public void IncreaseScore()
	{
		score++;
	}
}
