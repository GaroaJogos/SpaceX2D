using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static bool gameStart = true;

    [SerializeField]
    private GameObject player;

    private Player p;
    private UImanager _uiManager;
    private bool _gameOverAudio = true;
    private AudioSource[] audioSources;

    private bool playDeadAudio = true;
    
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UImanager>();
        audioSources = GetComponents<AudioSource>();
        p = player.GetComponent<Player>();
        p.lives = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(p.lives == 0)
        {
            audioSources[0].Stop();

            if (!audioSources[1].isPlaying && playDeadAudio)
            {
                audioSources[1].Play();
                playDeadAudio = false;
            }
        }

        _uiManager.RestartLevel();
    }
  
}
