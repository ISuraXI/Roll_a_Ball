using UnityEngine;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
	public GameObject playerObject;
	public GameObject gameOverCanvas;
	public GameObject playCanvas;
	public Text scoreText;
	public Player player;
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
		playerObject.SetActive(false);
		playCanvas.SetActive(false);
		gameOverCanvas.SetActive(true);
		var count = player.Score;
		scoreText.text = "Score: " + count;
		counter2 = gameController.TimePlayingStr;
		counterText.text = counter2;
	}
}