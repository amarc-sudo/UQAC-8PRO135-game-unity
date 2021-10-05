using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelFor : MonoBehaviour
{
    public string sceneName;
    public float timeLeft = 3.0f;
    

    // Start is called before the first frame update
    void Start()
    {
    }
    public void DoChangeScene()
    {
        SceneManager.LoadScene(this.sceneName);
    }
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            DoChangeScene();
        }
    }
}
