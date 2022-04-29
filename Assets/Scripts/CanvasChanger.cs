using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasChanger : MonoBehaviour
{
    public Text textFake;
    public Text textReal;

    bool hiddenShow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hiddenShow && Input.GetKeyDown(KeyCode.F))
        {
            hiddenShow = true;
        }
        else if (hiddenShow && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (hiddenShow)
        {
            textFake.color = new Color(textFake.color.r, textFake.color.g, textFake.color.b, Mathf.Lerp(textFake.color.a, 0f, Time.deltaTime * 3f));
            textReal.color = new Color(textReal.color.r, textReal.color.g, textReal.color.b, Mathf.Lerp(textReal.color.a, 1f, Time.deltaTime * 3f));
        }
    }
}
