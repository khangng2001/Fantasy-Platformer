using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    private Slider HealthBar;
    private PlayerMovement player;
    public Image image;
    private void Start() {
        HealthBar = GetComponent<Slider>();
        player = FindObjectOfType<PlayerMovement>();
        image.color = Color.green;
    }
    // Update is called once per frame
    void Update()
    {
        HealthBar.maxValue = player.maxhealth;
        HealthBar.value = player.Health;
        if(HealthBar.value <= player.maxhealth/2)
        {
            image.color = Color.red;
        }
        else {
            image.color = Color.green;
        }
    }
}
