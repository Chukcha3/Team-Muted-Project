using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody2D rg;
    public bool isFly = false;
    private BuildingManager bm;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        bm = Player.GetComponent<BuildingManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            isFly = true;
            rg.gravityScale = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFly)
        {
            this.transform.position += new Vector3(0.0f, 1.0f, 0.0f);
        }
    }
}
