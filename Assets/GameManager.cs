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
    public AudioSource Victory;
    public AudioSource Loss;
    public Image P1Image;
    public Image P2Image;
    public Text ResultText;
    public Sprite RockSprite;
    public Sprite PaperSprite;
    public Sprite MemeSprite;

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

    public void GoToPlayAgain()
    {
        currentCanvas.gameObject.SetActive(false);
        currentCanvas = PlayAgainCanvas;
        currentCanvas.gameObject.SetActive(true);
    }

    public void UpdateResults()
    {
        switch(PlayerChoice)
        {
            case Choice.Rock: P1Image.color = Color.red; P1Image.sprite = RockSprite; break;
            case Choice.Paper: P1Image.color = Color.blue; P1Image.sprite = PaperSprite; break;
            case Choice.Meme: P1Image.color = (Color.red + Color.yellow) / 2; P1Image.sprite = MemeSprite; break;
        }

        switch (AIChoice)
        {
            case Choice.Rock: P2Image.color = Color.red; P2Image.sprite = RockSprite; break;
            case Choice.Paper: P2Image.color = Color.blue; P2Image.sprite = PaperSprite; break;
            case Choice.Meme: P2Image.color = (Color.red + Color.yellow) / 2; P2Image.sprite = MemeSprite; break;
        }

        if (PlayerChoice == Choice.Rock && AIChoice == Choice.Paper)
        {
            ResultText.text = "The AI just won!";
            Victory.enabled = false;
            Loss.enabled = true;
        }else if (PlayerChoice == Choice.Rock && AIChoice == Choice.Meme)
        {
            ResultText.text = "You just won!";
            Victory.enabled = true;
            Loss.enabled = false;
        }
        else if (PlayerChoice == Choice.Paper && AIChoice == Choice.Meme)
        {
            ResultText.text = "The AI just won!";
            Victory.enabled = false;
            Loss.enabled = true;
        }
        else if (PlayerChoice == Choice.Paper && AIChoice == Choice.Rock)
        {
            ResultText.text = "You just won!";
            Victory.enabled = true;
            Loss.enabled = false;
        }
        else if (PlayerChoice == Choice.Meme && AIChoice == Choice.Rock)
        {
            ResultText.text = "The AI just won!";
            Victory.enabled = false;
            Loss.enabled = true;
        }
        else if (PlayerChoice == Choice.Meme && AIChoice == Choice.Paper)
        {
            ResultText.text = "You just won!";
            Victory.enabled = true;
            Loss.enabled = false;
        }
        else
        {
            ResultText.text = "Nobody won!";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
