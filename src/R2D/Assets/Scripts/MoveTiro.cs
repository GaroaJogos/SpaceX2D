using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTiro : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -25)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name != "NaveHeroi1")
            Destroy(this.gameObject);
    }

}
