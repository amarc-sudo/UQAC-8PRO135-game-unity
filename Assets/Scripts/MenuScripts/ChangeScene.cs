using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    /**
     * The name of the scene to go
     */
    public string sceneName;

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
        
    }
}
