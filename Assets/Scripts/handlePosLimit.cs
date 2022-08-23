using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handlePosLimit : MonoBehaviour
{
    public float highLimit;
    public float lowLimit;
    public GameObject cart;
    public float cartSpeed;
    //public GameObject pullyLocation;
    public float maxSpeed;
    //private float originalSpeed;
    private bool cartShouldMove;
    private bool timerActive;


    
    void Start()
    {
        //cartShouldMove = false;
        //originalSpeed = cartSpeed;
        //timerActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(this.transform.position.y >= highLimit)
        {
            this.transform.position = new Vector3(this.transform.position.x, highLimit, this.transform.position.z);
            Debug.Log("high limit reached");
        }

        if (this.transform.position.y <= lowLimit)
        {
            this.transform.position = new Vector3(this.transform.position.x, lowLimit, this.transform.position.z);
            Debug.Log("low limit reached");
        }*/
    }

    private void FixedUpdate()
    {
        if (this.transform.position.y >= highLimit)
        {
            this.transform.position = new Vector3(this.transform.position.x, highLimit, this.transform.position.z);
            //Debug.Log("high limit reached");
            //cartShouldMove = true;
            //cartSpeed = originalSpeed;
            //pullySound.pitch = Random.Range(0.7f, 1.2f);
            //pullySound.Play();

        }

        if (this.transform.position.y <= lowLimit)
        {
            this.transform.position = new Vector3(this.transform.position.x, lowLimit, this.transform.position.z);
            //Debug.Log("low limit reached");
            //cartShouldMove = true;
            //cartSpeed = originalSpeed;
            //pullySound.pitch = Random.Range(0.8f, 1.4f);
            //pullySound.Play();
        }

       /* if(cartShouldMove == true)
        {
            MoveCart();
            if (timerActive == false)
            {
                TimerController.instance.BeginTimer();
                timerActive = true;
            }
        }*/
    }

    /*void MoveCart()
    {
        if (cartShouldMove == true)
        {

            cart.transform.position += new Vector3(cart.transform.position.x, cart.transform.position.y, cartSpeed);
            cartSpeed -= 0.0003f;
            if (cartSpeed >= 0)
            {
                //cartSpeed = 0;
                cartShouldMove = false;
            }

            if (cartSpeed <= maxSpeed)
            {
                cartSpeed = maxSpeed;
            }
        }
        
        //Debug.Log(cartSpeed);
    } */

  
}
