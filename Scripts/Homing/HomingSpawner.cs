using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingSpawner : MonoBehaviour
{
    public bool enemyDeath = false;
    public float SpawnTime;
    public float timer;

    public GameObject HomingEnemy;
    //public GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDeath){
            timer = timer + Time.deltaTime;
            HomingEnemy.transform.position = transform.position;
            
            if (timer >= SpawnTime){
                timer = 0;
                //GameObject Homing_enemy = Instantiate(HomingEnemy);
                //Homing_enemy.transform.position = transform.position;
                //Homing_enemy.GetComponent<AIDestinationSetter>().Target = GameManager.GetComponent<ResetEnemyTarget>().MainPlayer.transform;

                enemyDeath = false;
            }
        }
    }
}
