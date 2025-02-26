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

    private IEnumerator ChangeSceneCoroutine()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(fade.timeToFade);
        SceneManager.LoadScene("Game");
    }
    
    public void ChangeToScene()
    { 
        StartCoroutine(ChangeSceneCoroutine());
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
    
}
