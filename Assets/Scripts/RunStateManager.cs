using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine.Utility;

public class GlobalVariables
{
    public static int money = 0;
}

public class RunStateManager : MonoBehaviour
{


    public RunState currentRunState = null;

    public GameObject grannyCart;

    public CartController cartController;

    public GameObject dialogueSystem;

    public GameObject carSpawner;

    public SpaceCartController spaceCartController;

    public GameObject spaceCamera;

    public GameObject spaceStaleCamera;

    public Animator sceneBlackBarAnimator;

    public Animator PDDAnimator;

    public bool talkked = false;

    public CountDown countDown;

    public Progress progress;

    public BuyButton buyButton;

    public GameObject gameCamera;

    public CameraController cameraController;

    public GameObject PDDFull;

    public GameObject cartRocket;

    public GameObject ScrollerBackground;

    void Start()
    {

        ChangeState(new ChaseEarth(this));

    }

    // Update is called once per frame
    void Update()
    {
        currentRunState.StateBehavior();
    }

    public void ChangeState(RunState newState)
    {
        if (currentRunState != null) currentRunState.Leave();
        currentRunState = newState;
        currentRunState.Enter();
    }

    public void changeToPDDState()
    {
        ChangeState(new PingDuoDuo(this));
    }

    public void changeMoney(int money)
    {
        GlobalVariables.money += money;
    }

    public void changeToShooterState()
    {
        if (!currentRunState.ToString().Equals("SpaceShooter"))
        {
ChangeState(new SpaceShooter(this));
        }
        
    }

}