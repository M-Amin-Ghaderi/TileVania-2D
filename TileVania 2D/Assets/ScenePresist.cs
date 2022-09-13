using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePresist : MonoBehaviour
{
    int startingSceneIndex;
    private void Awake()
    {
        int presistCount = FindObjectsOfType<ScenePresist>().Length;
        if (presistCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (startingSceneIndex != currentScene)
        {
            Destroy(gameObject);
        }
    }
}
