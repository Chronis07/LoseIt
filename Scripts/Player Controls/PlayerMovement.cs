using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float move_speed;
    public float jump_force;

    public bool stunned; //to stop motion if stunned


    public Animator Animate;
    public bool Rotated = false;


    //public bool is_grounded = false;

    [SerializeField] private LayerMask GroundLayer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!stunned){

            Animate.SetBool("Stunned", false);


            //Jumping
            if (((Input.GetKeyDown (KeyCode.W)) || (Input.GetKeyDown (KeyCode.Space))) && Ground_Check()){

                GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x , jump_force);
                //Animate.SetBool("Jummped", true);
            }

            if(Ground_Check()){
                Animate.SetBool("Jummped", false);
            }
            else{
                Animate.SetBool("Jummped", true);
            }
            //else{Animate.SetBool("Jummped", false);}

            //Left & Right movement
            if (Input.GetKey (KeyCode.A)){

                if(Rotated){
                    transform.Rotate(0.0f,180.0f,0.0f);
                    Rotated = false;
                }

                GetComponent<Rigidbody2D>().velocity = new Vector2 (-move_speed , GetComponent<Rigidbody2D>().velocity.y);
                //Animate.SetBool("Running", true);
            }

            if (Input.GetKey (KeyCode.D)){

                if(Rotated == false){
                    transform.Rotate(0.0f,180.0f,0.0f);
                    Rotated = true;
                }
                GetComponent<Rigidbody2D>().velocity = new Vector2 (move_speed , GetComponent<Rigidbody2D>().velocity.y);
                //Animate.SetBool("Running", true);
            }

            if ((GetComponent<Rigidbody2D>().velocity.x != 0) && (GetComponent<Rigidbody2D>().velocity.y == 0)){
                Animate.SetBool("Running", true);
            }
            else{Animate.SetBool("Running", false);}

        }

        else{
            Animate.SetBool("Stunned", true);
        }
    }

    /*
    void FixedUpdate(){

        //Jumping
        if ((Input.GetKeyDown (KeyCode.W)) && Ground_Check()){

            GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x , jump_force);
        }
    } 
    */

    private bool Ground_Check (){
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().is_grounded;
    }
}
