using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
	public GameController gameController;

	//Player
	private Rigidbody rb;
	public float speed;
	public Player player;

	//Level
	// public GameObject level1;
	// public GameObject level2;
	// public GameObject bridge2;
	// public GameObject closeWall2;
	// public GameObject bridge3;
	// public GameObject closeWall3;

	//Jump
	public int forceConst = 4;
	private bool contactWithGround = true;


	private void Start()
	{
		player = new Player();
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
}
