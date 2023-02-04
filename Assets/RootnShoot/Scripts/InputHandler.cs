using Assets.RootnShoot.Scripts.Root;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] RootController rootController;
    private LineRenderer chargeLine;
    private Vector3 ChargeStartPos;
    private bool IsCharging = false;

    private void Awake()
    {
        chargeLine = GetComponentInChildren<LineRenderer>();
        chargeLine.gameObject.SetActive(false);
        chargeLine.positionCount = 2;
    }

    private void Update()
    {
        if(IsCharging)
        {
            Vector3 currentMousePos = (Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            chargeLine.SetPosition(1, currentMousePos );
            rootController.juiceBar.material.SetFloat("JuiceForShot", rootController.CalculateJuiceCost(currentMousePos-ChargeStartPos));
        }
    }

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
            IsCharging = true;
            chargeLine.gameObject.SetActive(true);
            chargeLine.SetPosition(0, (Vector2)ChargeStartPos);

        }
        else
        {
            IsCharging = false;
            rootController.juiceBar.material.SetFloat("JuiceForShot",0);
            Vector3 ReleasePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            //Debug.Log("Shoot\nDirection: " + (ChargeStartPos - ReleasePos) + "\nStart: " + ChargeStartPos + "\nRelease: " + ReleasePos);
            rootController.ShootToTarget(ChargeStartPos - ReleasePos);
            chargeLine.gameObject.SetActive(false);
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
