using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PathMover : MonoBehaviour
{
	public Transform[] target;
    public int speed;
    private int current;
    private float nextActionTime = 0.00f;
    private float sampleRate = 100; //check twenty times per seco


    public void toggleSpeed()
    {
        if (speed == 0)
        {
            speed = 1;
        }
        else
        {
            speed = 0;
        }
    }

    public void SetCurrentToZero()
    {
	    current = 0;
    }
    void Update()
    {
	    if (Time.time > nextActionTime) {
		    nextActionTime = Time.time + (1/sampleRate);
		    Move();
	    }
    }

    public void Move()
    {
	    if (transform.position != target[current].position)
	    {
		    Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
		    GetComponent<Rigidbody>().MovePosition(pos);
	    }
	    else current = (current + 1) % target.Length;
    }
}