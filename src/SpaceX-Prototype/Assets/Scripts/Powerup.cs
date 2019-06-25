using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int powerupID;
  

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.x < -10.0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                if (powerupID == 0)
                {
                    player.DoubleShotOn();
                }
                else if (powerupID == 1)
                {
                    player.ShotgunOn();
                }  
                else if (powerupID == 2)
                {
                    player.MachineGunOn();
                }
                else if (powerupID == 3)
                {
                    player.ShieldsOn();
                }

            }

            Destroy(this.gameObject);
        }

    }
}
