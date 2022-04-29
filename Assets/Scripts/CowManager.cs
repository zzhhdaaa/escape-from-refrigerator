using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CowManager : MonoBehaviour
{
    Rigidbody rb;
    NavMeshAgent navMeshAgent;
    float x;
    float z;

    [HideInInspector]
    public float followers = 0f;

    public float speed;
    public float jump;
    public float jumpTime;
    public float smash;
    public GameObject beef;
    public GameObject explosion;
    public GameObject smashFire;
    public Animation ani;

    bool canJump;
    float jumpTimmer;

    bool canSmash;
    float smashTimmer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Timmer();
        Change();
        AnimationControl();
    }

    void Move()
    {
        x = Input.GetAxis("Horizontal") * speed;
        z = Input.GetAxis("Vertical") * speed;
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(new Vector3(0f, jump, 0f));
            canJump = false;
            jumpTimmer = 0f;
        }
        if (x != 0 || z != 0)
        {
            if (rb != null)
            {
                rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(x, rb.velocity.y, z), Time.deltaTime * speed * 3.0f);
                if (rb.velocity.magnitude != 0)
                {
                    transform.forward = Vector3.Lerp(transform.forward, new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y/8f, GetComponent<Rigidbody>().velocity.z), 0.8f);
                }
                else
                {
                    transform.forward = transform.forward;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canSmash)
        {
            rb.AddForce(new Vector3(transform.forward.x, 0f, transform.forward.z).normalized * smash);
            canSmash = false;
            smashTimmer = 0f;
            smashFire.SetActive(true);
        }
    }

    void Timmer()
    {
        if (!canJump && jumpTimmer < jumpTime)
        {
            jumpTimmer += Time.deltaTime;
        }
        else if (!canJump && jumpTimmer >= jumpTime)
        {
            canJump = true;
        }

        if (!canSmash && smashTimmer < jumpTime)
        {
            smashTimmer += Time.deltaTime;
            rb.useGravity = false;
        }
        else if (!canSmash && smashTimmer >= jumpTime)
        {
            canSmash = true;
            smashFire.SetActive(false);
            rb.useGravity = true;
        }
    }

    void Change()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(beef, transform.position, transform.rotation).transform.localScale = transform.localScale;
            //Destroy(FindObjectOfType<ParticleSystem>().gameObject);
            Instantiate(explosion, transform.position, transform.rotation).transform.localScale *= transform.localScale.x;
            Destroy(gameObject);
        }
    }

    void AnimationControl()
    {
        if (rb.velocity.magnitude > 0.1f && rb.velocity.y < 0.1f)
        {
            ani.enabled = true;
        }
        else
        {
            ani.enabled = false;
        }
    }
}
