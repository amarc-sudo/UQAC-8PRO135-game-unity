using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSceneToSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("Settings");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
