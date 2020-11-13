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
	public Text counterText;
	public string counter2;


	private void Start()
	{
		gameOverText.text = "";
		scoreText.text = "";
		counterText.text = "";
	}

	private void OnTriggerEnter(Collider other)
	{
		Destroy(other.gameObject);
		playCanvas.SetActive(false);
		gameOverCanvas.SetActive(true);
		gameOverText.text = "Game Over";
		var count = myplayerController.player.Score;
		scoreText.text = "Score: " + count;
		counter2 = myplayerController.timePlayingStr;
		counterText.text = counter2;
	}
}