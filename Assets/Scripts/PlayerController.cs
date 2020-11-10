using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;




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
            Wall2.SetActive(true);
        }

        if (other.gameObject.CompareTag("Trigger3"))
        {
            Wall3.SetActive(true);
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