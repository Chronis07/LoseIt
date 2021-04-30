using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundProjectileSpawner : MonoBehaviour
{

    public GameObject Ground_Proj;
    public float timer = 0;
    public float maxTime;
    public bool facingLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        int randomiser = Random.Range(1,20);

        if (timer > maxTime){
            
            if (randomiser <= 16){

                Debug.Log (randomiser);
                GameObject newProjectile = Instantiate(Ground_Proj);
                newProjectile.GetComponent<Ground_proj_movement>().Stationary = false;

                if(facingLeft){
                    newProjectile.GetComponent<Ground_proj_movement>().speed = -(newProjectile.GetComponent<Ground_proj_movement>().speed);
                }

                newProjectile.transform.position = transform.position;

                Destroy(newProjectile, 8);

                timer = 0;
            }
        }
        
    }
}
