using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upsizer : MonoBehaviour
{
	public Resetter Resetter;

	private void Start()
	{
		Resetter.AddGameObject(this);
	}

	private void Update()
	{
		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
