using UnityEngine;

public class PickUp : MonoBehaviour
{
	private int healthRegeneration;

	public PickUp()
	{
		healthRegeneration = 10;
	}

	public int HealthRegeneration => healthRegeneration;

	private void Update()
	{
		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}