using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class TestTransition
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestTransitionSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
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
}
