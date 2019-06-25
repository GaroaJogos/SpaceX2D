using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunShot : MonoBehaviour
{

    [SerializeField]
    private float _speed = 35.0f;
    [SerializeField]
    private float _frequency = 50f;
    [SerializeField]
    private float _magnitude = 2.5f;


    Vector3 pos;
    
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        pos += transform.right * _speed * Time.deltaTime;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * _frequency) * _magnitude;
        if (transform.position.x > 10.0f)
        {
            Destroy(this.gameObject);
        }
       
    }
}
