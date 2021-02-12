using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidingNumber : MonoBehaviour
{
	public Text scoreText;

	//private float animationTime = 0.2f;
	private float desiredNumber;
	private float initialNumber;
	private float currentNumber;

	public void SetNumber(float value)
	{
		initialNumber = currentNumber;
		desiredNumber = value;
	}

	public void AddToNumber(float value)
	{
		initialNumber = currentNumber;
		desiredNumber += value;
	}

	public void Update()
	{
		if (currentNumber != desiredNumber)
		{
			if (initialNumber < desiredNumber)
			{
				currentNumber += (2f * Time.deltaTime) * (desiredNumber - initialNumber);
				if (currentNumber >= desiredNumber)
					currentNumber = desiredNumber;
			}
			else
			{
				currentNumber -= (2f * Time.deltaTime) * (initialNumber - desiredNumber);
				if (currentNumber <= desiredNumber)
					currentNumber = desiredNumber;
			}

			scoreText.text = "Score: " + currentNumber.ToString("0");
		}
	}
}
