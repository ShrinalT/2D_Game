using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float dspeed = 3.0f;
    private Player _player;
    private Animator anim;
    private AudioSource _audioSource;
    


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
       
      
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * dspeed * Time.deltaTime);

        if( transform.position.y < - 5f)
        {
            float randomX = Random.Range(-9f, 9f);
            transform.position =    new Vector3( randomX , 7 , 0); 

        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        //player damage player destroy us
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if(player != null )
            {
                player.Damage();
            }
            anim.SetTrigger("OnEnemyDead");
            _audioSource.Play();
            dspeed = 0;
            Destroy(this.gameObject, 2.5f);
            
            

        }
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if(_player != null)
            {
                _player.addScore(10);
            }
            
            anim.SetTrigger("OnEnemyDead");
            dspeed = 0;
            _audioSource.Play();
            Destroy(this.gameObject,0.8f);
            

        }
        //laser destroy laser and damage 
    }
}
