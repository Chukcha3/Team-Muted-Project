using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsStay : MonoBehaviour
{
    public bool isStay = true;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isStay = true;
        }
        else
        {
            isStay = false;
        }
    }
   // private void OnTriggerExit(Collider other)
    //{

    //    isStay = false;
    //}
}
