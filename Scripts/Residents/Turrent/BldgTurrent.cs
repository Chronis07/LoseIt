using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BldgTurrent : MonoBehaviour
{
    public LayerMask NoticeMe;
    public float Range;
    public Transform Target;
    public bool Detected = false;
    Vector2 Direction;

    public GameObject bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    //public Transform Shootpoint;
    public float Force;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,Direction,Range, NoticeMe);
        if (rayInfo)
        {
            Debug.DrawRay(transform.position, Direction, Color.green);
            //Debug.Log(rayInfo.collider.gameObject.layer);

            if(rayInfo.collider.gameObject.layer == 9)
            {
                Debug.DrawRay(transform.position, Direction, Color.red);

                if (Detected == false)
                {
                    Detected = true;
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                }
            }
        }
        else
        {
            Detected = false;

            Debug.DrawRay(transform.position, Direction, Color.green);
        }



        if (Detected)
        {
            if(Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }
    }
    void shoot()
    {
        GameObject BulletIns = Instantiate(bullet, transform.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }



}
