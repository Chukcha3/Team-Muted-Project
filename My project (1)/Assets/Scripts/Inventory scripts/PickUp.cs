using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    void Start()
    {
        inventory = GetComponent<Inventory>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
