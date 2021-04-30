using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_proj_movement : MonoBehaviour
{
    public float speed;
    public GameObject manager;
    public bool Stationary = true;

    public Animator Animate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Stationary){
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
    }

    void OnTriggerEnter2D (Collider2D HitInfo){
        
        if (HitInfo.gameObject.tag == "Player"){
            manager.GetComponent<EffectController>().Stunned = true;
            Debug.Log ("stunned = true");

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            Animate.SetBool("Collided", true);
            Destroy(gameObject, 2);
        }

        if (HitInfo.gameObject.tag == "OuterWall"){
            Destroy(gameObject);
        }
    }
}
