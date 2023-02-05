using Assets.RootnShoot.Scripts.Root;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public PlayerInput Input;
    public RootController rootController;
    public Transform ResetPosition;
    public CinemachineVirtualCamera virtualCamera;

    public void LevelIntro()
    {
        SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);
    }

    public void StartLevel()
    {
        
        rootController.StartLevel();
        Input.SwitchCurrentActionMap("Root");
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
