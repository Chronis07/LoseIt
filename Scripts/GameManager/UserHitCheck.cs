using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserHitCheck : MonoBehaviour
{
    public bool Game_Over = false;
    public AudioSource Meow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){

        if(col.gameObject.tag == "Homing"){
            Debug.Log ("Player Hit, GameOver !");
            Meow.Play();
            Game_Over = true;
        }
    }
}
