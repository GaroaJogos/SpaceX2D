using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canDoubleShot = false;
    public bool canShotgun = false;
    public bool canMachineGun = false;
    public bool isShieldActive = false;

    private AudioSource powerUpAudio;
    private AudioSource shieldAudio;

    [SerializeField]
    private GameObject _shotgun;
    [SerializeField]
    private GameObject _explosion;
    [SerializeField]
    private GameObject _Shield;
    [SerializeField]
    private GameObject doubleShot;
    [SerializeField]
    private float _playerSpeed = 1.5f;
    [SerializeField]
    private GameObject machineGun;
    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private float _fireRate = 0.25f;
    [SerializeField]
    private float _shotgunFireRate = 3f;
    [SerializeField]
    private float _machineGunRate = 0.15f;

    public int lives = 1;
    private float _canFire = 0.0f;

    Sprite heroiCima;
    Sprite heroiBaixo;
    SpriteRenderer spriteHeroi;
    Sprite normalSpriteAnimation;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        AudioSource [] audios = GetComponents <AudioSource>();
        powerUpAudio = audios[0];
        shieldAudio = audios[1];

        spriteHeroi = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        heroiCima = Resources.Load<Sprite>("NaveHeroiCima");
        heroiBaixo = Resources.Load<Sprite>("NaveHeroiBaixo");
        normalSpriteAnimation = Resources.Load<Sprite>("NaveHeroi1_2");
    }

    // Update is called once per frame
    void Update()
    {
        _MovePlayer();

        _Shoot();
    }

    private void _MovePlayer()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * _playerSpeed * inputHorizontal * Time.deltaTime);

        float inputVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * _playerSpeed * inputVertical * Time.deltaTime);

        Vector3 _posx = transform.position;
        _posx.x = Mathf.Clamp(_posx.x, -7.8f, 7.8f);
        _posx.y = Mathf.Clamp(_posx.y, -4f, 4f);
        transform.position = _posx;

        if (inputVertical > 0)
        {
            spriteHeroi.sprite = heroiCima;
            animator.enabled = false;
        }
        else if (inputVertical < 0)
        {
            spriteHeroi.sprite = heroiBaixo;
            animator.enabled = false;
        }
        else
        {
            spriteHeroi.sprite = normalSpriteAnimation;
            animator.enabled = true;
        }
    }

    private void _Shoot()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetButton("Fire1"))
        {
            if (canMachineGun == true)
            {
                _MachineGunShot();
            }
            else if (canShotgun == true)
            {
                _ShotgunShot();
            }
            else
            {
                _LaserShot();
            }

        }
    }

    private void _LaserShot()
    {
            if (Time.time > _canFire)
            {
            if (canDoubleShot == true)
            {
                Instantiate(doubleShot, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(laser, transform.position + new Vector3(0.81f, 0.77f), Quaternion.identity);
            }
            _canFire = Time.time + _fireRate;
        }
    }

    private void _MachineGunShot()
    {
        if (Time.time > _canFire)
        {
            if (canMachineGun == true)
            {
                Instantiate(machineGun, transform.position + new Vector3(0.81f, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(laser, transform.position + new Vector3(0.81f, 0.77f), Quaternion.identity);
            }
                _canFire = Time.time + _machineGunRate;
        }
        
    }

    private void _ShotgunShot()
    {
        if(Time.time > _canFire)
        {
            if (canShotgun == true)
            {
                Instantiate(_shotgun, transform.position + new Vector3(0.81f, 0), Quaternion.identity);
                
            }
            else
            {
                Instantiate(laser, transform.position + new Vector3(0.81f, 0.77f), Quaternion.identity);
            }
            _canFire = Time.time + _shotgunFireRate;
        }
   
    }

    public void DoubleShotOn()
    {
        powerUpAudio.Play();
        canDoubleShot =  true;
        StartCoroutine(DoubleShotOff());
    }
    public IEnumerator DoubleShotOff ()
    {
        yield return new WaitForSeconds(5.0f);
        canDoubleShot = false;
    }

    public void ShotgunOn()
    {
        powerUpAudio.Play();
        canShotgun = true;
        StartCoroutine(ShotgunOff());
    }

    public IEnumerator ShotgunOff()
    {
        yield return new WaitForSeconds(5.0f);
        canShotgun = false;
    }

    public void MachineGunOn()
    {
        powerUpAudio.Play();
        canMachineGun = true;
        StartCoroutine(MachineGunOff());
    }

    public IEnumerator MachineGunOff()
    {
        yield return new WaitForSeconds(5.0f);
        canMachineGun = false;
    }

    public void ShieldsOn()
    {
        powerUpAudio.Play();
        shieldAudio.Play();
        isShieldActive = true;
        _Shield.SetActive(true);
    }

    public void Damage()
    {
        if (isShieldActive == true)
        {
            isShieldActive = false;
            _Shield.SetActive(false);
            shieldAudio.Stop();
            return;
        }

        lives--;

        if (lives < 1)
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
