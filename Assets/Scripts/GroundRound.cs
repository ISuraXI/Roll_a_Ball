using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRound : MonoBehaviour
{
	public Resetter Resetter;

	private void Start()
	{
		Resetter.AddGameObject(this);
	}
}

