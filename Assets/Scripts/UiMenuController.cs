using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMenuController : MonoBehaviour
{
	public GameController gameController;

	public void RollaBallStart()
	{
		gameController.menuCanvas.SetActive(false);
		gameController.playCanvas.SetActive(true);
		gameController.mainCam.transform.position = gameController.level1CamSpawn;
		gameController.mainCam.GetComponent<CameraController>().enabled = true;
		gameController.skyboxController.SetActive(false);
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
		gameController.mainCam.GetComponent<CameraController>().enabled = true;
		gameController.skyboxController.SetActive(false);
		gameController.level2Load = true;
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