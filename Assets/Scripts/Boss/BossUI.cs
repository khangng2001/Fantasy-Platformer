using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    [SerializeField] private Slider Bosspanel;
    [SerializeField] private Image HealthImage;
    [SerializeField]private Boss Enemy;
    
    public static BossUI instance;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Bosspanel = GetComponent<Slider>();
        Bosspanel.gameObject.SetActive(false);
        Enemy = FindObjectOfType<Boss>();
        Enemy.gameObject.SetActive(false);
        HealthImage.color = Color.red;
    }
    private void Update() {
        Bosspanel.maxValue = Enemy.MaxHealth;
        Bosspanel.value = Enemy.currentHealth;
    }

    public void BossActivator()
    {
        Bosspanel.gameObject.SetActive(true);
        Enemy.gameObject.SetActive(true);
    }


}
