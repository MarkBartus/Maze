
using UnityEngine;
namespace Player
{
    public class IdleState : State
    {

       
        // constructor
        public IdleState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();

            //player.anim.Play("", 0, 0);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            player.CheckForRun();
            player.CheckForPlayer();
            Debug.Log("checking for run");
            base.LogicUpdate();

            if ((!player.path.pathPending && player.path.remainingDistance < 0.5f))
            {
                sm.ChangeState(player.runningState);
            }

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

    }
}