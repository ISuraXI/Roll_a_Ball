using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour
{
    public Text deathText;


    void Start()
    {
        deathText.text = "";
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        deathText.text = "YOU DIED BITCH";
    }

    
}
