using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacMan : MonoBehaviour
{
    public CharacterController controller;

    private float speed = 4f;
    public int health = 2;

    public int coin = 0;
    private void Start()
    {

       
        
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        Run();
    }

    public void win()
    {
        if( coin == 3 )
        {
            Debug.Log("Player Has Won");
        }
    }     

    public void Run()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 7;
        }
        else
        {
            speed = 4;
        }
    }

}
