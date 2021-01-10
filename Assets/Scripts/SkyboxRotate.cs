using UnityEngine;

public class SkyboxRotate : MonoBehaviour
{
	public float Skyboxspeed;

	// Update is called once per frame
	void Update()
	{
		RenderSettings.skybox.SetFloat("_Rotation", Time.time * Skyboxspeed);
	}
}