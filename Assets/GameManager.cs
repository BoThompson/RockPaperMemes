using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas StartCanvas;
    public Canvas MainMenuCanvas;
    public Canvas PlayCanvas;
    public Canvas ResultsCanvas;
    public Canvas PlayAgainCanvas;
    public Canvas currentCanvas;
    public enum Choice
    {
        Rock = 0,
        Paper = 1,
        Meme = 2
    }

    public Choice PlayerChoice;
    public Choice AIChoice;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        //Set my current canvas to StartCanvas, turn it on
        currentCanvas = StartCanvas;
        currentCanvas.gameObject.SetActive(true);
        //Turn off the other canvases
        PlayCanvas.gameObject.SetActive(false);
        PlayAgainCanvas.gameObject.SetActive(false);
        MainMenuCanvas.gameObject.SetActive(false);
        ResultsCanvas.gameObject.SetActive(false);
    }

    public void GoToPlayScreen()
    {
        currentCanvas.gameObject.SetActive(false);
        currentCanvas = PlayCanvas;
        currentCanvas.gameObject.SetActive(true);
    }

    public void GoToMainMenuScreen()
    {
        currentCanvas.gameObject.SetActive(false);
        currentCanvas = MainMenuCanvas;
        currentCanvas.gameObject.SetActive(true);
    }

    public void SelectRock()
    {
        PlayerChoice = Choice.Rock;
        AIChoose();
        GoToResults();
    }

    public void SelectPaper()
    {
        PlayerChoice = Choice.Paper;
        AIChoose();
        GoToResults();
    }

    public void SelectMeme()
    {
        PlayerChoice = Choice.Meme;
        AIChoose();
        GoToResults();
    }
    public void AIChoose()
    {
        AIChoice = (Choice)Random.Range(0, 3);
    }

    public void GoToResults()
    {
        currentCanvas.gameObject.SetActive(false);
        UpdateResults();
        currentCanvas = ResultsCanvas;
        currentCanvas.gameObject.SetActive(true);
    }

    public void UpdateResults()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
