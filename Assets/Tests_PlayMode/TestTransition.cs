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
    
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator SphereIsAffectByGravity() {
        var loadSceneOperation = SceneManager.LoadSceneAsync("Assets/Scenes/level/Level2.unity");
        loadSceneOperation.allowSceneActivation = true;
 
        while (!loadSceneOperation.isDone)
            yield return null;
        
        GameObject prefabRoot = GameObject.Find("Sphere");
        prefabRoot.transform.position = new Vector3(1310.3f, 701, 0);
        yield return new WaitForSeconds(1f);
        Assert.AreNotEqual(prefabRoot.transform.position, new Vector3(1310.3f, 701, 0));
    }
    public IEnumerator TestTransitionBeetwenLevel2AndLevel3()
    {
        var loadSceneOperation = SceneManager.LoadSceneAsync("Assets/Scenes/level/Level2.unity");
        loadSceneOperation.allowSceneActivation = true;
 
        while (!loadSceneOperation.isDone)
            yield return null;
        yield return new WaitForSeconds(4f);
        Assert.AreEqual(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, "Level3");
    }
    
}
