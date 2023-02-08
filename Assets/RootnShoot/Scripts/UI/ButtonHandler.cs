using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ButtonHandler : SingletonMonoBehaviour<ButtonHandler>
{
    public Text nutriScoreText;

    public Button currentButton;

    public GameObject upgradeMenu;
    public GameObject pauseMenu;
    public GameObject startMenu;
    public GameObject endScreen;

    public Text titleText;
    public Text descriptionText;
    public Text costText;
    public Image inspectorIcon;
    public Sprite questionMark;
    public Button buyButton;
    public GameObject X;
    public GameObject continueButton;

    public float fadeTime;
    public float maxVolume;

    public AudioSource menuRest;
    public AudioSource menuSolo;
    public AudioSource soundTrack;

    public GameObject startIcon;
    public GameObject seedIcon;
    public GameObject titleIcon;
    public float scrollSpeed;
    bool move;
    bool fade;
    public Slider slider;
    public AudioMixer audioMixer;

    public int gameState;

    public new void Awake()
    {
        UpgradeManager.Instance.UpgradePoints= (int)UpgradeManager.Instance.UpgradePoints;
        nutriScoreText.text = UpgradeManager.Instance.UpgradePoints.ToString();
        move = false;
        slider.onValueChanged.AddListener(delegate { audioMixer.SetFloat("Audio", -40 + (slider.value / slider.maxValue)*60); });
        base.Awake();
    }

    public void BuyClick()
    {
        int nutriCost = currentButton.GetComponent<ButtonSkript>().Upgrade((int)UpgradeManager.Instance.UpgradePoints);
        UpgradeManager.Instance.UpgradePoints-= nutriCost;
        nutriScoreText.text = UpgradeManager.Instance.UpgradePoints.ToString();
    }

    
    public void EscPress()
    {
        switch (gameState)
        {
            case 0:
                StartGame();
                break;
            case 1:
                if (pauseMenu.activeSelf)
                {
                    ClosePauseMenu();
                }
                else if(upgradeMenu.activeSelf)
                {
                    upgradeMenu.SetActive(false);
                    pauseMenu.SetActive(true);
                }
                break;
            case 2:
                pauseMenu.SetActive(true);
                X.SetActive(true);
                
                gameState = 1;
                break;

        }
    }

    public void OpenUpgradeMenu()
    {
        if(gameState == 1)
        {
            X.SetActive(true);
            continueButton.SetActive(false);
            upgradeMenu.SetActive(true);
            pauseMenu.SetActive(false);
            currentButton = null;
            nutriScoreText.text = UpgradeManager.Instance.UpgradePoints.ToString();
            titleText.text = "";
            descriptionText.text = "";
            costText.text = "--";
            inspectorIcon.sprite = questionMark;
            buyButton.gameObject.SetActive(false);
        }
    }

    public void ClosePauseMenu()
    {
        continueButton.SetActive(false);
        X.SetActive(false);
        pauseMenu.SetActive(false);
        gameState = 2;
        GameManager.Instance.CloseMenu();
    }

    public void Evolve()
    {
        gameState = 0;
        upgradeMenu.SetActive(true);
        pauseMenu.SetActive(false);
        X.SetActive(false);
        continueButton.SetActive(true);
        currentButton = null;
        titleText.text = "";
        descriptionText.text = "";
        costText.text = "--";
        inspectorIcon.sprite = questionMark;
        buyButton.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        GameManager.Instance.LevelIntro();
        upgradeMenu.SetActive(false);
        gameState = 2;
    }

    public void StartNewGame()
    {
        seedIcon.SetActive(false);
        fade = true;
        GameManager.Instance.LevelIntro();
        move = true;
        gameState = 2;
    }

    public void FinishGame()
    {
        endScreen.SetActive(true);
    }

    public void TerminateGame()
    {
        Application.Quit();
    }






    public void Update()
    {
        if(move)
        {
            if (titleIcon.transform.position.y <= 1000)
            {
                titleIcon.transform.position = new Vector3(titleIcon.transform.position.x, titleIcon.transform.position.y + scrollSpeed, titleIcon.transform.position.z);
                startIcon.transform.position = new Vector3(startIcon.transform.position.x, startIcon.transform.position.y + scrollSpeed, startIcon.transform.position.z);
            }
            if(titleIcon.transform.position.y >= 1000)
            {
                move = false;
                startMenu.SetActive(false);
            }
        }
        if(fade)
        {
            if(soundTrack.volume <= maxVolume)
                soundTrack.volume += fadeTime;
            if(menuSolo.volume >= 0)
                menuSolo.volume -= fadeTime;
            if (menuRest.volume >= 0)
                menuRest.volume -= fadeTime;

            if (soundTrack.volume >= maxVolume && menuSolo.volume <= 0 && menuRest.volume <= 0)
            {
                fade = false;
                menuRest.Stop();
                menuSolo.Stop();
            }
        }
    }

}
