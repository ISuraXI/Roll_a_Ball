using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
	public float speed;
	public Text countText;
	public Text winText1;
	public Text winText2;
	public GameObject Wall1;
	private Rigidbody rb;
	private int count;
	public GameObject Level_2;
	public GameObject Wall2;
	public GameObject Wall2_1;
	public GameObject Level_3;
	public GameObject Wall3;
	public GameObject Ground3;
	public GameObject Falle;


	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText1.text = "";
		winText2.text = "";
	}

	public void FixedUpdate()
	{
		var moveHorizontal = Input.GetAxis("Horizontal");
		var moveVertical = Input.GetAxis("Vertical");

		var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);

		if (count >= 8)
		{
			Wall1.SetActive(false);
			Level_2.SetActive(true);
		}

		if (count >= 9)
		{
			Wall2_1.SetActive(false);
			Level_3.SetActive(true);
		}

		if (count >= 13)
		{
			Ground3.SetActive(false);
			Falle.SetActive(true);
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
		}

		if (other.gameObject.CompareTag("Trigger2"))
		{
			Wall2.SetActive(true);
		}

		if (other.gameObject.CompareTag("Trigger3"))
		{
			Wall3.SetActive(true);
		}
	}

	private void SetCountText()
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