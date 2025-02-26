using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    FadeInOut fade;
    
    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    void Update()
    {

    }

    private IEnumerator ChangeSceneCoroutine(string sceneName)
    {
        fade.FadeIn();
        yield return new WaitForSeconds(fade.timeToFade);
        SceneManager.LoadScene(sceneName);
    }
    
    public void ChangeToScene(string sceneName)
    { 
        StartCoroutine(ChangeSceneCoroutine(sceneName));
    }
    
    
    public void ExitGame()
    {
        Application.Quit();
    }
    
}
