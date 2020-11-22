using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
	public GameObject menuCanvas;
	public GameObject levelCanvas;

	public void KlickOnLevel()
	{
		menuCanvas.SetActive(false);
		levelCanvas.SetActive(true);
	}

	public void KlickOnBack()
	{
		menuCanvas.SetActive(true);
		levelCanvas.SetActive(false);
	}
}