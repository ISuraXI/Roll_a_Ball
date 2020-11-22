using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLevel5 : MonoBehaviour
{
	public int speed = 1;

	private void Update()
	{
		transform.Rotate(new Vector3(0, 0, 30 * speed) * Time.deltaTime);
	}
}