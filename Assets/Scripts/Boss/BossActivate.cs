using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivate : MonoBehaviour
{
    PlayerMovement player;
    private void Start() {
        player = FindObjectOfType<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            BossUI.instance.BossActivator();
            StartCoroutine(WaitforBoss());
        }
    }

    IEnumerator WaitforBoss()
    {
        var CurrentSpeed = player.moveSpeed;
        player.moveSpeed = 0;
        yield return new WaitForSeconds(3f);
        player.moveSpeed = CurrentSpeed;
        Destroy(gameObject);
    }

}
