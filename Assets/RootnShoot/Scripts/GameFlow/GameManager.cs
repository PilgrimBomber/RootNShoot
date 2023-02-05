using Assets.RootnShoot.Scripts.Root;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public PlayerInput playerInput;
    public RootController rootController;
    public Transform ResetPosition;
    public CinemachineVirtualCamera virtualCamera;
    public LevelIntro levelIntro;
    public void Start()
    {
        LevelIntro();
    }

    public void LevelIntro()
    {
        SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);
        virtualCamera.Follow = levelIntro.Seed.transform;
        levelIntro.BeginIntro();
    }

    public void StartLevel()
    {
        
        rootController.StartLevel();
        

        playerInput.SwitchCurrentActionMap("Roots");
    }

    public void EndLevel()
    {
        SceneManager.UnloadScene("Level1");
        //Jump To StartPos
        virtualCamera.Follow = ResetPosition;
        //Open Upgrade Menu
        //ButtonHandler.Instance.Evolve();
    }

    public void Victory()
    {

    }

    public void EnterPauseMenu()
    {
        playerInput.SwitchCurrentActionMap("Menu");
        ButtonHandler.Instance.EscPress();
    }

    public void CloseMenu()
    {
        playerInput.SwitchCurrentActionMap("Roots");
    }

}
