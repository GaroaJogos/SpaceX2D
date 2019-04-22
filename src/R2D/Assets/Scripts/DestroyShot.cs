using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroir", 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Destroir()
    {
        Destroy(this.gameObject);
    }
}
