using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodModePickUp : MonoBehaviour
{
	public Resetter Resetter;
	private void Start()
	{
		Resetter.AddGameObject(this);
	}
}
