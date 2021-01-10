using JetBrains.Annotations;
using UnityEngine;

public class UiMenuController : MonoBehaviour
{
	public Player player;
	public GameController gameController;
	public Resetter resetter;

	public GameObject BuyBallCanvas2;
	public GameObject BuyBallCanvas3;
	public GameObject BuyBallCanvas4;
	public GameObject BuyBallCanvas5;
	public GameObject BuyBallCanvas6;
	public GameObject BuyBallCanvas7;
	public GameObject BuyBallCanvas8;
	public GameObject BuyBallCanvas9;
	public GameObject BuyBallCanvas10;

	public Material ball1Material;
	public Material ball2Material;
	public Material ball3Material;
	public Material ball4Material;
	public Material ball5Material;
	public Material ball6Material;
	public Material ball7Material;
	public Material ball8Material;
	public Material ball9Material;
	public Material ball10Material;

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

	public GameObject ball2Lock;
	public GameObject ball3Lock;
	public GameObject ball4Lock;
	public GameObject ball5Lock;
	public GameObject ball6Lock;
	public GameObject ball7Lock;
	public GameObject ball8Lock;
	public GameObject ball9Lock;
	public GameObject ball10Lock;




	public GameObject BuyGroundCanvas2;
	public GameObject BuyGroundCanvas3;
	public GameObject BuyGroundCanvas4;
	public GameObject BuyGroundCanvas5;


	public Material ground1Material;
	public Material ground2Material;
	public Material ground2_1Material;
	public Material ground3Material;
	public Material ground3_1Material;
	public Material ground4Material;
	public Material ground4_1Material;
	public Material ground5Material;
	public Material ground5_1Material;


	public GameObject ground1Check;
	public GameObject ground2Check;
	public GameObject ground3Check;
	public GameObject ground4Check;
	public GameObject ground5Check;

	public GameObject ground2Lock;
	public GameObject ground3Lock;
	public GameObject ground4Lock;
	public GameObject ground5Lock;


	public GameObject groundFill2;
	public GameObject groundFill1;

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
		if (gameController.pauseCanvas.activeSelf)
		{
			gameController.menuCanvas.SetActive(false);
		}
		else
		{
			gameController.menuCanvas.SetActive(true);
		}
		gameController.levelCanvas.SetActive(false);
		gameController.shopBallCanvas.SetActive(false);
		gameController.shopGroundCanvas.SetActive(false);
		gameController.settingsCanvas.SetActive(false);
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

	public void KlickOnSettings()
	{
		gameController.settingsCanvas.SetActive(true);
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

	public void BallSetter()
	{
		if (gameController.ballStatus == 1)
		{
			ShopBall1();
		}
		else if (gameController.ballStatus == 2)
		{
			ShopBall2();
		}
		else if (gameController.ballStatus == 3)
		{
			ShopBall3();
		}
		else if (gameController.ballStatus == 4)
		{
			ShopBall4();
		}
		else if (gameController.ballStatus == 5)
		{
			ShopBall5();
		}
		else if (gameController.ballStatus == 6)
		{
			ShopBall6();
		}
		else if (gameController.ballStatus == 7)
		{
			ShopBall7();
		}
		else if (gameController.ballStatus == 8)
		{
			ShopBall8();
		}
		else if (gameController.ballStatus == 9)
		{
			ShopBall9();
		}
		else if (gameController.ballStatus == 10)
		{
			ShopBall10();
		}
	}

	public void CloseBuyCanvas()
	{
		BuyBallCanvas2.SetActive(false);
		BuyBallCanvas3.SetActive(false);
		BuyBallCanvas4.SetActive(false);
		BuyBallCanvas5.SetActive(false);
		BuyBallCanvas6.SetActive(false);
		BuyBallCanvas7.SetActive(false);
		BuyBallCanvas8.SetActive(false);
		BuyBallCanvas9.SetActive(false);
		BuyBallCanvas10.SetActive(false);

		BuyGroundCanvas2.SetActive(false);
		BuyGroundCanvas3.SetActive(false);
		BuyGroundCanvas4.SetActive(false);
		BuyGroundCanvas5.SetActive(false);
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
		gameController.ballStatus = 1;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball1Material;
		UncheckAllCheckImages();
		ball1Check.SetActive(true);
	}

	public void ClickOnBall2()
	{
		if (ball2Lock.activeSelf)
		{
			BuyBallCanvas2.SetActive(true);
		}
		else
		{
			ShopBall2();
		}
	}

	public void ClickOnBuyBall2()
	{
		if (gameController.coins >= 20)
		{
			gameController.coins = gameController.coins - 20;
			ShopBall2();
			BuyBallCanvas2.SetActive(false);
		}
	}

	public void ShopBall2()
	{
		gameController.ballStatus = 2;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball2Material;
		UncheckAllCheckImages();
		ball2Lock.SetActive(false);
		ball2Check.SetActive(true);
		gameController.ball2Unlocked = true;
	}

	public void UnlockBall2()
	{
		ball2Lock.SetActive(false);
	}

	public void ClickOnBall3()
	{
		if (ball3Lock.activeSelf)
		{
			BuyBallCanvas3.SetActive(true);
		}
		else
		{
			ShopBall3();
		}
	}

	public void ClickOnBuyBall3()
	{
		if (gameController.coins >= 20)
		{
			gameController.coins = gameController.coins - 20;
			ShopBall3();
			BuyBallCanvas3.SetActive(false);
		}
	}

	public void ShopBall3()
	{
		gameController.ballStatus = 3;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball3Material;
		UncheckAllCheckImages();
		ball3Check.SetActive(true);
		ball3Lock.SetActive(false);
		gameController.ball3Unlocked = true;
	}

	public void UnlockBall3()
	{
		ball3Lock.SetActive(false);
	}

	public void ClickOnBall4()
	{
		if (ball4Lock.activeSelf)
		{
			BuyBallCanvas4.SetActive(true);
		}
		else
		{
			ShopBall4();
		}
	}

	public void ClickOnBuyBall4()
	{
		if (gameController.coins >= 20)
		{
			gameController.coins = gameController.coins - 20;

			ShopBall4();
			BuyBallCanvas4.SetActive(false);
		}
	}

	public void ShopBall4()
	{
		gameController.ballStatus = 4;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball4Material;
		UncheckAllCheckImages();
		ball4Check.SetActive(true);
		ball4Lock.SetActive(false);
		gameController.ball4Unlocked = true;
	}

	public void UnlockBall4()
	{
		ball4Lock.SetActive(false);
	}

	public void ShopBall5()
	{
		gameController.ballStatus = 5;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball5Material;
		UncheckAllCheckImages();
		ball5Lock.SetActive(false);
		ball5Check.SetActive(true);
	}

	public void ClickOnBall6()
	{
		if (ball6Lock.activeSelf)
		{
			BuyBallCanvas6.SetActive(true);
		}
		else
		{
			ShopBall6();
		}
	}

	public void ClickOnBuyBall6()
	{
		if (gameController.coins >= 100)
		{
			gameController.coins = gameController.coins - 100;
			ShopBall6();
			BuyBallCanvas6.SetActive(false);
		}
	}

	public void ShopBall6()
	{
		gameController.ballStatus = 6;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball6Material;
		UncheckAllCheckImages();
		ball6Check.SetActive(true);
		ball6Lock.SetActive(false);
		gameController.ball6Unlocked = true;
	}

	public void UnlockBall6()
	{
		ball6Lock.SetActive(false);
	}

	public void ClickOnBall7()
	{
		if (ball7Lock.activeSelf)
		{
			BuyBallCanvas7.SetActive(true);
		}
		else
		{
			ShopBall7();
		}
	}

	public void ClickOnBuyBall7()
	{
		if (gameController.coins >= 100)
		{
			gameController.coins = gameController.coins - 100;
			ShopBall7();
			BuyBallCanvas7.SetActive(false);
		}
	}

	public void ShopBall7()
	{
		gameController.ballStatus = 7;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball7Material;
		UncheckAllCheckImages();
		ball7Check.SetActive(true);
		ball7Lock.SetActive(false);
		gameController.ball7Unlocked = true;
	}

	public void UnlockBall7()
	{
		ball7Lock.SetActive(false);
	}

	public void ClickOnBall8()
	{
		if (ball8Lock.activeSelf)
		{
			BuyBallCanvas8.SetActive(true);
		}
		else
		{
			ShopBall8();
		}
	}

	public void ClickOnBuyBall8()
	{
		if (gameController.coins >= 100)
		{
			gameController.coins = gameController.coins - 100;
			ShopBall8();
			BuyBallCanvas8.SetActive(false);
		}
	}

	public void ShopBall8()
	{
		gameController.ballStatus = 8;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball8Material;
		UncheckAllCheckImages();
		ball8Check.SetActive(true);
		ball8Lock.SetActive(false);
		gameController.ball8Unlocked = true;
	}

	public void UnlockBall8()
	{
		ball8Lock.SetActive(false);
	}

	public void ClickOnBall9()
	{
		if (ball9Lock.activeSelf)
		{
			BuyBallCanvas9.SetActive(true);
		}
		else
		{
			ShopBall9();
		}
	}

	public void ClickOnBuyBall9()
	{
		if (gameController.coins >= 100)
		{
			gameController.coins = gameController.coins - 100;
			ShopBall9();
			BuyBallCanvas9.SetActive(false);
		}
	}

	public void ShopBall9()
	{
		gameController.ballStatus = 9;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball9Material;
		UncheckAllCheckImages();
		ball9Check.SetActive(true);
		ball9Lock.SetActive(false);
		gameController.ball9Unlocked = true;
	}

	public void UnlockBall9()
	{
		ball9Lock.SetActive(false);
	}

	public void ShopBall10()
	{
		gameController.ballStatus = 10;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball10Material;
		UncheckAllCheckImages();
		ball10Lock.SetActive(false);
		ball10Check.SetActive(true);
	}


	public void GroundSetter()
	{
		if (gameController.groundStatus == 1)
		{
			resetter.SetGround1();
		}
		else if (gameController.groundStatus == 2)
		{
			resetter.SetGround2();
		}
		else if (gameController.groundStatus == 3)
		{
			resetter.SetGround3();
		}
		else if (gameController.groundStatus == 4)
		{
			resetter.SetGround4();
		}
		else if (gameController.groundStatus == 5)
		{
			resetter.SetGround5();
		}
	}

	private void UncheckAllGroundCheckImages()
	{
		ground1Check.SetActive(false);
		ground2Check.SetActive(false);
		ground3Check.SetActive(false);
		ground4Check.SetActive(false);
		ground5Check.SetActive(false);
	}

	public void ShopGround1()
	{
		UncheckAllGroundCheckImages();
		ground1Check.SetActive(true);
		groundFill1.GetComponent<MeshRenderer>().material = ground1Material;
		groundFill2.GetComponent<MeshRenderer>().material = ground1Material;
		gameController.groundStatus = 1;
	}

	public void ClickOnGround2()
	{
		if (ground2Lock.activeSelf)
		{
			BuyGroundCanvas2.SetActive(true);
		}
		else
		{
			resetter.SetGround2();
		}
	}

	public void ClickOnBuyGround2()
	{
		if (gameController.coins >= 50)
		{
			gameController.coins = gameController.coins - 50;
			resetter.SetGround2();
			BuyGroundCanvas2.SetActive(false);
		}
	}

	public void ShopGround2()
	{
		UncheckAllGroundCheckImages();
		ground2Check.SetActive(true);
		groundFill1.GetComponent<MeshRenderer>().material = ground2_1Material;
		groundFill2.GetComponent<MeshRenderer>().material = ground2_1Material;
		gameController.groundStatus = 2;
		ground2Lock.SetActive(false);
		gameController.ground2Unlocked = true;
	}

	public void UnlockGround2()
	{
		ground2Lock.SetActive(false);
	}

	public void ClickOnGround3()
	{
		if (ground3Lock.activeSelf)
		{
			BuyGroundCanvas3.SetActive(true);
		}
		else
		{
			resetter.SetGround3();
		}
	}

	public void ClickOnBuyGround3()
	{
		if (gameController.coins >= 100)
		{
			gameController.coins = gameController.coins - 100;
			resetter.SetGround3();
			BuyGroundCanvas3.SetActive(false);
		}
	}

	public void ShopGround3()
	{
		UncheckAllGroundCheckImages();
		ground3Check.SetActive(true);
		groundFill1.GetComponent<MeshRenderer>().material = ground3_1Material;
		groundFill2.GetComponent<MeshRenderer>().material = ground3_1Material;
		gameController.groundStatus = 3;
		ground3Lock.SetActive(false);
		gameController.ground3Unlocked = true;
	}

	public void UnlockGround3()
	{
		ground3Lock.SetActive(false);
	}

	public void ClickOnGround4()
	{
		if (ground4Lock.activeSelf)
		{
			BuyGroundCanvas4.SetActive(true);
		}
		else
		{
			resetter.SetGround4();
		}
	}

	public void ClickOnBuyGround4()
	{
		if (gameController.coins >= 150)
		{
			gameController.coins = gameController.coins - 150;
			resetter.SetGround4();
			BuyGroundCanvas4.SetActive(false);
		}
	}

	public void ShopGround4()
	{
		UncheckAllGroundCheckImages();
		ground4Check.SetActive(true);
		groundFill1.GetComponent<MeshRenderer>().material = ground4_1Material;
		groundFill2.GetComponent<MeshRenderer>().material = ground4_1Material;
		gameController.groundStatus = 4;
		ground4Lock.SetActive(false);
		gameController.ground4Unlocked = true;
	}

	public void UnlockGround4()
	{
		ground4Lock.SetActive(false);
	}

	public void ClickOnGround5()
	{
		if (ground5Lock.activeSelf)
		{
			BuyGroundCanvas5.SetActive(true);
		}
		else
		{
			resetter.SetGround5();
		}
	}

	public void ClickOnBuyGround5()
	{
		if (gameController.coins >= 200)
		{
			gameController.coins = gameController.coins - 200;
			resetter.SetGround5();
			BuyGroundCanvas5.SetActive(false);
		}
	}

	public void ShopGround5()
	{
		UncheckAllGroundCheckImages();
		ground5Check.SetActive(true);
		groundFill1.GetComponent<MeshRenderer>().material = ground5_1Material;
		groundFill2.GetComponent<MeshRenderer>().material = ground5_1Material;
		gameController.groundStatus = 5;
		ground5Lock.SetActive(false);
		gameController.ground5Unlocked = true;
	}

	public void UnlockGround5()
	{
		ground5Lock.SetActive(false);
	}
}