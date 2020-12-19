using UnityEngine;

public class DeathZone : MonoBehaviour
{
	public GameController gameController;

	private void OnTriggerEnter(Collider other)
	{
		gameController.SetGameOver();
	}
}