using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpMovement : MonoBehaviour
{
    public float highLimit;
    public float lowLimit;
    public GameObject pump;
    public GameObject cart;
    public float cartSpeed;
    public float currentSpeed;
    //public GameObject pullyLocation;
    public float maxSpeed;
    //private float originalSpeed;
    private bool cartShouldMove;
    private bool timerActive;
    private bool hightLimitReached;
    private bool lowLimitReached;

    public Animator groundAnim;
    void Start()
    {
        cartShouldMove = false;
        //originalSpeed = cartSpeed;
        timerActive = false;
        hightLimitReached = false;
        lowLimitReached = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (this.transform.rotation == Quaternion.Euler(highLimit, 0, 0) && hightLimitReached == false)
        {
            //pump.transform.rotation = Quaternion.Euler(13, 0, 0);
            cartShouldMove = true;
            Debug.Log("cart should move High");
            hightLimitReached = true;
            lowLimitReached = false;
            
        }
       
        else if (this.transform.rotation == Quaternion.Euler(lowLimit, 0, 0) && lowLimitReached == false)
        {
            //pump.transform.rotation = Quaternion.Euler(-13, 0, 0);
            cartShouldMove = true;
            Debug.Log("cart should move LOW");
            hightLimitReached = false;
            lowLimitReached = true;
        }
        else
        {
            //cartShouldMove = false;
        }

        if (cartShouldMove == true)
        {
            MoveCart();
            //groundAnim.SetTrigger("move");
            //groundAnim.speed = 0.1f;
            if (timerActive == false)
            {
                TimerController.instance.BeginTimer();
                timerActive = true;

            }
        }
    }

    void MoveCart()
    {
        if (cartShouldMove == true)
        {

            cart.transform.position += new Vector3(cart.transform.position.x, cart.transform.position.y, cartSpeed);
            cartSpeed -= 0.00015f;
            currentSpeed = cartSpeed;
            if (cartSpeed >= 0)
            {
                cartSpeed = 0;
                cartShouldMove = false;
            }

            if (cartSpeed <= maxSpeed)
            {
               cartSpeed = maxSpeed;
            }
        }
        if(cartShouldMove == false)
        {
           
            cart.transform.position += new Vector3(cart.transform.position.x, cart.transform.position.y, currentSpeed);
            
        }

        //Debug.Log(cartSpeed);
    }
}
