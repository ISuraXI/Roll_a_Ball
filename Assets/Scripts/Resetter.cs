using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour
{
	private readonly List<PickUp> pickUps = new List<PickUp>();
	private readonly List<Trigger> triggers = new List<Trigger>();
	private readonly List<OpenWall> openWalls = new List<OpenWall>();
	private readonly List<GodModePickUp> godModePickUps = new List<GodModePickUp>();

	public void AddGameObject(PickUp pickUp)
	{
		pickUps.Add(pickUp);
	}

	public void AddGameObject(Trigger trigger)
	{
		triggers.Add(trigger);
	}

	public void AddGameObject(OpenWall openWall)
	{
		openWalls.Add(openWall);
	}

	public void AddGameObject(GodModePickUp godModePickUp)
	{
		godModePickUps.Add(godModePickUp);
	}

	public void ResetAll()
	{
		foreach (var pickUp in pickUps)
		{
			pickUp.gameObject.SetActive(true);
		}

		foreach (var trigger in triggers)
		{
			trigger.gameObject.SetActive(true);
		}

		foreach (var godModePickUp in godModePickUps)
		{
			godModePickUp.gameObject.SetActive(true);
		}

		foreach (var openWall in openWalls)
		{
			openWall.gameObject.SetActive(false);
		}

	}
}