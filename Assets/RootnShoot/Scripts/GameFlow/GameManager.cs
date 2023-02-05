using Assets.RootnShoot.Scripts.Root;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public PlayerInput Input;
    public RootController rootController;

    public void StartLevel()
    {
        rootController.StartLevel();
    }

    public void EndLevel()
    {

    }

    public void EnterPauseMenu()
    {
        Input.SwitchCurrentActionMap("Menu");
        ButtonHandler.Instance.EscPress();
    }

    public void CloseMenu()
    {
        Input.SwitchCurrentActionMap("Root");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
