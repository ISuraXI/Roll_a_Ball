using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upsizer : MonoBehaviour
{
	public Resetter Resetter;
	public float speed;

	private void Start()
	{
		Resetter.AddGameObject(this);
	}

	private void Update()
	{
		transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime * speed);
	}
}
