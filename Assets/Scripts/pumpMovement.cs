using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpMovement : MonoBehaviour
{

    public GameObject pump;
    //public GameObject cart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (pump.transform.rotation.x >= 15)
        {
            this.transform.rotation = Quaternion.Euler(15, 0, 0);
            
        }
        if (this.transform.rotation.x <= -15)
        {
            this.transform.rotation = Quaternion.Euler(-15, 0, 0);
        }
    }
}
