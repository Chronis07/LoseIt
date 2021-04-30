using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    //private GameObject ParentGameObject = GameObject.FindGameObjectWithTag("Manager"); 
    public GameObject Player;
    public float timer;

    public bool Stunned;
    private bool isStunned = false;
    public float stunDuration;


    public AudioSource audioSource;

    private bool Ended = false;
    public GameObject End_Menu;
    public GameObject TimeCounter;

    // Start is called before the first frame update
    void Start()
    {
        Player = transform.GetChild (0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerStun_Check();

        if(Ended == false){
            if(Player.GetComponent<UserHitCheck>().Game_Over == true){
                END_GAME();
                Ended = true;
                TimeCounter.GetComponent<Timer>().GameEnded = true;
            }
        }
        
    }

    // Manages stun effect
    void PlayerStun_Check(){

        if (timer != 0){
            if(timer >= stunDuration){
                Stunned = false;
                Player.GetComponent<PlayerMovement>().stunned = false;
                timer = 0;
                isStunned = false;
            }
        }
        
        if ((Stunned) && (timer == 0)){
            Player.GetComponent<PlayerMovement>().stunned = true;
            audioSource.Play();
            isStunned = true;
        }

        if (isStunned){
            timer = timer + Time.deltaTime;
        }
    }

    void END_GAME(){
        End_Menu.SetActive(true);
    }
}
