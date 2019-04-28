using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moveinimigo : MonoBehaviour
{
    public static Text texto;
    public static int count = 0;
    public GameObject explosion;
    private int dano = 0;
    private SpriteRenderer inimigoSprite;

    // Start is called before the first frame update
    void Start()
    {
        texto.text = "Pontuação: " + (count * 50);
        GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
        inimigoSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -25)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        ++count;
        ++dano;
        texto.text = "Pontuação: " + (count * 50);

        switch(dano)
        {
            case 1:
                inimigoSprite.color = Color.yellow;
                break;

            case 2:
                inimigoSprite.color = Color.red;
                break;

            case 3:
                GameObject explosao = Instantiate(
                    explosion,
                    this.transform.position,
                    this.transform.rotation);

                Destroy(this.gameObject);
                break;
        }
    }
}
