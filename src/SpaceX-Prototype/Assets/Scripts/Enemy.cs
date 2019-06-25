using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private GameObject _explosion;
    private UImanager _uimanager;

    // Start is called before the first frame update
    void Start()
    {
        _uimanager = GameObject.Find ("Canvas").GetComponent<UImanager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Movement();
    }

    private void _Movement()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.x < -10f)
        {
            float randomY = Random.Range(-4.2f, 4.2f);
            transform.position = new Vector3(10f, randomY, 0);
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
            Destroy (this.gameObject);
        }
    }
}
