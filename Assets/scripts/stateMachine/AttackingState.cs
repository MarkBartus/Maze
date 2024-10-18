
using System.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Player
{
    public class AttackingState : State
    {


        public float timer;
        public int DMG = 1;
        

        // constructor
        public AttackingState(PlayerScript player, StateMachine sm) : base(player, sm)
        {

        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Attacking");

            timer = 10f;
            
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

           

            if(timer <= 0)
            {
                player.CheckForRun();
            }
            else
            {
                timer -= Time.deltaTime;
                
            }

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            player.path.destination = player.pacMan.position;

        }

     

    }
}