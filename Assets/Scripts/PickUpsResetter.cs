using System.Collections.Generic;
using UnityEngine;

public class PickUpsResetter : MonoBehaviour
{
	private readonly List<PickUp> pickUps = new List<PickUp>();

	public void AddPickUp(PickUp pickUp)
	{
		pickUps.Add(pickUp);
	}

	public void ResetPickUps()
	{
		foreach (var pickUp in pickUps)
		{
			pickUp.gameObject.SetActive(true);
		}
	}
}