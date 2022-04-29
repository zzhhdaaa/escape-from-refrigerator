using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefManager : MonoBehaviour
{
    public GameObject cow;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Change();
    }

    void Change()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(cow, transform.position, transform.rotation).transform.localScale = transform.localScale;
            //Destroy(FindObjectOfType<ParticleSystem>().gameObject);
            Instantiate(explosion, transform.position, transform.rotation).transform.localScale *= transform.localScale.x;
            Destroy(gameObject);
        }
    }
}
