
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


namespace Player

{
    public class RunningState : State
    {

        

        // constructor
        public RunningState(PlayerScript player, StateMachine sm) : base(player, sm)
        {

        }

        public override void Enter()
        {

            base.Enter();
            Debug.Log("Pathfinding");
            
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
            base.LogicUpdate();


            player.CheckForPlayer();
            
            


            Debug.Log("checking for player");


        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (!player.path.pathPending && player.path.remainingDistance < 0.5f)
            {
                if (player.points.Length == 0)
                {
                    return;
                }
                player.path.destination = player.points[player.destPoint].position;
                player.destPoint = (player.destPoint + 1) % player.points.Length;
            }
            
            
        }
    }
}