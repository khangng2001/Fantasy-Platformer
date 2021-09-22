using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthBar : MonoBehaviour
{
    
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;

    public void setHealth(float Health, float maxHealth)
    {

        //slider.gameObject.SetActive(Health<maxHealth);
        slider.value=Health;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponentInChildren<Image>().color=Color.Lerp(low,high, slider.normalizedValue);
        
    }


    private void Update() {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position+offset);
    }

}
