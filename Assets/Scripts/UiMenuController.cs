using JetBrains.Annotations;
using UnityEngine;

public class UiMenuController : MonoBehaviour
{
	public Player player;
	public GameController gameController;

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

	public GameObject groundLevel1_1;
	public GameObject groundLevel1_2;
	public GameObject groundLevel1_3;
	public GameObject groundLevel1_4;
	public GameObject groundLevel1_5;
	public GameObject groundLevelGoToLevel2;

	public GameObject groundLevel2_0_1;
	public GameObject groundLevel2_0_2;
	public GameObject groundLevel2_1;
	public GameObject groundLevel2_2_1;
	public GameObject groundLevel2_2_2;
	public GameObject groundLevel2_2_3;
	public GameObject groundLevel2_2_4;
	public GameObject groundLevel2_2_5;
	public GameObject groundLevel2_2_6;
	public GameObject groundLevel2_2_7;
	public GameObject groundLevel2_2_8;
	public GameObject groundLevel2_2_9;
	public GameObject groundLevel2_3;
	public GameObject groundLevel2_4_1;
	public GameObject groundLevel2_4_2;
	public GameObject groundLevel2_4_3;
	public GameObject groundLevel2_4_4;
	public GameObject groundLevel2_4_5;
	public GameObject groundLevel2_5;
	public GameObject groundLevelGoToLevel3;

	public GameObject groundLevel3_0_1;
	public GameObject groundLevel3_0_2;
	public GameObject groundLevel3_1;
	/*public GameObject groundLevel3_2;
	public GameObject groundLevel3_3;
	public GameObject groundLevel3_4;
	public GameObject groundLevel3_5;
	public GameObject groundLevelGoToLevel4;*/

	/*public GameObject bridgeLevel1_1;
	public GameObject bridgeLevel1_2;
	public GameObject bridgeLevel1_3;
	public GameObject bridgeLevel1_4_1;
	public GameObject bridgeLevel1_4_2;
	public GameObject bridgeLevel1_5;
	public GameObject bridgeLevelGoToLevel2;

	public GameObject bridgeLevel2_1;
	public GameObject bridgeLevel2_2;
	public GameObject bridgeLevel2_3;
	public GameObject bridgeLevel2_4;
	public GameObject bridgeLevel2_5;
	public GameObject bridgeLevelGoToLevel3_1;
	public GameObject bridgeLevelGoToLevel3_2;*/



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
		gameController.shopGroundCanvas.SetActive(false);
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

	public void ShopBall2()
	{
		gameController.ballStatus = 2;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball2Material;
		UncheckAllCheckImages();
		ball2Check.SetActive(true);
	}

	public void ShopBall3()
	{
		gameController.ballStatus = 3;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball3Material;
		UncheckAllCheckImages();
		ball3Check.SetActive(true);
	}

	public void ShopBall4()
	{
		gameController.ballStatus = 4;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball4Material;
		UncheckAllCheckImages();
		ball4Check.SetActive(true);
	}

	public void ShopBall5()
	{
		gameController.ballStatus = 5;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball5Material;
		UncheckAllCheckImages();
		ball5Check.SetActive(true);
	}

	public void ShopBall6()
	{
		gameController.ballStatus = 6;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball6Material;
		UncheckAllCheckImages();
		ball6Check.SetActive(true);
	}

	public void ShopBall7()
	{
		gameController.ballStatus = 7;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball7Material;
		UncheckAllCheckImages();
		ball7Check.SetActive(true);
	}

	public void ShopBall8()
	{
		gameController.ballStatus = 8;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball8Material;
		UncheckAllCheckImages();
		ball8Check.SetActive(true);
	}

	public void ShopBall9()
	{
		gameController.ballStatus = 9;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball9Material;
		UncheckAllCheckImages();
		ball9Check.SetActive(true);
	}

	public void ShopBall10()
	{
		gameController.ballStatus = 10;
		gameController.playerGameObject.GetComponent<MeshRenderer>().material = ball10Material;
		UncheckAllCheckImages();
		ball10Check.SetActive(true);
	}


	public void GroundSetter()
	{
		if (gameController.groundStatus == 1)
		{
			ShopGround1();
		}
		else if (gameController.groundStatus == 2)
		{
			ShopGround2();
		}
		else if (gameController.groundStatus == 3)
		{
			ShopGround3();
		}
		else if (gameController.groundStatus == 4)
		{
			ShopGround4();
		}
		else if (gameController.groundStatus == 5)
		{
			ShopGround5();
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
		gameController.groundStatus = 1;

		groundLevel1_1.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel1_2.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel1_3.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel1_4.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel1_5.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevelGoToLevel2.GetComponent<MeshRenderer>().material = ground1Material;

		groundLevel2_0_1.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel2_0_2.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel2_1.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel2_2_1.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel2_2_2.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel2_2_3.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel2_2_4.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel2_2_5.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel2_2_6.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel2_2_7.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel2_2_8.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel2_2_9.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel2_3.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel2_4_1.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel2_4_2.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel2_4_3.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel2_4_4.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel2_4_5.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel2_5.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevelGoToLevel3.GetComponent<MeshRenderer>().material = ground1Material;

		groundLevel3_0_1.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel3_0_2.GetComponent<MeshRenderer>().material = ground1Material;
		groundLevel3_1.GetComponent<MeshRenderer>().material = ground1Material;


		/*bridgeLevel1_1.GetComponent<MeshRenderer>().material = ground1Material;
		bridgeLevel1_2.GetComponent<MeshRenderer>().material = ground1Material;
		bridgeLevel1_3.GetComponent<MeshRenderer>().material = ground1Material;
		bridgeLevel1_4_1.GetComponent<MeshRenderer>().material = ground1Material;
		bridgeLevel1_4_2.GetComponent<MeshRenderer>().material = ground1Material;
		bridgeLevel1_5.GetComponent<MeshRenderer>().material = ground1Material;
		bridgeLevelGoToLevel2.GetComponent<MeshRenderer>().material = ground1Material;

		bridgeLevel2_1.GetComponent<MeshRenderer>().material = ground1Material;
		bridgeLevel2_2.GetComponent<MeshRenderer>().material = ground1Material;
		bridgeLevel2_3.GetComponent<MeshRenderer>().material = ground1Material;
		bridgeLevel2_4.GetComponent<MeshRenderer>().material = ground1Material;
		bridgeLevel2_5.GetComponent<MeshRenderer>().material = ground1Material;
		bridgeLevelGoToLevel3_1.GetComponent<MeshRenderer>().material = ground1Material;
		bridgeLevelGoToLevel3_2.GetComponent<MeshRenderer>().material = ground1Material;*/
	}

	public void ShopGround2()
	{
		UncheckAllGroundCheckImages();
		ground2Check.SetActive(true);
		gameController.groundStatus = 2;


		groundLevel1_1.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel1_2.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel1_3.GetComponent<MeshRenderer>().material = ground2_1Material;
		groundLevel1_4.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel1_5.GetComponent<MeshRenderer>().material = ground2_1Material;
		groundLevelGoToLevel2.GetComponent<MeshRenderer>().material = ground2Material;

		groundLevel2_0_1.GetComponent<MeshRenderer>().material = ground2_1Material;
		groundLevel2_0_2.GetComponent<MeshRenderer>().material = ground2_1Material;
		groundLevel2_1.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel2_2_1.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel2_2_2.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel2_2_3.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel2_2_4.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel2_2_5.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel2_2_6.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel2_2_7.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel2_2_8.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel2_2_9.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel2_3.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel2_4_1.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel2_4_2.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel2_4_3.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel2_4_4.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel2_4_5.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevel2_5.GetComponent<MeshRenderer>().material = ground2Material;
		groundLevelGoToLevel3.GetComponent<MeshRenderer>().material = ground2Material;

		groundLevel3_0_1.GetComponent<MeshRenderer>().material = ground2_1Material;
		groundLevel3_0_2.GetComponent<MeshRenderer>().material = ground2_1Material;
		groundLevel3_1.GetComponent<MeshRenderer>().material = ground2Material;


		/*bridgeLevel1_1.GetComponent<MeshRenderer>().material = ground2Material;
		bridgeLevel1_2.GetComponent<MeshRenderer>().material = ground2Material;
		bridgeLevel1_3.GetComponent<MeshRenderer>().material = ground2Material;
		bridgeLevel1_4_1.GetComponent<MeshRenderer>().material = ground2Material;
		bridgeLevel1_4_2.GetComponent<MeshRenderer>().material = ground2Material;
		bridgeLevel1_5.GetComponent<MeshRenderer>().material = ground2Material;
		bridgeLevelGoToLevel2.GetComponent<MeshRenderer>().material = ground2Material;

		bridgeLevel2_1.GetComponent<MeshRenderer>().material = ground2Material;
		bridgeLevel2_2.GetComponent<MeshRenderer>().material = ground2Material;
		bridgeLevel2_3.GetComponent<MeshRenderer>().material = ground2Material;
		bridgeLevel2_4.GetComponent<MeshRenderer>().material = ground2Material;
		bridgeLevel2_5.GetComponent<MeshRenderer>().material = ground2Material;
		bridgeLevelGoToLevel3_1.GetComponent<MeshRenderer>().material = ground2Material;
		bridgeLevelGoToLevel3_2.GetComponent<MeshRenderer>().material = ground2Material;*/
	}

	public void ShopGround3()
	{
		UncheckAllGroundCheckImages();
		ground3Check.SetActive(true);
		gameController.groundStatus = 3;


		groundLevel1_1.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel1_2.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel1_3.GetComponent<MeshRenderer>().material = ground3_1Material;
		groundLevel1_4.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel1_5.GetComponent<MeshRenderer>().material = ground3_1Material;
		groundLevelGoToLevel2.GetComponent<MeshRenderer>().material = ground3Material;

		groundLevel2_0_1.GetComponent<MeshRenderer>().material = ground3_1Material;
		groundLevel2_0_2.GetComponent<MeshRenderer>().material = ground3_1Material;
		groundLevel2_1.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel2_2_1.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel2_2_2.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel2_2_3.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel2_2_4.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel2_2_5.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel2_2_6.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel2_2_7.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel2_2_8.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel2_2_9.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel2_3.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel2_4_1.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel2_4_2.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel2_4_3.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel2_4_4.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel2_4_5.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevel2_5.GetComponent<MeshRenderer>().material = ground3Material;
		groundLevelGoToLevel3.GetComponent<MeshRenderer>().material = ground3Material;

		groundLevel3_0_1.GetComponent<MeshRenderer>().material = ground3_1Material;
		groundLevel3_0_2.GetComponent<MeshRenderer>().material = ground3_1Material;
		groundLevel3_1.GetComponent<MeshRenderer>().material = ground3Material;


		/*bridgeLevel1_1.GetComponent<MeshRenderer>().material = ground3Material;
		bridgeLevel1_2.GetComponent<MeshRenderer>().material = ground3Material;
		bridgeLevel1_3.GetComponent<MeshRenderer>().material = ground3Material;
		bridgeLevel1_4_1.GetComponent<MeshRenderer>().material = ground3Material;
		bridgeLevel1_4_2.GetComponent<MeshRenderer>().material = ground3Material;
		bridgeLevel1_5.GetComponent<MeshRenderer>().material = ground3Material;
		bridgeLevelGoToLevel2.GetComponent<MeshRenderer>().material = ground3Material;

		bridgeLevel2_1.GetComponent<MeshRenderer>().material = ground3Material;
		bridgeLevel2_2.GetComponent<MeshRenderer>().material = ground3Material;
		bridgeLevel2_3.GetComponent<MeshRenderer>().material = ground3Material;
		bridgeLevel2_4.GetComponent<MeshRenderer>().material = ground3Material;
		bridgeLevel2_5.GetComponent<MeshRenderer>().material = ground3Material;
		bridgeLevelGoToLevel3_1.GetComponent<MeshRenderer>().material = ground3Material;
		bridgeLevelGoToLevel3_2.GetComponent<MeshRenderer>().material = ground3Material;*/
	}

	public void ShopGround4()
	{
		UncheckAllGroundCheckImages();
		ground4Check.SetActive(true);
		gameController.groundStatus = 4;


		groundLevel1_1.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel1_2.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel1_3.GetComponent<MeshRenderer>().material = ground4_1Material;
		groundLevel1_4.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel1_5.GetComponent<MeshRenderer>().material = ground4_1Material;
		groundLevelGoToLevel2.GetComponent<MeshRenderer>().material = ground4Material;

		groundLevel2_0_1.GetComponent<MeshRenderer>().material = ground4_1Material;
		groundLevel2_0_2.GetComponent<MeshRenderer>().material = ground4_1Material;
		groundLevel2_1.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel2_2_1.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel2_2_2.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel2_2_3.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel2_2_4.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel2_2_5.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel2_2_6.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel2_2_7.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel2_2_8.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel2_2_9.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel2_3.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel2_4_1.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel2_4_2.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel2_4_3.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel2_4_4.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel2_4_5.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevel2_5.GetComponent<MeshRenderer>().material = ground4Material;
		groundLevelGoToLevel3.GetComponent<MeshRenderer>().material = ground4Material;

		groundLevel3_0_1.GetComponent<MeshRenderer>().material = ground4_1Material;
		groundLevel3_0_2.GetComponent<MeshRenderer>().material = ground4_1Material;
		groundLevel3_1.GetComponent<MeshRenderer>().material = ground4Material;


		/*bridgeLevel1_1.GetComponent<MeshRenderer>().material = ground4Material;
		bridgeLevel1_2.GetComponent<MeshRenderer>().material = ground4Material;
		bridgeLevel1_3.GetComponent<MeshRenderer>().material = ground4Material;
		bridgeLevel1_4_1.GetComponent<MeshRenderer>().material = ground4Material;
		bridgeLevel1_4_2.GetComponent<MeshRenderer>().material = ground4Material;
		bridgeLevel1_5.GetComponent<MeshRenderer>().material = ground4Material;
		bridgeLevelGoToLevel2.GetComponent<MeshRenderer>().material = ground4Material;

		bridgeLevel2_1.GetComponent<MeshRenderer>().material = ground4Material;
		bridgeLevel2_2.GetComponent<MeshRenderer>().material = ground4Material;
		bridgeLevel2_3.GetComponent<MeshRenderer>().material = ground4Material;
		bridgeLevel2_4.GetComponent<MeshRenderer>().material = ground4Material;
		bridgeLevel2_5.GetComponent<MeshRenderer>().material = ground4Material;
		bridgeLevelGoToLevel3_1.GetComponent<MeshRenderer>().material = ground4Material;
		bridgeLevelGoToLevel3_2.GetComponent<MeshRenderer>().material = ground4Material;*/
	}

	public void ShopGround5()
	{
		UncheckAllGroundCheckImages();
		ground5Check.SetActive(true);
		gameController.groundStatus = 5;


		groundLevel1_1.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel1_2.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel1_3.GetComponent<MeshRenderer>().material = ground5_1Material;
		groundLevel1_4.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel1_5.GetComponent<MeshRenderer>().material = ground5_1Material;
		groundLevelGoToLevel2.GetComponent<MeshRenderer>().material = ground5Material;

		groundLevel2_0_1.GetComponent<MeshRenderer>().material = ground5_1Material;
		groundLevel2_0_2.GetComponent<MeshRenderer>().material = ground5_1Material;
		groundLevel2_1.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel2_2_1.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel2_2_2.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel2_2_3.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel2_2_4.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel2_2_5.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel2_2_6.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel2_2_7.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel2_2_8.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel2_2_9.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel2_3.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel2_4_1.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel2_4_2.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel2_4_3.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel2_4_4.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel2_4_5.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevel2_5.GetComponent<MeshRenderer>().material = ground5Material;
		groundLevelGoToLevel3.GetComponent<MeshRenderer>().material = ground5Material;

		groundLevel3_0_1.GetComponent<MeshRenderer>().material = ground5_1Material;
		groundLevel3_0_2.GetComponent<MeshRenderer>().material = ground5_1Material;
		groundLevel3_1.GetComponent<MeshRenderer>().material = ground5Material;


		/*bridgeLevel1_1.GetComponent<MeshRenderer>().material = ground5Material;
		bridgeLevel1_2.GetComponent<MeshRenderer>().material = ground5Material;
		bridgeLevel1_3.GetComponent<MeshRenderer>().material = ground5Material;
		bridgeLevel1_4_1.GetComponent<MeshRenderer>().material = ground5Material;
		bridgeLevel1_4_2.GetComponent<MeshRenderer>().material = ground5Material;
		bridgeLevel1_5.GetComponent<MeshRenderer>().material = ground5Material;
		bridgeLevelGoToLevel2.GetComponent<MeshRenderer>().material = ground5Material;

		bridgeLevel2_1.GetComponent<MeshRenderer>().material = ground5Material;
		bridgeLevel2_2.GetComponent<MeshRenderer>().material = ground5Material;
		bridgeLevel2_3.GetComponent<MeshRenderer>().material = ground5Material;
		bridgeLevel2_4.GetComponent<MeshRenderer>().material = ground5Material;
		bridgeLevel2_5.GetComponent<MeshRenderer>().material = ground5Material;
		bridgeLevelGoToLevel3_1.GetComponent<MeshRenderer>().material = ground5Material;
		bridgeLevelGoToLevel3_2.GetComponent<MeshRenderer>().material = ground5Material;*/
	}
}