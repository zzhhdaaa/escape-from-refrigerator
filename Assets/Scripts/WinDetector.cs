using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinDetector : MonoBehaviour
{
    public GameObject[] turnOff;
    public GameObject[] turnOn;

    public bool lose;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LoseChange();
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject go in turnOff)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in turnOn)
        {
            go.SetActive(true);
        }
        SceneManager.LoadScene("SimpleNaturePack_Demo");
    }

    void LoseChange()
    {
        if (lose)
        {
            foreach (GameObject go in turnOff)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in turnOn)
            {
                go.SetActive(true);
            }
            SceneManager.LoadScene("DecorativeScene");
        }
    }
}
