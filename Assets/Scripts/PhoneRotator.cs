using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneRotator : MonoBehaviour
{
	public GameController gameController;
	private int speed = 1;
	private bool check = false;
	private bool check2 = false;
	private bool check3 = false;
	private bool check4 = false;
	private bool check5 = false;
	private bool check6 = false;
	private bool check7 = false;
	private bool check8 = false;
	private bool check9 = false;
	private bool check10 = false;

	private void Update()
	{
		if (transform.rotation.x >= -0.6f && check == false && check3 == false && check7 == false)
		{
			transform.Rotate(new Vector3( 0, 40 * speed * Time.deltaTime, 0));
		}
		if (transform.rotation.x <= -0.6f)
		{
			check = true;
		}
		if (transform.rotation.x <= -0.4f && check == true && check2 == false && check3 == false && check7 == false)
		{
			transform.Rotate(new Vector3( 0, -40 * speed * Time.deltaTime, 0));
		}
		if (transform.rotation.x >= -0.4f)
		{
			check2 = true;
		}
		if (transform.rotation.x >= -0.5f && check2 == true && check3 == false && check7 == false)
		{
			transform.Rotate(new Vector3( 0, 40 * speed * Time.deltaTime, 0));
		}
		if (transform.rotation.x <= -0.5f && check2 == true && check7 == false)
		{
			check4 = true;
			check7 = true;
		}
		if (transform.rotation.y <= 0.58f && check4 == true && check8 == false)
		{
			transform.Rotate(new Vector3( 40 * speed * Time.deltaTime, 0, 0));
		}
		if (transform.rotation.y >= 0.58f && check4 == true && check8 == false)
		{
			check5 = true;
			check8 = true;
		}
		if (transform.rotation.y >= 0.42f && check5 == true && check9 == false)
		{
			transform.Rotate(new Vector3( -40 * speed * Time.deltaTime, 0, 0));
		}
		if (transform.rotation.y <= 0.42f && check5 == true)
		{
			check9 = true;
			check6 = true;
		}
		if (transform.rotation.y <= 0.5f && check6 == true)
		{
			transform.Rotate(new Vector3( 40 * speed * Time.deltaTime, 0, 0));
			check10 = true;
		}
		if (transform.rotation.y >= 0.5f && check10 == true)
		{
			gameController.introPhone.SetActive(false);
			gameController.playerGameObject.GetComponent<Rigidbody>().isKinematic = false;
		}
	}
}
