using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport2 : MonoBehaviour
{

	public Transform[] target;
	public int speed;
	private int current;
	private float nextActionTime = 0.00f;
	private float sampleRate = 100; //check twenty times per seco


	void Update()
	{
		if (Time.time > nextActionTime) {
			nextActionTime = Time.time + (1/sampleRate);
			Move();
		}
	}

	public void Move()
	{
		if (transform.position != target[current].position)
		{
			Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
			GetComponent<Rigidbody>().MovePosition(pos);
		}
		else current = (current + 1) % target.Length;
	}

	public void SetCurrentToZero()
	{
		current = 0;
	}
}