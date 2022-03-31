using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
        set
        {
            if (instance == null)
            {
                instance = value;
            }
        }
    }
    private static GameManager instance;

    [SerializeField]private SceneHandler sceneHandler;
  

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void LoadScene(string sceneName,Action OnSceneCompeleted=null)
    {
        StartCoroutine(sceneHandler.LoadScene(sceneName,OnSceneCompeleted));
    }


    public void LoadScene(int sceneIndex, Action OnSceneCompeleted = null)
    {
        StartCoroutine(sceneHandler.LoadScene(sceneIndex, OnSceneCompeleted));
    }

}
