using UnityEngine;

public class Player : MonoBehaviour
{
	public GameController gameController;

	//Player
	private Rigidbody rb;

	//Properties
	private float speed;
	private int score;
	private int health;

	//Jump
	public int forceConst = 4;
	private bool contactWithGround = true;

	public int Score => score;

	private void Start()
	{
		health = 100;
		speed = 10;
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (contactWithGround)
			{
				rb.AddForce(0, forceConst, 0, ForceMode.Impulse);
			}
		}
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
			var panelRectTransformGreenBar = gameController.greenHealthBar.GetComponent<RectTransform>();
			panelRectTransformGreenBar.sizeDelta = new Vector2((health * 2), 15);
			TakeDamage(50);
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
			var panelRectTransform = gameController.greenHealthBar.GetComponent<RectTransform>();
			panelRectTransform.sizeDelta = new Vector2((health * 2), 15);
			other.gameObject.SetActive(false);

			//Pick Ups regenerate health
			RegenerateHealth(other.GetComponent<PickUp>().HealthRegeneration);

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