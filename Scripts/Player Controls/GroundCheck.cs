using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool is_grounded;
    [SerializeField] private LayerMask GroundLayer;

    private void OnTriggerStay2D (Collider2D collider){
        is_grounded = collider != null && (((1 << collider.gameObject.layer) & GroundLayer) != 0);
    }
    private void OnTriggerExit2D (Collider2D collider){
        is_grounded = false;
    }
}
