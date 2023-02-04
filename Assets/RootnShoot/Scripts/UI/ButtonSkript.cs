using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSkript : MonoBehaviour
{
    public List<Sprite> buttonSprites;
    private Transform HoverChild;
    private Image image;

    public void Awake()
    {
        HoverChild = transform.GetComponentInChildren<Transform>();
        HoverChild.gameObject.SetActive(false);
        image = GetComponent<Image>();
    }

    public void OnMouseOver()
    {
        HoverChild.gameObject.SetActive(true);
    }

    public void OnMouseExit()
    {
        HoverChild.gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        image.sprite = buttonSprites[1];
    }

    public void OnMouseUp()
    {
        image.sprite = buttonSprites[0];
    }
}
