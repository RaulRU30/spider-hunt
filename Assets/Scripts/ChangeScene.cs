using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    FadeInOut fade;
    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator ChangeSceneCoroutine()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(fade.TimeToFade);
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
