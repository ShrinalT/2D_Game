using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float dspeed = 3.0f;
    [SerializeField]
    private float powerid;
    [SerializeField]
    private AudioClip _clip;
    
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * dspeed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
           Destroy(this.gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                AudioSource.PlayClipAtPoint(_clip, transform.position);
                switch (powerid)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        //speed
                        player.SpeedboostActive();
                        break;
                    case 2:
                        player.ShieldPlayer();
                        break;
                    default:
                        Debug.Log("Default value ");
                        break;

                }

            }
            Destroy(this.gameObject);
        }
    }
}
