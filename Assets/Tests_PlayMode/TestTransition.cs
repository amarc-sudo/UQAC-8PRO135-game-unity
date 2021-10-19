using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class TestTransition
{
    [UnityTest]
    
    public IEnumerator TestTransitionEndScene()
    {
        var loadSceneOperation = SceneManager.LoadSceneAsync("Assets/Scenes/level/Level4.unity");
        loadSceneOperation.allowSceneActivation = true;
 
        while (!loadSceneOperation.isDone)
            yield return null;
        yield return new WaitForSeconds(3f);
        Assert.AreEqual(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, "Menu");
    }
    
    [UnityTest]
    public IEnumerator PressButtonPlayShouldLaunchFirstLevel()
    {
    
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        
        
        var loadSceneOperation = SceneManager.LoadSceneAsync("Assets/Scenes/Menu.unity");
        loadSceneOperation.allowSceneActivation = true;

        while (!loadSceneOperation.isDone)
        {
            yield return null;
        }


        var boutonplayGameObject = GameObject.Find("ButtonPlay");
        var boutonplay = boutonplayGameObject.GetComponent<Button>();
        Assert.NotNull(boutonplay);
        boutonplay.onClick.Invoke();
        yield return null;
        yield return new WaitForSeconds(1);
        Assert.AreEqual(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, "Level1");
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator PressButtonSettingsShouldLaunchSettingsScene()
    {
    
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        
        
        var loadSceneOperation = SceneManager.LoadSceneAsync("Assets/Scenes/Menu.unity");
        loadSceneOperation.allowSceneActivation = true;

        while (!loadSceneOperation.isDone)
        {
            yield return null;
        }


        var boutonsettingGameObject = GameObject.Find("ButtonSettings");
        var boutonsetting = boutonsettingGameObject.GetComponent<Button>();
        Assert.NotNull(boutonsetting);
        boutonsetting.onClick.Invoke();
        yield return null;
        yield return new WaitForSeconds(1);
        Assert.AreEqual(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, "Settings");
        yield return null;
    }
    
    
}
