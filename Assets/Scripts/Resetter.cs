﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour
{
	public UiMenuController uiMenuController;

	private readonly List<PickUp> pickUps = new List<PickUp>();
	private readonly List<Trigger> triggers = new List<Trigger>();
	private readonly List<OpenWall> openWalls = new List<OpenWall>();
	private readonly List<GodModePickUp> godModePickUps = new List<GodModePickUp>();
	private readonly List<Ground> grounds = new List<Ground>();
	private readonly List<GroundPb> groundPbs = new List<GroundPb>();
	private readonly List<GroundRound> groundRounds = new List<GroundRound>();
	private readonly List<Upsizer> upsizers = new List<Upsizer>();

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

	public void AddGameObject(Ground ground)
	{
		grounds.Add(ground);
	}

	public void AddGameObject(GroundPb groundPb)
	{
		groundPbs.Add(groundPb);
	}

	public void AddGameObject(GroundRound groundRound)
	{
		groundRounds.Add(groundRound);
	}

	public void AddGameObject(Upsizer upsizer)
	{
		upsizers.Add(upsizer);
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

		foreach (var upsizer in upsizers)
		{
			upsizer.gameObject.SetActive(true);
		}

	}

	public void SetGround1()
	{
		foreach (var ground in grounds)
		{
			ground.gameObject.GetComponent<MeshRenderer>().material = uiMenuController.ground1Material;
		}

		uiMenuController.ShopGround1();
	}

	public void SetGround2()
	{
		foreach (var ground in grounds)
		{
			ground.gameObject.GetComponent<MeshRenderer>().material = uiMenuController.ground2Material;
		}

		foreach (var groundPb in groundPbs)
		{
			groundPb.gameObject.GetComponent<MeshRenderer>().material = uiMenuController.ground2_1Material;
		}

		foreach (var groundRound in groundRounds)
		{
			groundRound.gameObject.GetComponent<MeshRenderer>().material = uiMenuController.ground2_2Material;
		}

		uiMenuController.ShopGround2();
	}

	public void SetGround3()
	{
		foreach (var ground in grounds)
		{
			ground.gameObject.GetComponent<MeshRenderer>().material = uiMenuController.ground3Material;
		}

		foreach (var groundPb in groundPbs)
		{
			groundPb.gameObject.GetComponent<MeshRenderer>().material = uiMenuController.ground3_1Material;
		}

		foreach (var groundRound in groundRounds)
		{
			groundRound.gameObject.GetComponent<MeshRenderer>().material = uiMenuController.ground3_2Material;
		}

		uiMenuController.ShopGround3();
	}

	public void SetGround4()
	{
		foreach (var ground in grounds)
		{
			ground.gameObject.GetComponent<MeshRenderer>().material = uiMenuController.ground4Material;
		}

		foreach (var groundPb in groundPbs)
		{
			groundPb.gameObject.GetComponent<MeshRenderer>().material = uiMenuController.ground4_1Material;
		}

		foreach (var groundRound in groundRounds)
		{
			groundRound.gameObject.GetComponent<MeshRenderer>().material = uiMenuController.ground4_2Material;
		}

		uiMenuController.ShopGround4();
	}

	public void SetGround5()
	{
		foreach (var ground in grounds)
		{
			ground.gameObject.GetComponent<MeshRenderer>().material = uiMenuController.ground5Material;
		}

		foreach (var groundPb in groundPbs)
		{
			groundPb.gameObject.GetComponent<MeshRenderer>().material = uiMenuController.ground5_1Material;
		}

		foreach (var groundRound in groundRounds)
		{
			groundRound.gameObject.GetComponent<MeshRenderer>().material = uiMenuController.ground5_2Material;
		}

		uiMenuController.ShopGround5();
	}
}