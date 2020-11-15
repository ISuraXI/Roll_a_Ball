using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
	public GameObject player;
	public GameObject gameOverCanvas;
	public GameObject playCanvas;
	public Text gameOverText;
	public Text scoreText;
	public PlayerController playerController;
	public GameController gameController;
	public Text counterText;
	public string counter2;


	private void Start()
	{
		scoreText.text = "";
		counterText.text = "";
	}

	private void OnTriggerEnter(Collider other)
	{
		player.SetActive(false);
		playCanvas.SetActive(false);
		gameOverCanvas.SetActive(true);
		var count = playerController.player.Score;
		scoreText.text = "Score: " + count;
		counter2 = gameController.TimePlayingStr;
		counterText.text = counter2;
	}
}