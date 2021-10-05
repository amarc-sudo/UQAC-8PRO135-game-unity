using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOne : MonoBehaviour
{
    public string sceneName;
    public float timeLeft = 30.0f;
    public int timerShown;

    public Text timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("TimerShown").GetComponent<Text>();
    }
    public void DoChangeScene()
    {
        SceneManager.LoadScene(this.sceneName);
    }
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timerShown = (int)timeLeft;
        timer.text = timerShown.ToString();
        if (timeLeft < 0)
        {
            DoChangeScene();
        }
    }
}
