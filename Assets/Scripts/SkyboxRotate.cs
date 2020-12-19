using UnityEngine;

public class SkyboxRotate : MonoBehaviour
{
	public float Skyboxspeed;

	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		RenderSettings.skybox.SetFloat("_Rotation", Time.time * Skyboxspeed);
	}
}