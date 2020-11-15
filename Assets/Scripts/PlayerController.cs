using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
	public GameController gameController;

	//Player
	private Rigidbody rb;
	private float speed;
	public Player player;

	//Jump
	public int forceConst = 4;
	private bool contactWithGround = true;


	private void Start()
	{
		player = new Player();
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
			var health = player.TakeDamage(50);
			panelRectTransformGreenBar.sizeDelta = new Vector2((player.Health * 2), 15);
			if (health == 0)
			{
				//TODO DIE
				Debug.Log("Dead");
			}
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
			player.RegenerateHealth(other.GetComponent<PickUp>().HealthRegeneration);
			panelRectTransform.sizeDelta = new Vector2((player.Health * 2), 15);
			other.gameObject.SetActive(false);
			player.IncreaseScore();
			gameController.SetScoreText();
		}
		else if (other.gameObject.CompareTag("LevelTrigger"))
		{
			other.gameObject.SetActive(false);

			switch (player.Level)
			{
				case 0:
					gameController.closeWall2.SetActive(true);
					gameController.level1.SetActive(false);
					gameController.bridge2.SetActive(false);
					break;
				case 1:
					gameController.closeWall3.SetActive(true);
					gameController.level2.SetActive(false);
					gameController.bridge3.SetActive(false);
					break;
				case 2:
					break;
			}

			player.NextLevel();
		}
	}
}