using UnityEngine;

public class UiMenuController : MonoBehaviour
{
	public PickUpsResetter pickUpsResetter;
	public Player player;
	public GameController gameController;

	public void RollaBallStart()
	{
		gameController.playCanvas.SetActive(true);
		gameController.menuCanvas.SetActive(false);
		gameController.gameOverCanvas.SetActive(false);
		gameController.levelCanvas.SetActive(false);
		gameController.player.transform.position = gameController.level1BallSpawn;
		gameController.playerGameObject.SetActive(true);
		gameController.playerGameObject.transform.position = new Vector3(0, 0.55f, 0);
		gameController.mainCam.transform.Rotate(new Vector3(45, 0, 0));
		gameController.mainCam.transform.position = gameController.level1CamSpawn;
		gameController.mainCam.GetComponent<CameraController>().enabled = true;
		gameController.playerGameObject.GetComponent<Rigidbody>().isKinematic = true;
		gameController.skyboxController.SetActive(false);
		gameController.playerGameObject.GetComponent<Rigidbody>().isKinematic = false;
		player.healthParticle.GetComponent<ParticleSystem>().playOnAwake = true;
	}

	/*public void menuScene()
	{
		SceneManager.LoadScene("Menu");
	}*/

	public void RollaBallLevel2()
	{
		gameController.levelCanvas.SetActive(false);
		gameController.playCanvas.SetActive(true);
		gameController.mainCam.transform.position = gameController.level2CamSpawn;
		gameController.mainCam.transform.Rotate(new Vector3(45, 0, 0));
		gameController.mainCam.GetComponent<CameraController>().enabled = true;
		gameController.skyboxController.SetActive(false);
		gameController.level2Load = true;
	}

	public void Menu()
	{
		var camPosition = new Vector3(0, -100, 0);
		gameController.mainCam.GetComponent<CameraController>().enabled = false;
		gameController.menuCanvas.SetActive(true);
		gameController.gameOverCanvas.SetActive(false);
		gameController.playCanvas.SetActive(false);
		gameController.mainCam.transform.Rotate(new Vector3(-45, 0, 0));
		gameController.mainCam.transform.position += camPosition;
		gameController.skyboxController.SetActive(true);
	}

	public void restartGame() //TODO should be done in gameContoller
	{
		gameController.GameStartLevelStatus();
		gameController.level = 0;
		gameController.score = 0;
		gameController.collectedPickUps = 0;
		gameController.pickUpsText.text =
			"Pick-ups: " + gameController.collectedPickUps + "/" + gameController.activePickUps;
		/*gameController.collectedPickUps = -1;
		gameController.PickUpCollected();*/
		player.healthParticle.GetComponent<ParticleSystem>().playOnAwake = false;
		pickUpsResetter.ResetPickUps();
		gameController.mainCam.transform.Rotate(-45, 0, 0);
		gameController.CalculateActivePickUpCount();
		gameController.pickUpsText.text =
			"Pick-ups: " + gameController.collectedPickUps + "/" + gameController.activePickUps;
		gameController.scoreText.text = "Score: " + gameController.score;
		RollaBallStart();
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
}