using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShot2 : MonoBehaviour
{
    [SerializeField]
    private float _speedH = 35.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right + Vector3.down * _speedH * Time.deltaTime);
        if (transform.position.x >= 9.0f && transform.position.y <= -5.0f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
