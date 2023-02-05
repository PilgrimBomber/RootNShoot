using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSkript : MonoBehaviour
{
    public Upgrade myUpgrade;
    public Image myIcon;
    public Button buyButton;
    public Button followMeButton;
    public GameObject followMeQuestionmark;
    public Text titleText;
    public Text descriptionText;
    public Text costText;
    public Image inspectorIcon;
    public ButtonHandler buttonHandler;
    public GameObject buttonHandlerG;

    public Image iconGlow;
    public List<Sprite> glowList;

    public int costIncrease;

    public void Awake()
    {
        buttonHandler = buttonHandlerG.GetComponent<ButtonHandler>();
        if (myUpgrade.purchased == true)
        {
            myIcon.color = new Color(42, 42, 42);
        }
        if(myUpgrade.upgradeType < 4)
            iconGlow.sprite = glowList[myUpgrade.stage];
    }

    public void Clicked()
    {
        if (myUpgrade.purchased != true)
        {
            if(buttonHandler.gameState == 0)
                buyButton.gameObject.SetActive(true);
            costText.text = myUpgrade.cost.ToString();
        }
        else
        {
            buyButton.gameObject.SetActive(false);
            costText.text = "--";
        }
        titleText.text = myUpgrade.title;
        descriptionText.text = myUpgrade.description;
        inspectorIcon.sprite = myUpgrade.icon;
        buttonHandler.currentButton = gameObject.GetComponent<Button>();
    }


    public int Upgrade(int total)
    {
        if (total >= myUpgrade.cost)
        {
            int oldCost = myUpgrade.cost;
            switch (myUpgrade.upgradeType)
            {
                case 0:
                    UpgradeManager.Instance.rootSpeedLevel++;
                    myUpgrade.cost += costIncrease;
                    break;
                case 1:
                    UpgradeManager.Instance.juiceCostLevel++;
                    myUpgrade.cost += costIncrease;
                    break;
                case 2:
                    UpgradeManager.Instance.rootStraightLevel++;
                    myUpgrade.cost += costIncrease;
                    break;
                case 3:
                    UpgradeManager.Instance.visionRangeLevel++;
                    myUpgrade.cost += costIncrease;
                    break;
                case 4:
                    UpgradeManager.Instance.hardlockLevel++;
                    break;
                case 5:
                    UpgradeManager.Instance.softlockLevel++;
                    break;
            }
            myUpgrade.stage++;
            if (myUpgrade.upgradeType < 4)
                iconGlow.sprite = glowList[myUpgrade.stage];
            costText.text = myUpgrade.cost.ToString();
            if (myUpgrade.stage >= myUpgrade.maxStage)
                CompleteUpgrade();
            return (oldCost);
        }
        else
            return (0);
    }

    public void CompleteUpgrade()
    {
        myIcon.color = new Color32(42,42,42, 255);
        if (followMeButton != null)
        {
            followMeButton.gameObject.SetActive(true);
            followMeQuestionmark.SetActive(false);
        }
        myUpgrade.purchased = true;
        buyButton.gameObject.SetActive(false);
        costText.text = "--";
    }
}
