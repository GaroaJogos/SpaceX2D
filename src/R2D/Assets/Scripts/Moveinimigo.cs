using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moveinimigo : MonoBehaviour
{
    public static Text texto;
    public static int count = 0;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        texto.text = "Pontuação: " + (count * 50);
        GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
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
        texto.text = "Pontuação: " + (count * 50);

        GameObject explosao = Instantiate(
            explosion,
            this.transform.position,
            this.transform.rotation);

        Destroy(this.gameObject);
    }
}
