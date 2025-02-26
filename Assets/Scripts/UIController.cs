using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject gameInfoPanel;
    public GameObject gameOverPanel;
    public GameObject gameVictoryPanel;
    public GameObject buttonContainer;
    // Start is called before the first frame update
    void Start()
    {
        gameInfoPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        gameVictoryPanel.SetActive(false);
        buttonContainer.SetActive(true);
    }
    
    public void WinGame()
    {
        gameVictoryPanel.SetActive(true);
        gameInfoPanel.SetActive(false);
        buttonContainer.SetActive(false);
    }
    
    public void LoseGame()
    {
        gameOverPanel.SetActive(true);
        gameInfoPanel.SetActive(false);
        buttonContainer.SetActive(false);
    }
}
