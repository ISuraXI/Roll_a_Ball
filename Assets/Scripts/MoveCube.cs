using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
	private Vector3 scaleChange;
	private Vector3 startPosi;
	private Vector3 endPosi;
	private bool switchBool = true;
	public int spped = 5;

	void Start()
	{
		startPosi = new Vector3(1.0f, 0.0f, 1.0f);
		endPosi = new Vector3(1.0f, 4.0f, 1.0f);
		scaleChange = new Vector3(0, 0.05f, 0);
	}

	// Update is called once per frame
	void Update()
	{
		if (switchBool)
		{
			transform.localScale += scaleChange;
		}
		else
		{
			transform.localScale -= scaleChange;
		}

		if (transform.lossyScale == startPosi)
		{
			switchBool = true;
		}

		if (transform.localScale == endPosi)
		{
			switchBool = false;
		}
	}
}