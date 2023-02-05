using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : SingletonMonoBehaviour<ButtonHandler>
{
    public int nutriScore;
    public Text nutriScoreText;

    public Button currentButton;

    public GameObject upgradeMenu;
    public GameObject pauseMenu;

    public Text titleText;
    public Text descriptionText;
    public Text costText;
    public Image inspectorIcon;
    public Sprite questionMark;
    public Button buyButton;
    public GameObject X;

    public float fadeTime;
    public float maxVolume;

    public int gameState;

    public new void Awake()
    {
        nutriScore = (int)UpgradeManager.Instance.UpgradePoints;
        nutriScoreText.text = nutriScore.ToString();
        base.Awake();
    }

    public void BuyClick()
    {
        int nutriCost = currentButton.GetComponent<ButtonSkript>().Upgrade(nutriScore);
        nutriScore -= nutriCost;
        nutriScoreText.text = nutriScore.ToString();
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
                nutriScore = (int)UpgradeManager.Instance.UpgradePoints;
                gameState = 1;
                break;

        }
    }

    public void OpenUpgradeMenu()
    {
        if(gameState == 1)
        {
            upgradeMenu.SetActive(true);
            pauseMenu.SetActive(false);
            currentButton = null;
            titleText.text = "";
            descriptionText.text = "";
            costText.text = "--";
            inspectorIcon.sprite = questionMark;
            buyButton.gameObject.SetActive(false);
        }
    }

    public void ClosePauseMenu()
    {
        X.SetActive(false);
        pauseMenu.SetActive(false);
        gameState = 2;
        GameManager.Instance.CloseMenu();
        UpgradeManager.Instance.UpgradePoints = nutriScore;
    }

    public void Evolve()
    {
        gameState = 0;
        upgradeMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void StartGame()
    {

    }

    public void StartNewGame()
    {

    }

}
