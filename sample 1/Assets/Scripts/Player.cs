using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _spd = 3.5f;
    private float _spd_boost = 2;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private GameObject _tripleshot;
    [SerializeField]
    private float firerate = 0.4f;
    private float canfire = -1f;
    [SerializeField]
    private int _lives = 3;
    private SpwanManager spwanManager;
    [SerializeField]
    private bool _istripleshotactive = false;
    private bool _isSpeedBoostActive = false;
    private bool _isShieldActive = false;
    [SerializeField]
    private GameObject _shield;
    [SerializeField]
    private int _score;
    private UIManager _uiManager;
    
    void Start()
    {
        // assign to new position to (0,0,0)
        transform.position = new Vector3(0, 0, 0);
        spwanManager = GameObject.Find("Spwan_Manager").GetComponent<SpwanManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();


        
    }

    
    void Update()
    {
        Playermv();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canfire)
        {
            shootmtd();
        }

            //spwan our laser

        }
    void Playermv()
    {


        float horizontalinput = Input.GetAxis("Horizontal");
        float verticaliinput = Input.GetAxis("Vertical");
        if (_isSpeedBoostActive == true)
        {
            transform.Translate(new Vector3(horizontalinput, verticaliinput, 0) * _spd * Time.deltaTime*_spd_boost);
        }
        else
        {
            transform.Translate(new Vector3(horizontalinput, verticaliinput, 0) * _spd * Time.deltaTime);
        }

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y , -3.8f, 0), 0);
        if (transform.position.x >= 10.8)
        {
            transform.position = new Vector3(10.8f, transform.position.y, 0);
        }
        else if (transform.position.x <= -10.8f)
        {
            transform.position = new Vector3(-10.8f, transform.position.y, 0);
        }
    }
    void shootmtd()
    {   
        
            canfire = Time.time + firerate;
        if(_istripleshotactive)
        {
            Instantiate(_tripleshot, transform.position + new Vector3(0, 1.0f, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1.0f, 0), Quaternion.identity);
        }
            
        
    }
    public void Damage()
    {
        if (_isShieldActive)
        {
            _isShieldActive = false;
            _shield.SetActive(_isShieldActive);
            return;
        }
        _lives--;

        _uiManager.UpdateLives(_lives);
        if (_lives == 0)
        {
            Destroy(this.gameObject);
            spwanManager.isPlayerDead();
            _uiManager.GameOver();
        }
    }
    public void ShieldPlayer()
    {

        _isShieldActive = true;
        _shield.SetActive(_isShieldActive);
    }
    public  void TripleShotActive()
    {
        _istripleshotactive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _istripleshotactive = false;
    }
    public void SpeedboostActive()
    {
        _isSpeedBoostActive = true;
        StartCoroutine(SpeedBoostPowerDownRountine());

    }
    IEnumerator SpeedBoostPowerDownRountine()
    {
        yield return new WaitForSeconds(5.0f);
        _isSpeedBoostActive = false;
    }
    public void addScore(int points)
    {
        _score += points;
        _uiManager.updateScore(_score);
    }
 }
