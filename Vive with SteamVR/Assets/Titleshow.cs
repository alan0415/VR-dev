using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Titleshow : MonoBehaviour
{
    // Start is called before the first frame update
    public float charsPerSecond = 0.2f;
    private string words;

    private bool isActive = false;
    private float timer;
    private Text mytext;
    private int currentPos = 0;
    void Start()
    {
        timer = 0;
        isActive = true;
        charsPerSecond = Mathf.Max(0.2f, charsPerSecond);
        mytext = GetComponent<Text>();
        words = mytext.text;
        mytext.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        onStartWriter();
    }

    public void StartEffect()
    {
        isActive = true;
    }

    void onStartWriter()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            {
                timer = 0;
                currentPos++;
                mytext.text = words.Substring(0, currentPos);

                if(currentPos >= words.Length)
                {
                    onFinish();
                }
            }
        }
    }
    void onFinish()
    {
        isActive = false;
        timer = 0;
        currentPos = 0;
        mytext.text = words;
    }
}
