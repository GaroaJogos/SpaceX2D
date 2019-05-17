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
    private Color spriteColor;
    private float flashTime = 0.07f;


    // Start is called before the first frame update
    void Start()
    {
        texto.text = "Pontuação: " + (count * 50);
        GetComponent<Rigidbody2D>().velocity = new Vector2(-11, 0);
        inimigoSprite = GetComponent<SpriteRenderer>();
        spriteColor = inimigoSprite.color;
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
        if( (col.name == "ViewArea") || ((col.name == "finishPoint")) )
            return;
        
        StartCoroutine(Flash());

        ++dano;
        
        if (dano == 3)
        {
            ++count;
            texto.text = "Pontuação: " + (count * 50);

            GameObject explosao = Instantiate(
                    explosion,
                    this.transform.position,
                    this.transform.rotation);

            Destroy(this.gameObject);
        }
    }

    IEnumerator Flash()
    {
        for (int n = 0; n < 2; n++)
        {
            inimigoSprite.color = Color.red;
            yield return new WaitForSeconds(flashTime);
            inimigoSprite.color = spriteColor;
            yield return new WaitForSeconds(flashTime);
        }
    }

}
