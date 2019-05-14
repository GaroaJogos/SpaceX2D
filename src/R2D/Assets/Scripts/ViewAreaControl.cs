using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewAreaControl : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool ok = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ok);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "finishPoint")
        {
            ok = true;
        }
    }
}
