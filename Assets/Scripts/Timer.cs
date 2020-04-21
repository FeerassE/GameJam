using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = ((int)timer).ToString();
    }
}
