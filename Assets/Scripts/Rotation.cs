using UnityEngine;

public class Rotation : MonoBehaviour
{
	public float speed = 1;
	// Update is called once per frame
	private void Update()
	{
		transform.Rotate(new Vector3(0, 60 * speed, 0) * Time.deltaTime);
	}
}