using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private GameObject _explosion;

    private UImanager _uimanager;

    [SerializeField]
    private GameObject _miniboss;
    MiniBoss miniboss;
    Boss boss;

    // Start is called before the first frame update
    void Start()
    {
        _uimanager = GameObject.Find("Canvas").GetComponent<UImanager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Movement();
    }

    private void _Movement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -6f)
        {
            float randomX = Random.Range(-10f, 10f);
            transform.position = new Vector3(randomX, 5.2f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (other.tag == "Laser")
        {
            if (other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }
            Destroy(other.gameObject);
            Instantiate(_explosion, transform.position, Quaternion.identity);
            _uimanager.UpdateScore();
            Destroy(this.gameObject);
        }
        
        else if (other.tag == "Enemy")
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);

            if(other.gameObject.name.StartsWith("Mini-Boss_0"))
            {
                miniboss = other.gameObject.GetComponent<MiniBoss>();
                miniboss.bossLife -= 5;
            }
            else if (other.gameObject.name.StartsWith("Boss"))
            {
                boss = other.gameObject.GetComponent<Boss>();
                --boss.bossLife;
            }
            else
            {
                Destroy(other.gameObject);
            }

            Destroy(this.gameObject);
        }
        
    }
}
