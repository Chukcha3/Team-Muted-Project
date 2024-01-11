using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    PlayerMove3 Script1;
    Fly Script2;
    [SerializeField] public GameObject target;
    bool a;
    void Start()
    {

    }
    void Update()
    {
        /*
        Script2.enabled = false;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            a = !a;
        }
        bool b = a ? Player = Point1: Player = Point2;*/
        transform.position = target.transform.position - new Vector3(0,0,10);
    }
}
