using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject doorL;
    public GameObject doorR;
    public GameObject doorTargetL;
    public GameObject doorTargetR;
    public float speed;
    
    bool isStatic = true;

    Vector3 startPosL;
    Quaternion startRotL;
    Vector3 startPosR;
    Quaternion startRotR;

    float randomTime;

    public float minTime;
    public float maxTime;

    float randomDoorID;
    float timmer;

    public GameObject loseText;
    public GameObject freezeText;
    public GameObject runText;

    public GameObject[] lightsInside;
    public GameObject[] lightsOutside;

    // Start is called before the first frame update
    void Start()
    {
        randomTime = Random.Range(minTime, maxTime);
        randomDoorID = Random.Range(0.0f, 3.0f);
        startPosL = doorL.transform.position;
        startRotL = doorL.transform.rotation;
        startPosR = doorR.transform.position;
        startRotR = doorR.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Timmer();
        RandomOpen();
        OpenAndClose();
        LightChanger();
    }
    void Timmer()
    {
        timmer += Time.deltaTime;
    }

    void RandomOpen()
    {
        if (isStatic && timmer >= randomTime)
        {
            isStatic = false;
            timmer = 0f;
            runText.SetActive(false);
            freezeText.SetActive(true);
            Debug.Log("Freeze!");
        }
    }

    void OpenAndClose()
    {
        if (randomDoorID <= 1.0f)
        {
            OpenAndCloseBoth();
        }
        else if (randomDoorID > 1.0f && randomDoorID <= 2.0f)
        {
            OpenAndCloseL();
        }
        else if (randomDoorID > 2.0f)
        {
            OpenAndCloseR();
        }
    }

    void OpenAndCloseL()
    {
        if (!isStatic && timmer <= 1.0f)
        {
            doorL.transform.rotation = Quaternion.Lerp(doorL.transform.rotation, doorTargetL.transform.rotation, Time.deltaTime * speed);
            doorL.transform.position = Vector3.Lerp(doorL.transform.position, doorTargetL.transform.position, Time.deltaTime * speed);
        }
        else if (!isStatic && timmer >1.0f && timmer <= 4.0f)
        {
            doorL.transform.rotation = Quaternion.Lerp(doorL.transform.rotation, doorTargetL.transform.rotation, Time.deltaTime * speed);
            doorL.transform.position = Vector3.Lerp(doorL.transform.position, doorTargetL.transform.position, Time.deltaTime * speed);
            CowDetector();
        }
        else if (!isStatic && timmer > 4.0f && timmer <= 4.5f)
        {
            doorL.transform.rotation = Quaternion.Lerp(doorL.transform.rotation, startRotL, Time.deltaTime * speed * 10);
            doorL.transform.position = Vector3.Lerp(doorL.transform.position, startPosL, Time.deltaTime * speed * 10);
            runText.SetActive(true);
            freezeText.SetActive(false);
            Debug.Log("Run!");
        }
        else if (!isStatic && timmer > 4.5f)
        {
            doorL.transform.rotation = startRotL;
            doorL.transform.position = startPosL;
            randomTime = Random.Range(minTime, maxTime);
            randomDoorID = Random.Range(0.0f, 3.0f);
            isStatic = true;
            timmer = 0f;
        }
    }

    void OpenAndCloseR()
    {
        if (!isStatic && timmer <= 1.0f)
        {
            doorR.transform.rotation = Quaternion.Lerp(doorR.transform.rotation, doorTargetR.transform.rotation, Time.deltaTime * speed);
            doorR.transform.position = Vector3.Lerp(doorR.transform.position, doorTargetR.transform.position, Time.deltaTime * speed);
        }
        else if (!isStatic && timmer > 1.0f && timmer <= 4.0f)
        {
            doorR.transform.rotation = Quaternion.Lerp(doorR.transform.rotation, doorTargetR.transform.rotation, Time.deltaTime * speed);
            doorR.transform.position = Vector3.Lerp(doorR.transform.position, doorTargetR.transform.position, Time.deltaTime * speed);
            CowDetector();
        }
        else if (!isStatic && timmer > 4.0f && timmer <= 4.5f)
        {
            doorR.transform.rotation = Quaternion.Lerp(doorR.transform.rotation, startRotR, Time.deltaTime * speed * 10);
            doorR.transform.position = Vector3.Lerp(doorR.transform.position, startPosR, Time.deltaTime * speed * 10);
            runText.SetActive(true);
            freezeText.SetActive(false);
            Debug.Log("Run!");
        }
        else if (!isStatic && timmer > 4.5f)
        {
            doorR.transform.rotation = startRotR;
            doorR.transform.position = startPosR;
            randomTime = Random.Range(minTime, maxTime);
            randomDoorID = Random.Range(0.0f, 3.0f);
            isStatic = true;
            timmer = 0f;
        }
    }

    void OpenAndCloseBoth()
    {
        if (!isStatic && timmer <= 1.0f)
        {
            doorL.transform.rotation = Quaternion.Lerp(doorL.transform.rotation, doorTargetL.transform.rotation, Time.deltaTime * speed);
            doorL.transform.position = Vector3.Lerp(doorL.transform.position, doorTargetL.transform.position, Time.deltaTime * speed);
            doorR.transform.rotation = Quaternion.Lerp(doorR.transform.rotation, doorTargetR.transform.rotation, Time.deltaTime * speed);
            doorR.transform.position = Vector3.Lerp(doorR.transform.position, doorTargetR.transform.position, Time.deltaTime * speed);
        }
        else if (!isStatic && timmer > 1.0f && timmer <= 4.0f)
        {
            doorL.transform.rotation = Quaternion.Lerp(doorL.transform.rotation, doorTargetL.transform.rotation, Time.deltaTime * speed);
            doorL.transform.position = Vector3.Lerp(doorL.transform.position, doorTargetL.transform.position, Time.deltaTime * speed);
            doorR.transform.rotation = Quaternion.Lerp(doorR.transform.rotation, doorTargetR.transform.rotation, Time.deltaTime * speed);
            doorR.transform.position = Vector3.Lerp(doorR.transform.position, doorTargetR.transform.position, Time.deltaTime * speed);
            CowDetector();
        }
        else if (!isStatic && timmer > 4.0f && timmer <= 4.5f)
        {
            doorL.transform.rotation = Quaternion.Lerp(doorL.transform.rotation, startRotL, Time.deltaTime * speed * 10);
            doorL.transform.position = Vector3.Lerp(doorL.transform.position, startPosL, Time.deltaTime * speed * 10);
            doorR.transform.rotation = Quaternion.Lerp(doorR.transform.rotation, startRotR, Time.deltaTime * speed * 10);
            doorR.transform.position = Vector3.Lerp(doorR.transform.position, startPosR, Time.deltaTime * speed * 10);
            CowDetector();
        }
        else if (!isStatic && timmer > 4.5f)
        {
            doorL.transform.rotation = startRotL;
            doorL.transform.position = startPosL;
            doorR.transform.rotation = startRotR;
            doorR.transform.position = startPosR;
            randomTime = Random.Range(minTime, maxTime);
            randomDoorID = Random.Range(0.0f, 3.0f);
            isStatic = true;
            timmer = 0f;
            runText.SetActive(true);
            freezeText.SetActive(false);
            Debug.Log("Run!");
        }
    }

    void CowDetector()
    {
        if (FindObjectOfType<CowManager>() != null)
        {
            freezeText.SetActive(false);
            loseText.SetActive(true);
            FindObjectOfType<WinDetector>().lose = true;
            Debug.Log("You Lose!");
            Destroy(FindObjectOfType<CowManager>());
            Destroy(this);
        }
    }

    void LightChanger()
    {
        foreach (GameObject go in lightsInside)
        {
            go.SetActive(isStatic);
        }
        foreach (GameObject go in lightsOutside)
        {
            go.SetActive(!isStatic);
        }
    }
}
