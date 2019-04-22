using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveHero : MonoBehaviour
{
    float speed = 8;
    Rigidbody2D corpoJogador;
    public Text warn;

    public GameObject shot;
    public GameObject explosion;
    private float fireRate = 0.2f;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        corpoJogador = GetComponent<Rigidbody2D>();
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

        
        //if (corpoJogador.position.x > 0)
        //{
            corpoJogador = GetComponent<Rigidbody2D>();
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
        //}

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
