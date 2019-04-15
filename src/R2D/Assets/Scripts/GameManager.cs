using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject NaveInimigo1;
    public Text texto;
    public static bool working = true;
    
    // Start is called before the first frame update
    void Start()
    {
        texto.text = "Pontuação: 0";
        Moveinimigo.texto = texto;
        InvokeRepeating("CriaInimigo", 1f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && (!working))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            working = true;
        }
    }

    void CriaInimigo()
    {
        if (working)
        {
            float alturaAleatoria = 10f * Random.value - 5;

            GameObject novoInimigo = Instantiate(NaveInimigo1);
            novoInimigo.transform.position = new Vector2(15f, alturaAleatoria);
        }
    }
}
