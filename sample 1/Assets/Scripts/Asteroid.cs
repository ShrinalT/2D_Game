using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _Rspeed = 3.0f;
    [SerializeField]
    private GameObject _ExposionPrefab;
    private SpwanManager _spwanManager;
    void Start()
    {
        _spwanManager = GameObject.Find("Spwan_Manager").GetComponent<SpwanManager>();
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * _Rspeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Instantiate(_ExposionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            _spwanManager.StartSpwan();
            Destroy(this.gameObject,0.15f);
            
                
        }
    }
}
