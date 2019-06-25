using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniBoss : MonoBehaviour
{
    public int bossLife;
    private UImanager _uimanager;
    [SerializeField]
    private GameObject _explosion;

    [SerializeField]
    private GameObject _bossShot;

    // Start is called before the first frame update
    void Start()
    {
        bossLife = 250;
        _uimanager = GameObject.Find("Canvas").GetComponent<UImanager>();
        StartCoroutine(BossShotSpawn());
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void _BossAttack()
    {
        Instantiate(_bossShot, new Vector2(5.18f, 0.0f), Quaternion.identity);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
            Instantiate(_explosion, transform.position, Quaternion.identity);
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
            bossLife--;
            _BossDead();           
        }
    }

    public void _BossDead()
    {
        if (bossLife <= 0)
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);
            SceneManager.LoadScene("TransitionToLevel02");
            //Destroy(this.gameObject);
        }       
    }

    public IEnumerator BossShotSpawn()
    {
        while (true)
        {
            _BossAttack();
            yield return new WaitForSeconds(5.0f);
        }
    }
}
