using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveHero : MonoBehaviour
{
    float speed = 8;
    Rigidbody2D corpoJogador;

    Sprite heroiCima;
    Sprite heroiBaixo;
    SpriteRenderer spriteHeroi;
    Sprite normalSpriteAnimation;
    Animator animator;

    public Text warn;

    public GameObject shot;
    public GameObject explosion;
    private float fireRate = 0.22f;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        corpoJogador = GetComponent<Rigidbody2D>();
        spriteHeroi = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        heroiCima = Resources.Load<Sprite>("NaveHeroiCima");
        heroiBaixo = Resources.Load<Sprite>("NaveHeroiBaixo");
        normalSpriteAnimation = Resources.Load<Sprite>("NaveHeroi1_2");
        warn.enabled = false;
    }

    void CriaTiro()
    {
        Transform transform = corpoJogador.transform;
        GameObject tiro = Instantiate(
            shot, 
            new Vector3(corpoJogador.transform.localPosition.x + 1, corpoJogador.transform.localPosition.y, 0.0f), 
            corpoJogador.transform.rotation);
        tiro.name = "tiro";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            CriaTiro();
        }


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        corpoJogador.velocity = movement * speed;

        corpoJogador.position = new Vector3
        (
            Mathf.Clamp(corpoJogador.position.x, -9, 9),
            Mathf.Clamp(corpoJogador.position.y, -5, 5),
            0.0f
        );

        if (moveVertical > 0)
        {
            spriteHeroi.sprite = heroiCima;
            animator.enabled = false;
        }
        else if (moveVertical < 0)
        {
            spriteHeroi.sprite = heroiBaixo;
            animator.enabled = false;
        }
        else
        {
            spriteHeroi.sprite = normalSpriteAnimation;
            animator.enabled = true;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name != "tiro")
        {
            this.enabled = false;
            warn.text = "Game Over. Pressione R para reiniciar";
            warn.enabled = true;
            GameManager.working = false;
            Sounds.stopMusic();

            GameObject explosao = Instantiate(
                explosion,
                corpoJogador.transform.position,
                corpoJogador.transform.rotation);

            Destroy(this.gameObject);
        }
    }

}
