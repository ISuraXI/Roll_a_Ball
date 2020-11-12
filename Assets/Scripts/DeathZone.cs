using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
	public GameObject gameOverCanvas;
	public GameObject playCanvas;
	public Text gameOverText;
	public Text scoreText;
	public PlayerController myplayerController;


	private void Start()
	{
		gameOverText.text = "";
		scoreText.text = "";
	}

	private void OnTriggerEnter(Collider other)
	{
		Destroy(other.gameObject);
		playCanvas.SetActive(false);
		gameOverCanvas.SetActive(true);
		gameOverText.text = "Game Over";
		var count = myplayerController.score;
		scoreText.text = "Score: " + count;
	}
}