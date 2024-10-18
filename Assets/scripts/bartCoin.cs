using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bartCoin : MonoBehaviour
{

    pacMan pm;
    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<pacMan>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("got"))
        {
            pm.coin += 1;
            Destroy(this.gameObject);
        }
    }
}
