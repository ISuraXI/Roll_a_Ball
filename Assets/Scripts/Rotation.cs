using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour

{
	[SerializeField] private float speed;

	// Update is called once per frame
	private void Update()
	{
		transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime);
	}
}