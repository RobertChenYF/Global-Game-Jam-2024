using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentRunStates : MonoBehaviour
{



}

public class Menu : RunState
{

    public Menu(RunStateManager runStateManager) : base(runStateManager)
    {

    }

    public override void StateBehavior()
    {
        //when player choose to enter combat
    }

    public override void Enter()
    {
        base.Enter();
  

    }

    public override void Leave()
    {
        base.Leave();

    }
}

public class FoodStandEarth : RunState
{

    public FoodStandEarth(RunStateManager runStateManager) : base(runStateManager)
    {

    }

    public override void StateBehavior()
    {
        //when player choose to enter combat

        
    }

    public override void Enter()
    {
        base.Enter();


    }

    public override void Leave()
    {
        base.Leave();

    }
}

public class ChaseEarth : RunState
{
    
    public ChaseEarth(RunStateManager runStateManager) : base(runStateManager)
    {

    }

    public override void StateBehavior()
    {

        //when player choose to enter combat

       if (manager.grannyCart.transform.position.x > 313 && manager.talkked == false)
        {
            manager.talkked = true;
            manager.ChangeState(new PeopleTalkEarth(manager));
           
        }
    }

    public override void Enter()
    {
        base.Enter();
        manager.cartController.stop = false;
        manager.cartController.speed = 8;
        manager.carSpawner.SetActive(true);
        Debug.Log("chase earth");

    }

    public override void Leave()
    {
        base.Leave();
        manager.cartController.stop = true;
        manager.carSpawner.SetActive(false);

    }
}

public class PeopleTalkEarth : RunState
{

    public PeopleTalkEarth(RunStateManager runStateManager) : base(runStateManager)
    {

    }

    public override void StateBehavior()
    {
        //when player choose to enter combat

        if (manager.cartController.speed >= 0)
        {
            manager.cartController.speed -= Time.deltaTime;

            manager.cartController.speed = Mathf.Max(manager.cartController.speed , 0);
        }

    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("people starts talk");

        manager.cartController.speed = 3;
        manager.cartController.stop = true;

        manager.dialogueSystem.SetActive(true);
        manager.carSpawner.SetActive(false);

    }

    public override void Leave()
    {
        base.Leave();
        manager.carSpawner.SetActive(true);
        manager.cartController.speed = 8;
        manager.cartController.stop = false;
        manager.dialogueSystem.SetActive(false);
    }
}

public class PingDuoDuo : RunState

{
    private float timer = 0;
    public PingDuoDuo(RunStateManager runStateManager) : base(runStateManager)
    {

    }

    public override void StateBehavior()
    {
        //when player choose to enter combat

        timer += Time.deltaTime;

        if (timer > 5)
        {
          //  EnableComponents();

        }
    }

    public override void Enter()
    {
        base.Enter();

        manager.cartController.speed = 0;

        manager.PDDAnimator.SetBool("enlarge", true);

        EnableComponents();
        

       // manager.spaceCamera.SetActive(true);

    }

    public override void Leave()
    {
        base.Leave();

    }

    public void EnableComponents()
    {
        manager.progress.enabled = true;
        manager.countDown.enabled = true;
        manager.buyButton.enabled = true;
    }


}

public class SpaceShooter : RunState
{
    float velocity = 1;

    public SpaceShooter(RunStateManager runStateManager) : base(runStateManager)
    {

    }

    public override void StateBehavior()
    {
        if (manager.spaceCartController.enabled == false)
        {
        velocity += Time.deltaTime * 2;
        velocity = Mathf.Min(5, velocity);

        manager.spaceCartController.gameObject.transform.position += new Vector3(0, velocity*Time.deltaTime, 0);
        }

        if (velocity == 5 && manager.spaceCartController.enabled == false)
        {
            manager.spaceCartController.enabled = true;

            manager.spaceStaleCamera.SetActive(true);
            //start scroll the background
        }


    }

    public override void Enter()
    {
        base.Enter();
        manager.cartController.enabled = false;
        manager.spaceCamera.SetActive(true);
        manager.sceneBlackBarAnimator.SetBool("SceneTransition",true);
        //move the camera transform and spaceCart transform maybe use animation

    }

    public override void Leave()
    {
        base.Leave();

    }
}