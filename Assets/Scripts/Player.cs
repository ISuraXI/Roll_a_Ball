﻿using UnityEngine;

public class Player : MonoBehaviour
{
	public GameController gameController;

	//Particle
	public GameObject healthParticle;
	public GameObject explosionParticle;

	//Properties
	private Rigidbody rb; //Player body
	private int speedPc;
	private int speedMobile;
	private int jumpForce;
	private int health;
	private bool contactWithGround = true;
	private Vector3 deathPlayerPosition;
	private bool fullLife;

	public int Health => health;

	private const int StartHealth = 20;

	private void Start()
	{
		healthParticle.GetComponent<ParticleSystem>().playOnAwake = true;
		health = StartHealth;
		speedPc = 10;
		speedMobile = 6;
		jumpForce = 4;
		rb = GetComponent<Rigidbody>();
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	public bool test;
	public float timeTest = 2f;

	private void Update()
	{
		if (health == 100)
		{
			fullLife = true;
		}
		else if (health <= 100)
		{
			fullLife = false;
		}


		if (test)
		{
			if (gameController.level == 5)
			{
				gameController.levelCompleteText.text = "Level 1 complete";
			}
			else if (gameController.level == 11)
			{
				gameController.levelCompleteText.text = "Level 2 complete";
			}

			timeTest -= Time.deltaTime;
			if (timeTest <= 0f)
			{
				gameController.levelCompleteText.text = "";
				timeTest = 2f;
				test = false;
			}
		}

		//For timer explosion particle
		if (gameController.StartTimerGameOverExplosion)
		{
			rb.transform.position = deathPlayerPosition;
			gameController.TimerGameOverExplosion -= Time.deltaTime;
			if (gameController.TimerGameOverExplosion <= 0f)
				if (gameController.TimerGameOverExplosion <= 0f)
				{
					gameController.SetGameOver();
					gameController.TimerGameOverExplosion = 2;
					gameController.StartTimerGameOverExplosion = false;
				}
		}


		if (gameController.StartTimerRedHealth)
		{
			gameController.TimerRedHealth -= Time.deltaTime;
			if (gameController.TimerRedHealth <= 0f)
			{
				gameController.RedHealthBarRect.sizeDelta = new Vector2((health * 8), 40);
				gameController.TimerRedHealth = 2;
				gameController.StartTimerRedHealth = false;
			}
		}


		if (!gameController.menuCanvas.activeSelf && !gameController.pauseCanvas.activeSelf)
		{
			if (Input.GetKeyDown(KeyCode.Space) && contactWithGround)
			{
				rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
			}

			foreach (var touch in Input.touches)
			{
				Vector3 touchPos = Camera.main.ScreenToViewportPoint(touch.position);
				if (touch.phase == TouchPhase.Began && contactWithGround && touchPos.y < 0.75f)
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
		if (SystemInfo.deviceType == DeviceType.Handheld)
		{
			var movementMobile = new Vector3((Input.acceleration.x) * speedMobile, 0.0f,
				(Input.acceleration.y + 0.5f) * 5);
			rb.AddForce(movementMobile * speedMobile);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Damage"))
		{
			TakeDamage(collision.gameObject.GetComponent<DamageDealer>().Damage);

			//Adjust health bar
			gameController.GreenHealthBarRect.sizeDelta = new Vector2((health * 8), 40);
			gameController.StartTimerRedHealth = true;
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

		if (collision.gameObject.CompareTag("LevelOutTrigger"))
		{
			gameController.LevelOutTriggerTurnOff();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("GroundTrigger"))
		{
			gameObject.GetComponent<Rigidbody>().isKinematic = false;
			gameObject.GetComponent<Teleport1>().enabled = false;
			gameObject.GetComponent<Teleport1>().SetCurrentToZero();
			gameObject.GetComponent<Teleport2>().enabled = false;
			gameObject.GetComponent<Teleport2>().SetCurrentToZero();
			gameObject.GetComponent<Teleport3>().enabled = false;
			gameObject.GetComponent<Teleport3>().SetCurrentToZero();

			switch (gameController.level)
			{
				case 5:
					gameController.timelineLevel2_1.SetActive(true);
					gameController.groundFillLevel2.SetActive(true);
					test = true;
					break;
				case 11:
					gameController.groundFillLevel3.SetActive(true);
					gameController.goToLevel3.SetActive(false);
					test = true;
					break;
			}

			gameController.SetScoreToZero();
		}

		else if (other.gameObject.CompareTag("Transporter"))
		{
			/*for (var i = 0; i < 50; i++)
			{
				rb.AddForce(0, 0.45f, 0, ForceMode.Impulse);
			}*/

			gameObject.GetComponent<Rigidbody>().isKinematic = true;

			switch (gameController.level)
			{
				case 5:
					gameObject.GetComponent<Teleport1>().enabled = true;
					break;
				case 11:
					gameObject.GetComponent<Teleport2>().enabled = true;
					break;
				case 17:
					gameObject.GetComponent<Teleport3>().enabled = true;
					break;
			}

			if (gameController.level1)
			{
				if (gameController.level == 5)
				{
					gameObject.GetComponent<Teleport1>().enabled = true;
					gameController.passedLevel = 1;
					gameController.level1 = false;
				}
			}
			else if (gameController.level2)
			{
				if (gameController.level == 11)
				{
					gameObject.GetComponent<Teleport2>().enabled = true;
					gameController.passedLevel = 2;
					gameController.level2 = false;
				}
			}
			else if (gameController.level3)
			{
				if (gameController.level == 17)
				{
					gameObject.GetComponent<Teleport3>().enabled = true;
					gameController.passedLevel = 3;
					gameController.level3 = false;
				}
			}

			gameController.PrintHighscore();
		}

		else if (other.gameObject.CompareTag("Good Mode"))
		{
			other.gameObject.SetActive(false);
			gameController.GodMode = true;
		}

		else if (other.gameObject.CompareTag("Pick Up"))
		{
			if (!fullLife)
			{
				healthParticle.SetActive(false);
				healthParticle.SetActive(true);
			}
			RegenerateHealth(other.GetComponent<PickUp>().HealthRegeneration);

			//Adjust health bar
			gameController.GreenHealthBarRect.sizeDelta = new Vector2((health * 8), 40);
			gameController.RedHealthBarRect.sizeDelta = new Vector2((health * 8), 40);
			other.gameObject.SetActive(false);

			//Update score
			gameController.PickUpCollected();
			gameController.UnlockNextLevel();
		}
		else if (other.gameObject.CompareTag("LevelTrigger"))
		{
			other.gameObject.SetActive(false);
			gameController.IncreaseLevel();
		}
		else if (other.gameObject.CompareTag("LevelOutTrigger"))
		{
			gameController.CompleteStage();
			other.gameObject.SetActive(false);
		}
	}

	private void TakeDamage(int damage)
	{
		if (gameController.canTakeDamage)
		{
			if (health - damage > 0)
			{
				health -= damage;
			}
			else
			{
				health = 0;

				gameController.StartTimerGameOverExplosion = true;
				explosionParticle.SetActive(true);

				var rbPosition = rb.position;
				deathPlayerPosition = new Vector3(rbPosition.x, rbPosition.y, rbPosition.z);
				rb.GetComponent<MeshRenderer>().enabled = false;
			}
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

	public void Reset()
	{
		health = StartHealth;
		rb.GetComponent<MeshRenderer>().enabled = true;
	}
}