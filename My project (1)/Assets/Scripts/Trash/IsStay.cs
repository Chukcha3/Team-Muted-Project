using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsStay : MonoBehaviour
{
    public bool Stay = true;
    private void OnTriggerStay2D(Collider2D other) 
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Ground"))
        {
            Stay = true;
        }
        else
        {
            Stay = false;
        }
    }
   // private void OnTriggerExit(Collider other)
    //{

    //    isStay = false;
    //}
}
