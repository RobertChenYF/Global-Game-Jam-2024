using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public bool talkked = false;

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



}