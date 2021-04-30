using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentSpawner : MonoBehaviour
{
    public GameObject[] ResidentSelect;
    //public GameObject Resident;
    //public GameObject Homing_Obj;

    public float timer;
    public float time_duration;
    //public float despawn_time;
    //public float spawn_time;

    public bool spawned = false;
    public bool timeset = false;

    public int RandomTime;
    public int ResidentSelector;
    GameObject Spawned_Res;

    public string ResidentName;



    public Animator Anim;
    public int AnimationSelector;
    public bool TurrentSpawned = false; // triggers when the AngryRes/Turrent is spawned

    public GameObject Child;



    public AudioSource audioSource;
    public AudioSource DoorOpenAudio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(TurrentSpawned){
            if(Spawned_Res.GetComponent<BldgTurrent>().Detected){
                Trigger_AngryRes_Anim(); // Starts turrent Triggered Animation
            }
            else{
                Anim.SetBool("AngryTriggered", false);
            }
        }

        Child.GetComponent<Animator>().SetBool("Explode", false);
        Hit_Check();

        if(!timeset){
            RandomTime = Random.Range(5,50);
            ResidentSelector = Random.Range(0,3);

            if(spawned){
                time_duration = RandomTime;
                timeset = true;
            }

            if(!spawned){
                time_duration = RandomTime;
                timeset = true;
            }
        }

        if(timeset){
            timer = timer + Time.deltaTime;

            if(timer >= time_duration){
                if(!spawned){
                    Spawned_Res = Instantiate(ResidentSelect[ResidentSelector]);
                    Spawned_Res.name = ResidentName;
                    Spawned_Res.transform.position = transform.position;

                    timer = 0;
                    timeset = false;

                    spawned = true;

                    if(ResidentSelector == 0 || ResidentSelector == 2){
                        Spawn_RegularRes_Anim(); // Starts RegResident Animation
                    }
                    if(ResidentSelector == 1 || ResidentSelector == 3){
                        Spawn_AngryRes_Anim(); // Starts turrent Entry Animation
                        TurrentSpawned = true;
                    }


                    DoorOpenAudio.Play(); // plays the audio for an opening window
                }
                else{
                    Destroy(Spawned_Res);

                    timer = 0;
                    timeset = false;

                    spawned = false;


                    if(TurrentSpawned){
                        Exit_AngryRes_Anim(); // Starts turrent Exit Animation
                        TurrentSpawned = false;
                    }
                    else{
                        Exit_RegularRes_Anim(); // Starts Exit Animation
                    }

                }
            }

        }
    
    }

    void Hit_Check(){  //Checks if the Instantiated resident is destroyed and if it is then it resets the timer for the despawn

        if(spawned){
            if(GameObject.Find(ResidentName) == null){
                Boom_RegularRes_Anim(); // Starts Boom Animation
                Child.GetComponent<Animator>().SetBool("Explode", true);
                audioSource.Play();
                Hit_Reset();
            }
        }
    }


    // void Hit_Check(){

    //     if(spawned){
    //         if(Spawned_Res.GetComponent<HomingTargetManager>().Im_Hit == true){
    //             Hit_Reset();
    //             Spawned_Res.GetComponent<HomingTargetManager>().Im_Hit == false;
    //         }
    //     }
    // }

    void Hit_Reset(){   //Resets the timer for the despawn of the intantiated resident

        timer = 0;
        timeset = false;

        spawned = false;
    }


    // __________________________ANIMATION FUNCTIONS__________________________________

    void Spawn_RegularRes_Anim(){
        AnimationSelector = Random.Range(1,4);

        if(AnimationSelector == 1 || AnimationSelector == 3){
            Anim.SetBool("CoffeeRes", true);
            Spawn_Coffee_Anim();
        }
        if(AnimationSelector == 2 || AnimationSelector == 4){
            Anim.SetBool("PhoneRes", true);
            Spawn_Phone_Anim();
        }
    }

    void Exit_RegularRes_Anim(){

        if(AnimationSelector == 1 || AnimationSelector == 3){
            Anim.SetBool("CoffeeRes", false);
            Exit_Coffee_Anim();
        }
        if(AnimationSelector == 2 || AnimationSelector == 4){
            Anim.SetBool("PhoneRes", false);
            Exit_Phone_Anim();
        }
    }

    void Boom_RegularRes_Anim(){

        if(AnimationSelector == 1 || AnimationSelector == 3){
            Anim.SetBool("CoffeeRes", false);
            Boom_Coffee_Anim();
        }
        if(AnimationSelector == 2 || AnimationSelector == 4){
            Anim.SetBool("PhoneRes", false);
            Boom_Phone_Anim();
        }
    }



    // Coffee Man:

    void Spawn_Coffee_Anim(){
        Anim.SetBool("ResSpawned", true);
        Anim.SetBool("Boom", false);
        Idle_Coffee_Anim();
    }
    void Idle_Coffee_Anim(){
        Anim.SetBool("Alive", true);
    }
    void Exit_Coffee_Anim(){
        Anim.SetBool("ResSpawned", false);
        Anim.SetBool("Alive", false);
    }
    void Boom_Coffee_Anim(){
        Anim.SetBool("Boom", true);
        Anim.SetBool("Alive", false);
    }


    // PhoneCall Man:

    void Spawn_Phone_Anim(){
        Anim.SetBool("ResSpawned", true);
        Anim.SetBool("Boom", false);
        Idle_Phone_Anim();
    }
    void Idle_Phone_Anim(){
        Anim.SetBool("Alive", true);
    }
    void Exit_Phone_Anim(){
        Anim.SetBool("ResSpawned", false);
        Anim.SetBool("Alive", false);
    }
    void Boom_Phone_Anim(){
        Anim.SetBool("Boom", true);
        Anim.SetBool("Alive", false);
    }


    // Angry Resident:

    void Spawn_AngryRes_Anim(){
        Anim.SetBool("AngrySpawned", true);
    }
    void Exit_AngryRes_Anim(){
        Anim.SetBool("AngrySpawned", false);
    }
    void Trigger_AngryRes_Anim(){
        Anim.SetBool("AngryTriggered", true);
    }
}
