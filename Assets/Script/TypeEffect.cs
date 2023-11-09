using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public int CharPerSeconds;
    public GameObject Cursor;
    public bool isAnimation;
    string targetMsg;
   Text msgText;
    AudioSource audioSource;
    int index;
    float interval;


     void Awake()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SetMsg(string msg)
    {
        if (isAnimation)
        {
            msgText.text = targetMsg;
            CancelInvoke();

            EffectEnd();

        }
        else
        {
        targetMsg = msg;
        EffectStart();

        }
    }

    // Update is called once per frame
    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        Cursor.SetActive(false);

        //Start Animation
        interval = 1.0f / CharPerSeconds;
        Debug.Log(interval);
        isAnimation = true;
        Invoke("Effecting", interval);
    }

    void Effecting()
    {

        if(msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }
        msgText.text += targetMsg[index];

        //Sound Play
        if (targetMsg[index] != ' ' || targetMsg[index] != '.')
        audioSource.Play();

        index++;
        //Recursive
        Invoke("Effecting", interval);
    }


    void EffectEnd()
    {
        isAnimation = false;
        Cursor.SetActive(true);
    }
}
