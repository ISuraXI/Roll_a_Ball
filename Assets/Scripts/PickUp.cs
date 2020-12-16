using UnityEngine;

public class PickUp : MonoBehaviour
{
	public Resetter Resetter;
	private int healthRegeneration;

	public int HealthRegeneration => healthRegeneration;

	private void Start()
	{
		healthRegeneration = 10;
		Resetter.AddGameObject(this);
	}

	private void Update()
	{
		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}