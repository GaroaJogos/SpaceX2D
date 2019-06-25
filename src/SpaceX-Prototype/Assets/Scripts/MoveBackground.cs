using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBackground : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Vector3 _endx = new Vector3 (-27.5f, 0.0f, 0.1f);
    [SerializeField]
    private GameObject _miniboss;
    private GameObject mini;
    MiniBoss miniboss;
    private bool bossAlive;

    private Boss boss;

    [SerializeField]
    private GameObject gameMaganer;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        BackgroundMovement();
        //CallMiniBoss();
        StageClear();   
    }

    private void BackgroundMovement()
    {
        print(transform.position.x);
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position != _endx)
        {
            transform.position = Vector3.MoveTowards(transform.position, _endx, _speed * Time.deltaTime);
        }
    }

    private void StageClear()
    {
        if (transform.position.x <= _endx.x)
        {
            if (!bossAlive)
            {
                AudioSource audioLevel = gameMaganer.GetComponent<AudioSource>();
                audioLevel.Stop();
                mini = Instantiate(_miniboss, new Vector3(5.83f, 0.47f, 0.1f), Quaternion.identity);

                AudioSource minibossAudio = mini.GetComponent<AudioSource>();
                minibossAudio.Play();
                miniboss = mini.GetComponent<MiniBoss>();
                bossAlive = true;
                if (miniboss == null)
                {
                    boss = mini.GetComponent<Boss>();
                }
            }
            else
            {
                if((miniboss!= null) && (miniboss.bossLife <= 0) )
                {
                    miniboss._BossDead();
                    bossAlive = false;
                }

                if ((boss != null) && (boss.bossLife <= 0) )
                {
                    boss._BossDead();
                    bossAlive = false;
                }
            }
        }
    }
}
