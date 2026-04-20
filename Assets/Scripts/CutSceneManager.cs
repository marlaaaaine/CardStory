using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    public static CutSceneManager Instance { get; private set; }
    private readonly int _mainScene = 0;
    private int _currentScene;

    /// <summary> Set the instance of the cutscene manager; there should only exist one. </summary>
    private void Awake()
    {
        Instance = this;
    }

    // Asynchronous additive load (Recommended for performance)
    public IEnumerator LoadSceneAsync(int sceneIndex)
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
    /// Aysnch additive unloading of scene
    /// </summary>
    /// <param name="sceneIndex"></param>
    /// <returns></returns>
    public IEnumerator UnloadRoutine(int sceneIndex)
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
