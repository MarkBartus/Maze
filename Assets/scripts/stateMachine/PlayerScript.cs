using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.AI;

namespace Player
{


    public class PlayerScript : MonoBehaviour
    {
        public Transform[] points;
        public Transform pacMan;
        public NavMeshAgent path;
        public int destPoint;
        public bool running = false;
        

        public Rigidbody rb;
        //public Animator anim;
        public SpriteRenderer sr;
        public NavMeshAgent navi;



        public LayerMask player;

        
        // variables holding the different player states
        public IdleState idleState;
        public RunningState runningState;
        public AttackingState attackingState;


        public StateMachine sm;

        public float speed = 6f;
        public float jumpForce = 4f;


        public bool groundCheck;

        public GameObject checkSphere;
        public LayerMask playerMask;
        // Start is called before the first frame update
        void Start()
        {
            path = GetComponent<NavMeshAgent>();
            rb = GetComponent<Rigidbody>();
            sm = gameObject.AddComponent<StateMachine>();
            //anim = GetComponent<Animator>();
            sr = GetComponent<SpriteRenderer>();
            navi = GetComponent<NavMeshAgent>();
            // add new states here
            idleState = new IdleState(this, sm);
            runningState = new RunningState(this, sm);
            attackingState = new AttackingState(this, sm);

            // initialise the statemachine with the default state
            sm.Init(idleState);
        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.LogicUpdate();

            //output debug info to the canvas
            string s;
            s = string.Format("last state={0}\ncurrent state={1}", sm.LastState, sm.CurrentState);

            



        }



        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }

        public void CheckForPlayer()
        {
            if (Physics.CheckSphere(checkSphere.transform.position, 4f, playerMask))
            {
                Debug.Log("playerInSight");
                sm.ChangeState(attackingState);
            }
        }

        public void CheckForRun()
        {
            if (navi.velocity != Vector3.zero) 
            {
                sm.ChangeState(runningState);
                Debug.Log("running");
                return;
            }


        }


        public void CheckForIdle()
        {
            if ((!path.pathPending && path.remainingDistance < 0.5f) )
            {
                sm.ChangeState(runningState);
            }
            else
            {
                Debug.Log("idleState");
                sm.ChangeState(idleState);

            }

        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(checkSphere.transform.position, 4f);
        }


    }

}