using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowFollowManager : MonoBehaviour
{
    public GameObject beefFollow;

    GameObject target;
    GameObject followTarget;
    float stopingDis = 0.1f;
    float speed = 3f;

    [HideInInspector]
    public float cowID;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<CowManager>().gameObject;
        target.GetComponent<CowManager>().followers += 1f;

        cowID = target.GetComponent<CowManager>().followers;

        if (target.GetComponent<CowManager>().followers == 1f)
        {
            followTarget = target;
        }
        else
        {
            foreach (CowFollowManager cFM in FindObjectsOfType<CowFollowManager>())
            {
                if (cFM.cowID == cowID - 1f)
                {
                    followTarget = cFM.gameObject;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Change();
    }

    void Follow()
    {
        if (Vector3.Distance(followTarget.transform.position, transform.position) > stopingDis)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.transform.position, Time.deltaTime * speed);
            transform.rotation = Quaternion.Lerp(transform.rotation, followTarget.transform.rotation, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, followTarget.transform.position.y, transform.position.z), Time.deltaTime * speed);
            transform.rotation = Quaternion.Lerp(transform.rotation, followTarget.transform.rotation, Time.deltaTime * speed);
        }
    }

    private void Change()
    {
        if (target == null)
        {
            Instantiate(beefFollow, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            Follow();
        }
    }
}
