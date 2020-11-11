using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
	public Text deathText;


	private void Start()
	{
		deathText.text = "";
	}

	private void OnTriggerEnter(Collider other)
	{
		Destroy(other.gameObject);
		deathText.text = "YOU DIED BITCH";
	}
}