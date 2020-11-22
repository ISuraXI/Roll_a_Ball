using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public void RollaBallScene()
	{
		SceneManager.LoadScene("RollABall");
	}

	public void menuScene()
	{
		SceneManager.LoadScene("Menu");
	}
}