using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    public static CutSceneManager Instance { get; private set; }
    private readonly int _mainScene = 0;
    private int _currentScene;

    #region Initialization

    /// <summary> Set the instance of the cutscene manager; there should only exist one. </summary>
    private void Awake()
    {
        Instance = this;
    }

    #endregion

    #region Loading Scenes
    /// <summary> asynchronously loads the scene by the given index </summary>
    /// <param name="sceneIndex"></param>
    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadSceneAsync(sceneIndex));
    }

    /// <summary> Asynch additive scene loading </summary>
    /// <param name="sceneIndex"></param>
    /// <returns></returns>
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
        Debug.Log("scene asynch loading done");
    }
    #endregion

    #region Unloading Scenes

    /// <summary> asychronously unloads the scene by the given index </summary>
    /// <param name="sceneIndex"></param>
    public void UnloadScene(int sceneIndex)
    {
        StartCoroutine(UnloadRoutine(sceneIndex));
    }

    /// <summary> Aysnch additive unloading of scene </summary>
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

    #endregion


}
