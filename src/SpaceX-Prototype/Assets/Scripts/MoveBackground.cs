using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBackground : MonoBehaviour
{
    
    private Vector3 _endx = new Vector3 (-27.5f, 0.0f, 0.1f);
    private GameObject mini;
    private MiniBoss miniboss;
    private bool bossAlive;
    private Boss boss;
    private SpawnManager spawnManager;

    [SerializeField]
    private GameObject _miniboss;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private GameObject gameMaganer;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
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
            //if (!bossAlive)
            if(mini == null)
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
                    spawnManager.SpawnAsteroide = false;
                    spawnManager.SpawnEnemyShip = false;
                    spawnManager.SpawnPowerupIcons = false;
                    bossAlive = false;
                }

                if ((boss != null) && (boss.bossLife <= 0) )
                {
                    boss._BossDead();
                    spawnManager.SpawnAsteroide = false;
                    spawnManager.SpawnEnemyShip = false;
                    spawnManager.SpawnPowerupIcons = false;
                    bossAlive = false;
                }
            }
        }
    }
}
