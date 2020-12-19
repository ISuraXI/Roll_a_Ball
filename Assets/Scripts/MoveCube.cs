using UnityEngine;

public class MoveCube : MonoBehaviour
{
	private Vector3 scaleChange;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private bool switchBool = true;

	private void Start()
	{
		startPosition = new Vector3(1.0f, 0.0f, 1.0f);
		endPosition = new Vector3(1.0f, 4.0f, 1.0f);
		scaleChange = new Vector3(0, 0.05f, 0);
	}

	// Update is called once per frame
	private void Update()
	{
		if (switchBool)
		{
			transform.localScale += scaleChange;
		}
		else
		{
			transform.localScale -= scaleChange;
		}

		if (transform.lossyScale == startPosition)
		{
			switchBool = true;
		}

		if (transform.localScale == endPosition)
		{
			switchBool = false;
		}
	}
}