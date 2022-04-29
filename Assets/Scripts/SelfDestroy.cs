using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    float timmer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timmer += Time.deltaTime;
        if (timmer > 1.0f)
        {
            Destroy(gameObject);
        }
    }
}
