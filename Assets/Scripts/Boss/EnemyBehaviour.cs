using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyBehaviour : MonoBehaviour
{
    public Transform[] EnemyTranformPos;
    [SerializeField] private GameObject SummomPosition;
    [SerializeField] private GameObject SummonAppear;
    [SerializeField] private float timeSpawn, Countdown;
    [SerializeField] private float timeTP, CountdownTP;  
    void Start()
    {
        var initialPosition = Random.Range(0, EnemyTranformPos.Length);
        transform.position= EnemyTranformPos[initialPosition].position;
        Countdown = timeSpawn;
        CountdownTP = timeTP;
    }
    private void Update() {
        Countdown -= Time.deltaTime;
        CountdownTP -= Time.deltaTime;
        if(Countdown < 0)
        {
            Countdown = timeSpawn;
            SummonNewEnemy();
            
        }
        if(CountdownTP < 0)
        {
            CountdownTP = timeTP;
            Teleport();
        }
    }
    void SummonNewEnemy()
    {
        GameObject Spawning = Instantiate(SummonAppear,SummomPosition.transform.position,Quaternion.identity);
    }
    void Teleport()
    {
        var initialPosition = Random.Range(0, EnemyTranformPos.Length);
        transform.position= EnemyTranformPos[initialPosition].position;
    }

}
