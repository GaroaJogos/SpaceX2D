using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{

    static AudioSource music;
    
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    public static void stopMusic()
    {
        music.Stop();
    }

}
