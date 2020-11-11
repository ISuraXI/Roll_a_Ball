using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
	public float speed;
	public Text countText;
	public Text winText1;
	public Text winText2;
	private Rigidbody rb;
	private int count;
	public GameObject level1;
	public GameObject openWall1;
	public GameObject level2;
	public GameObject openWall2;
	public GameObject bridge2;
	public GameObject closeWall2;
	public GameObject level3;
	public GameObject bridge3;
	public GameObject closeWall3;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText1.text = "";
		winText2.text = "";
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);

		if (count >= 8)
		{
			openWall1.SetActive(false);
			level2.SetActive(true);
		}

		if (count >= 9)
		{
			openWall2.SetActive(false);
			level3.SetActive(true);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}

		if (other.gameObject.CompareTag("Trigger2"))
		{
			closeWall2.SetActive(true);
			level1.SetActive(false);
			bridge2.SetActive(false);
		}

		if (other.gameObject.CompareTag("Trigger3"))
		{
			closeWall3.SetActive(true);
			level2.SetActive(false);
			bridge3.SetActive(false);
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 8)
		{
			winText1.text = "Stage 1 clear!";
			Destroy(winText1, 2);
		}

		countText.text = "Count: " + count.ToString();
		if (count >= 9)
		{
			winText2.text = "Stage 2 clear!";
			Destroy(winText2, 2);
		}
	}
}