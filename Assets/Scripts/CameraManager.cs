using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    Transform target;
    public float offsetY = 0.2f;
    public float offsetZ = 0.5f;
    public float offsetSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindTarget();
    }

    void FindTarget()
    {
        if (FindObjectOfType<CowManager>() != null)
        {
            target = FindObjectOfType<CowManager>().gameObject.transform;
            transform.position = new Vector3(0, Mathf.Lerp(transform.position.y, target.position.y + offsetY, Time.deltaTime * offsetSpeed), -offsetZ);
            GetComponent<CinemachineVirtualCamera>().LookAt = target;
        }
    }
}
