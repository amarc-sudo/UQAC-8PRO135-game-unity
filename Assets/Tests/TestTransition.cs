using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class TestScript1
{
    private string sceneToUnload;
    
    // A Test behaves as an ordinary method
    [Test]
    public void TestScript1SimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestTransitionEndScene() {
        EditorSceneManager.OpenScene("Assets/Scenes/level/Level4.unity");
        yield return new WaitForSeconds(3f);
        Assert.AreEqual(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, "Menu");
    }
    
  
}

