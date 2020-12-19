using UnityEngine;

public class Trigger : MonoBehaviour
{
	public Resetter Resetter;
	private void Start()
	{
		Resetter.AddGameObject(this);
	}
}
