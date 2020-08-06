using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Laser_script : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 8.0f ;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*Time.deltaTime*speed);
        if(transform.position.y >= 7)
        {
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
 