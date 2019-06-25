using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverAudio;

    public int score = 0;
    public Text scoreText;
    public Text restartlevel;
    public Text gameOver;
    public GameObject player;
    private Player p;
   
    // Start is called before the first frame update
    void Start()
    {
       p = player.GetComponent<Player>();
    }

    void Update()
    {
    }

    public void UpdateScore()
    {
        score += 100;
        scoreText.text = "Pontuação: " + score;
    }

     public void RestartLevel()
     {
         if (p.lives == 0)
         {
            restartlevel.text = "Aperte a tecla: R para Reiniciar o jogo.";
            gameOver.text = "Game Over";
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
         }
      }
}
