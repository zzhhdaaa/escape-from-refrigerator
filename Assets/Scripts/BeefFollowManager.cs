using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefFollowManager : MonoBehaviour
{
    public GameObject cowFollow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cow"))
        {
            Instantiate(cowFollow, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
