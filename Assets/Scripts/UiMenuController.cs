using UnityEditor;
using UnityEngine;

public class UiMenuController : MonoBehaviour
{
	public Resetter resetter;
	public Player player;
	public GameController gameController;

	public void Menu()
	{
		Time.timeScale = 1;
		var camPosition = new Vector3(0, -100, 0);
		gameController.mainCam.GetComponent<CameraController>().enabled = false;
		gameController.menuCanvas.SetActive(true);
		gameController.gameOverCanvas.SetActive(false);
		gameController.pauseCanvas.SetActive(false);
		gameController.playCanvas.SetActive(false);
		gameController.mainCam.transform.Rotate(new Vector3(-45, 0, 0));
		gameController.mainCam.transform.position += camPosition;
		gameController.skyboxController.SetActive(true);
	}

	public void KlickOnLevel()
	{
		gameController.menuCanvas.SetActive(false);
		gameController.levelCanvas.SetActive(true);
	}

	public void KlickOnBack()
	{
		gameController.menuCanvas.SetActive(true);
		gameController.levelCanvas.SetActive(false);
	}

	public void KlickOnResume()
	{
		Time.timeScale = 1;
		gameController.pauseCanvas.SetActive(false);
	}

	public void KlickOnPause()
	{
		gameController.pauseCanvas.SetActive(true);
		Time.timeScale = 0;
	}


	/*public void restartGame() //TODO should be done in gameContoller
	{
		gameController.GameStartLevelStatus();
		gameController.level = 0;
		var score = 0;
		var collectedPickUps = 0;
		var activePickUps = 0;
		gameController.pickUpsText.text = "Pick-ups: " + collectedPickUps + "/" + activePickUps;
		gameController.scoreText.text = "Score: " + score;
		gameController.mainCam.transform.Rotate(-45, 0, 0);

		player.Reset();
		Resetter.ResetAll();
		gameController.CalculateActivePickUpCount();
		gameController.StartGame();
	}*/

	/*public void RollaBallLevel2()
	{



		player.GetComponent<Rigidbody>().isKinematic = false;
		gameController.levelCanvas.SetActive(false);
		gameController.playCanvas.SetActive(true);
		gameController.mainCam.transform.position = gameController.level2CamSpawn;
		gameController.mainCam.transform.Rotate(new Vector3(45, 0, 0));
		gameController.mainCam.GetComponent<CameraController>().enabled = true;
		gameController.skyboxController.SetActive(false);
		gameController.level2Load = true;
	}*/
}