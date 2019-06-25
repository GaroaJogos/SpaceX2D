using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShot : MonoBehaviour
{
    [SerializeField]
    private float _speed = 35.0f;
    [SerializeField]
    private GameObject[] shotgunShell;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shotgunShell[0].transform.Translate(Vector3.right + Vector3.up * 2 * _speed * Time.deltaTime);
        shotgunShell[1].transform.Translate(Vector3.right + Vector3.up * _speed * Time.deltaTime);
        shotgunShell[2].transform.Translate(Vector3.right * 3 * _speed * Time.deltaTime);
        shotgunShell[3].transform.Translate(Vector3.right + Vector3.down * _speed * Time.deltaTime);
        shotgunShell[4].transform.Translate(Vector3.right + Vector3.down * 2 * _speed * Time.deltaTime);

        for(int i = 0; i <= 4; ++i)
        {
            if (shotgunShell[i].transform.position.x >= 10.0f && shotgunShell[i].transform.position.y >= 6)
            {
                if (transform.parent != null)
                {
                    Destroy(transform.parent.gameObject);
                }

                Destroy(this.gameObject);
            }
            else if (shotgunShell[i].transform.position.x <= -10.0f && shotgunShell[i].transform.position.y <= -6)
            {
                if (transform.parent != null)
                {
                    Destroy(transform.parent.gameObject);
                }

                Destroy(this.gameObject);
            }
        }

    }

   /* public void ShotgunShoot()
    {
        shotgunShell[0].transform.Translate(Vector3.right + Vector3.up * 2 * _speed * Time.deltaTime);
        shotgunShell[1].transform.Translate(Vector3.right + Vector3.up * _speed * Time.deltaTime);
        shotgunShell[2].transform.Translate(Vector3.right * 3 * _speed * Time.deltaTime);
        shotgunShell[3].transform.Translate(Vector3.right + Vector3.down * _speed  * Time.deltaTime);
        shotgunShell[4].transform.Translate(Vector3.right + Vector3.down * 2 * _speed * Time.deltaTime);
        if (transform.position.x >= 10.0f && transform.position.y >= 6)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }
        else if (transform.position.x <= -10.0f && transform.position.y <= -6)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }*/
}
