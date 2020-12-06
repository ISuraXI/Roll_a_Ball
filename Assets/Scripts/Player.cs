using UnityEngine;

public class Player : MonoBehaviour
{
	public GameController gameController;

	//Particle
	public GameObject healthParticle;
	public GameObject explosionParticle;

	//Mobile Movement
	private float x = 0;
	private float y = 0;

	//Properties
	private Rigidbody rb; //Player body
	private int speedPc;
	private int speedMobile;
	private int jumpForce;
	private int score;
	private int health;
	private bool contactWithGround = true;
	private Vector3 deathPlayerPosition;

	public int Score => score;
	public int Health => health;


	private void Start()
	{
		//TODO: makt it better for set x and y to 0 when you have the phone not horizontal when you start the game working but not good :(
		//x = Input.acceleration.x;
		//y = Input.acceleration.y;
		healthParticle.GetComponent<ParticleSystem>().playOnAwake = true;
		health = 20;
		speedPc = 10;
		speedMobile = 5;
		jumpForce = 4;
		rb = GetComponent<Rigidbody>();
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	private void Update()
	{
		if (gameController.TimerTeleportStart)
		{
			rb.AddForce(0, 0.45f, 0, ForceMode.Impulse);
			gameController.TimeTelportForce -= Time.deltaTime;
			if (gameController.TimeTelportForce <= 0f)
			{
				rb.AddForce(0, -0.45f, 0, ForceMode.Impulse);
				rb.AddForce(0, 0, 0, ForceMode.Impulse);
				gameController.TimerTeleportStart = false;
				gameController.TimeTelportForce = 1;
			}
		}

		//For timer explosion particle
		if (gameController.StartTimerGameOverExplosion)
		{
			rb.transform.position = deathPlayerPosition;
			gameController.TimerGameOverExplosion -= Time.deltaTime;
			//gameController.TimerGameOverExplosionInt = (int) gameController.TimerGameOverExplosion;
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
			//gameController.TimerRedHealthInt = (int) gameController.TimerRedHealth;
			if (gameController.TimerRedHealth <= 0f)
			{
				gameController.RedHealthBarRect.sizeDelta = new Vector2((health * 8), 40);
				gameController.TimerRedHealth = 2;
				gameController.StartTimerRedHealth = false;
			}
		}


		if (Input.GetKeyDown(KeyCode.Space) && contactWithGround)
		{
			rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
		}

		foreach (var touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began && contactWithGround)
			{
				rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
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
		var movementMobile = new Vector3((Input.acceleration.x - x) * speedMobile, 0.0f,
			(Input.acceleration.y - y) * speedMobile);
		rb.AddForce(movementMobile * speedMobile);
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
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("GroundTrigger"))
		{
			gameController.timelineLevel2_1.SetActive(true);
			gameController.groundFill.SetActive(true);
		}

		if (other.gameObject.CompareTag("Transporter"))
		{
			gameController.TimerTeleportStart = true;
		}

		if (other.gameObject.CompareTag("Pick Up"))
		{
			healthParticle.SetActive(false);
			healthParticle.SetActive(true);
			RegenerateHealth(other.GetComponent<PickUp>().HealthRegeneration);

			//Adjust health bar
			gameController.GreenHealthBarRect.sizeDelta = new Vector2((health * 8), 40);
			gameController.RedHealthBarRect.sizeDelta = new Vector2((health * 8), 40);
			other.gameObject.SetActive(false);

			//Update score
			score++; //TODO remove, since it is done in the GameController
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
			explosionParticle.GetComponent<ParticleSystem>().playOnAwake = true;
			gameController.StartTimerGameOverExplosion = true;
			explosionParticle.SetActive(true);

			var rbPosition = rb.position;
			deathPlayerPosition = new Vector3(rbPosition.x, rbPosition.y, rbPosition.z);
			rb.GetComponent<MeshRenderer>().enabled = false;
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