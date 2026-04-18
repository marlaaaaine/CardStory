using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    private int _mainScene = 0;
    private int _currentScene;

    // Asynchronous additive load (Recommended for performance)
    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        // keep track of the current scene 
        _currentScene = sceneIndex;
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        while (!op.isDone)
        {
            yield return null;
        }
        // scene is now fully loaded
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sceneIndex"></param>
    /// <returns></returns>
    IEnumerator UnloadRoutine(int sceneIndex)
    {
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneIndex);
        while (!asyncUnload.isDone)
        {
            yield return null;
        }
        // Scene is now fully unloaded
        // should the main scene be loaded here
    }


}
