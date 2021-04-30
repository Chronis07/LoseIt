using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingTargetManager : MonoBehaviour
{
    public GameObject Homing_Spawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D HitInfo){

        if (HitInfo.tag == "Homing"){
            Debug.Log ("Resident HIT");
            Homing_Spawner.GetComponent<HomingSpawner>().enemyDeath = true; //passing trigger for Homing enemy spawner
            
            //gameObject.GetComponent<ResidentSpawner>().destroyed = true;
            Destroy(gameObject); //Destroys the resident it Hit

        }
    }
}
