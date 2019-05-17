using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBrackground1 : MonoBehaviour
{
    float larguraTela;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-0.4f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (ViewAreaControl.ok)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
