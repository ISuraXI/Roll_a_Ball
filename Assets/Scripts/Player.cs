using UnityEngine;

public class Player : MonoBehaviour
{
	public GameController gameController;

	//Player
	private Rigidbody rb;

	//Properties
	private int speed;
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
		speed = 10;
		jumpForce = 4;
		rb = GetComponent<Rigidbody>();
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

		//TODO make it better       Hint: that is the handy movement
		var dir = Vector3.zero;
		// we assume that the device is held parallel to the ground
		// and the Home button is in the right hand

		// remap the device acceleration axis to game coordinates:
		// 1) XY plane of the device is mapped onto XZ plane
		// 2) rotated 90 degrees around Y axis

		dir.x = -Input.acceleration.y;
		dir.z = Input.acceleration.x;

		// clamp acceleration vector to the unit sphere
		if (dir.sqrMagnitude > 1)
			dir.Normalize();

		// Make it move 10 meters per second instead of 10 meters per frame...
		dir *= Time.deltaTime;

		// Move object
		rb.transform.Translate(dir * speed);
	}

	private void FixedUpdate()
	{
		var moveHorizontal = Input.GetAxis("Horizontal");
		var moveVertical = Input.GetAxis("Vertical");

		var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);
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