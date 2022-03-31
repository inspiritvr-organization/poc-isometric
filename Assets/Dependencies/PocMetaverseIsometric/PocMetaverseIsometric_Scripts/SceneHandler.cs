using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
  
    public IEnumerator LoadScene(int sceneIndex, Action OnSceneLoaded=null)
    {
        AsyncOperation asyncop= SceneManager.LoadSceneAsync(sceneIndex);
        asyncop.allowSceneActivation = false;
        yield return asyncop.isDone;
        OnSceneLoaded?.Invoke();
        asyncop.allowSceneActivation = true;
    }

    public IEnumerator LoadScene(string sceneName, Action OnSceneLoaded = null)
    {
        AsyncOperation asyncop = SceneManager.LoadSceneAsync(sceneName);
        asyncop.allowSceneActivation = false;
        yield return asyncop.isDone;
        OnSceneLoaded?.Invoke();
        asyncop.allowSceneActivation = true;
    }
}
