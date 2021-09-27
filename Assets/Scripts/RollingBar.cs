using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollingBar : MonoBehaviour
{
    private Slider StaminaBar;
    public Image image;
    public float stamina;
    public float maxstamina;

    private Coroutine regen=null;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    public static RollingBar instance;
    private void Awake() {
        instance =this;
    }
    private void Start() {
        StaminaBar = GetComponent<Slider>();
        image.color = Color.blue;
        stamina = maxstamina;
    }
    private void Update() {
        StaminaBar.maxValue = maxstamina;
        StaminaBar.value= stamina;
    }
    // Update is called once per frame
    public void useStamina(int amount)
    {
        if(stamina -amount >=0)
        {
            stamina-=amount;
            StaminaBar.value = stamina;

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
        while (stamina <maxstamina)
        {
            stamina+= 1;
            StaminaBar.value = stamina;
            yield return regenTick;
        }
        regen = null;
    }
}
