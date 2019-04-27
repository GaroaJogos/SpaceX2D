using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroir", 3);
    }

    void Destroir()
    {
        Destroy(this.gameObject);
    }
}
