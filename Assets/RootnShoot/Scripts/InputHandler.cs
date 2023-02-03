using Assets.RootnShoot.Scripts.Root;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] RootController rootController;

    private Vector3 ChargeStartPos;
    private bool IsCharging = false;

    public void OnShoot(InputValue value)
    {
        //Vector3 WorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //rootController.ShootToTarget(WorldPos);
    }

    public void OnCharge(InputValue value)
    {
        if(value.isPressed)
        {
            ChargeStartPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        }
        else
        {
            Vector3 ReleasePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Debug.Log("Shoot\nDirection: " + (ChargeStartPos - ReleasePos) + "\nStart: " + ChargeStartPos + "\nRelease: " + ReleasePos);
            rootController.ShootToTarget(ChargeStartPos - ReleasePos);
        }
    }

    public void OnNavUp()
    {
        rootController.Navigate(RootController.Direction.Up);
    }
    public void OnNavDown()
    {
        rootController.Navigate(RootController.Direction.Down);
    }

    public void OnNavLeft()
    {
        rootController.Navigate(RootController.Direction.Left);
    }
    public void OnNavRight()
    {
        rootController.Navigate(RootController.Direction.Right);
    }

}
