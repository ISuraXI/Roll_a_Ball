using System;
using UnityEngine;

public class Player : MonoBehaviour
{
	public GameController gameController;

	//Player
	private Rigidbody rb;

	//Properties
	private int speedPc;
	private int speedMobile;
	private int jumpForce;
	private int score;
	private int health;
	private bool contactWithGround = true;

	public int Score => score;
	public int Health => health;

	private void Start()
	{
		GetComponent<ParticleSystem>().Stop();
		health = 20;
		speedPc = 10;
		speedMobile = 5;
		jumpForce = 4;
		rb = GetComponent<Rigidbody>();
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (contactWithGround)
			{
				rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
			}
		}

		foreach (Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began)
			{
				if (contactWithGround)
				{
					rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
				}
			}
		}
	}

	private void FixedUpdate()
	{
		//For Pc only Test
		var moveHorizontal = Input.GetAxis("Horizontal");
		var moveVertical = Input.GetAxis("Vertical");
		var movementPc = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.AddForce(movementPc * speedPc);

		//For Mobile
		Vector3 movementMobile =
			new Vector3(Input.acceleration.x * speedMobile, 0.0f, Input.acceleration.y * speedMobile);
		rb.AddForce(movementMobile * speedMobile);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Damage50"))
		{
			TakeDamage(collision.gameObject.GetComponent<DamageDealer>().Damage);

			//Adjust health bar
			gameController.GreenHealthBarRect.sizeDelta = new Vector2((health * 2), 15);
		}
		else if (collision.gameObject.CompareTag("Ground"))
		{
			contactWithGround = true;
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			contactWithGround = false;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			//Pick Ups regenerate health
			RegenerateHealth(other.GetComponent<PickUp>().HealthRegeneration);


			//Adjust health bar
			gameController.GreenHealthBarRect.sizeDelta = new Vector2((health * 2), 15);
			other.gameObject.SetActive(false);

			//Update score
			score++;
			gameController.SetScoreText();
		}
		else if (other.gameObject.CompareTag("LevelTrigger"))
		{
			other.gameObject.SetActive(false);
			gameController.IncreaseLevel();
		}
	}

	private void TakeDamage(int damage)
	{
		if (health - damage > 0)
		{
			health -= damage;
		}
		else
		{
			health = 0;
			gameController.GreenHealthBarRect.sizeDelta = new Vector2((health * 2), 15);
			GetComponent<ParticleSystem>().Play(); //TODO add delay
			gameController.SetGameOver();
		}
	}

	private void RegenerateHealth(int amount)
	{
		if (health + amount <= 100)
		{
			health += amount;
		}
		else
		{
			health = 100;
		}
	}
}