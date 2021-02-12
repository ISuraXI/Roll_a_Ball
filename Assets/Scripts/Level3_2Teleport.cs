using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_2Teleport : MonoBehaviour
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
			//Vector3 test = transform.position;
			Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
			GetComponent<Rigidbody>().MovePosition(pos);
			/*Debug.Log("1" + pos);
			Debug.Log("2" + test);
			if (test == pos)
			{
				Debug.Log("Test");
			}*/
		}
		else current = (current + 1) % target.Length;
	}

	public void SetCurrentToZero()
	{
		current = 0;
	}
}
