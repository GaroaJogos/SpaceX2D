using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniBoss : MonoBehaviour
{
    public int bossLife;
    public bool bossAtack = false;
    public bool isAlive = true;
    private UImanager _uimanager;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    [SerializeField]
    private GameObject _explosion;

    [SerializeField]
    private GameObject _bossShot;

    // Start is called before the first frame update
    void Start()
    {
        _uimanager = GameObject.Find("Canvas").GetComponent<UImanager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        bossLife = 250;
        bossAtack = true;
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
        if(bossLife > 0)
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
    }

    public IEnumerator BossShotSpawn()
    {
        while (bossAtack)
        {
            _BossAttack();
            yield return new WaitForSeconds(5.0f);
        }
    }

    public void _BossDead()
    {
        if ( (bossLife <= 0) && isAlive)
        {
            bossAtack = false;
            isAlive = false;
            StartCoroutine(BossDead());
        }
    }

    private IEnumerator BossDead()
    {
        Color color = spriteRenderer.color;
        audioSource.Stop();
        for (int i = 0; i < 6; ++i)
        {
            spriteRenderer.color = Color.red;
            Vector3 position = transform.position;
            Instantiate(_explosion, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(.350f);

            spriteRenderer.color = color;
            Instantiate(_explosion, position * -0.001f, Quaternion.identity);
            yield return new WaitForSeconds(.350f);

            spriteRenderer.color = Color.red;
            Instantiate(_explosion, Vector3.up * -0.3f, Quaternion.identity);
            yield return new WaitForSeconds(.350f);

            spriteRenderer.color = color;
            Instantiate(_explosion, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(.350f);
        }

        SceneManager.LoadScene("TransitionToLevel02");
    }
}
