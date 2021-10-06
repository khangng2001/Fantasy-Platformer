using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollingBar : MonoBehaviour
{
    private Slider StaminaBar;
    public Image BarColor;
    public float Stamina;
    public float MaxStamina;

    private Coroutine regen=null;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    public static RollingBar instance;
    private void Awake() {
        instance =this;
    }
    private void Start() {
        StaminaBar = GetComponent<Slider>();
        BarColor.color = Color.blue;
        Stamina = MaxStamina;
    }
    private void Update() {
        StaminaBar.maxValue = MaxStamina;
        StaminaBar.value= Stamina;
    }
    // Update is called once per frame
    public void useStamina(int amount)
    {
        if(Stamina -amount >=0)
        {
            Stamina-=amount;
            StaminaBar.value = Stamina;

            if(regen !=null)
            {
                StopCoroutine(regen);
            }
            regen =StartCoroutine(RegenStamina());
        }
        else{
            Debug.Log("not enough stamina");
        }
    }
    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);
        while (Stamina <MaxStamina)
        {
            Stamina+= 1;
            StaminaBar.value = Stamina;
            yield return regenTick;
        }
        regen = null;
    }
}
