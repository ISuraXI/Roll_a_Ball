using UnityEngine;

public class UiMenuController : MonoBehaviour
{
	public Player player;
	public GameController gameController;

	public Material ball1;
	public Material ball2;
	public Material ball3;
	public Material ball4;
	public Material ball5;
	public Material ball6;
	public Material ball7;
	public Material ball8;
	public Material ball9;
	public Material ball10;

	public GameObject ball1Check;
	public GameObject ball2Check;
	public GameObject ball3Check;
	public GameObject ball4Check;
	public GameObject ball5Check;
	public GameObject ball6Check;
	public GameObject ball7Check;
	public GameObject ball8Check;
	public GameObject ball9Check;
	public GameObject ball10Check;


	public void Menu()
	{
		player.gameObject.SetActive(false);
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

	public void KlickOnShop()
	{
		gameController.menuCanvas.SetActive(false);
		gameController.shopBallCanvas.SetActive(true);
	}

	public void KlickOnBack()
	{
		gameController.menuCanvas.SetActive(true);
		gameController.levelCanvas.SetActive(false);
		gameController.shopBallCanvas.SetActive(false);
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

	public void KlickOnGrounds()
	{
		gameController.shopGroundCanvas.SetActive(true);
		gameController.shopBallCanvas.SetActive(false);
	}

	public void KlickOnBalls()
	{
		gameController.shopBallCanvas.SetActive(true);
		gameController.shopGroundCanvas.SetActive(false);
	}

	private void UncheckAllCheckImages()
	{
		ball1Check.SetActive(false);
		ball2Check.SetActive(false);
		ball3Check.SetActive(false);
		ball4Check.SetActive(false);
		ball5Check.SetActive(false);
		ball6Check.SetActive(false);
		ball7Check.SetActive(false);
		ball8Check.SetActive(false);
		ball9Check.SetActive(false);
		ball10Check.SetActive(false);
	}

	public void ShopBall1()
	{
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball1;
		UncheckAllCheckImages();
		ball1Check.SetActive(true);
	}

	public void ShopBall2()
	{
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball2;
		UncheckAllCheckImages();
		ball2Check.SetActive(true);
	}

	public void ShopBall3()
	{
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball3;
		UncheckAllCheckImages();
		ball3Check.SetActive(true);
	}

	public void ShopBall4()
	{
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball4;
		UncheckAllCheckImages();
		ball4Check.SetActive(true);
	}

	public void ShopBall5()
	{
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball5;
		UncheckAllCheckImages();
		ball5Check.SetActive(true);
	}

	public void ShopBall6()
	{
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball6;
		UncheckAllCheckImages();
		ball6Check.SetActive(true);
	}

	public void ShopBall7()
	{
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball7;
		UncheckAllCheckImages();
		ball7Check.SetActive(true);
	}

	public void ShopBall8()
	{
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball8;
		UncheckAllCheckImages();
		ball8Check.SetActive(true);
	}

	public void ShopBall9()
	{
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball9;
		UncheckAllCheckImages();
		ball9Check.SetActive(true);
	}

	public void ShopBall10()
	{
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball10;
		UncheckAllCheckImages();
		ball10Check.SetActive(true);
	}
}