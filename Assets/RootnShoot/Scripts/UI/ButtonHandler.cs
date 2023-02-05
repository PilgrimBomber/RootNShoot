using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
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

    public int gameState;

    public void Awake()
    {
        nutriScoreText.text = nutriScore.ToString();
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
                break;
            case 1:
                if (pauseMenu.activeSelf)
                {
                    pauseMenu.SetActive(false);
                    gameState = 2;
                }
                else if(upgradeMenu.activeSelf)
                {
                    upgradeMenu.SetActive(false);
                    pauseMenu.SetActive(true);
                }
                break;
            case 2:
                pauseMenu.SetActive(true);
                gameState = 1;
                break;

        }
    }

    public void OpenUpgradeMenu()
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
