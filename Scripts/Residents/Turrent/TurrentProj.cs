using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentProj : MonoBehaviour
{
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 90 * Time.deltaTime));
    }

    void OnTriggerEnter2D (Collider2D HitInfo)
  {
        if (HitInfo.gameObject.tag == "Player"){
            manager.GetComponent<EffectController>().Stunned = true;
            Debug.Log ("stunned = true");
            Destroy(gameObject);
        }

        if (HitInfo.gameObject.tag == "OuterWall"){
            Destroy(gameObject);
        }

  }


}
