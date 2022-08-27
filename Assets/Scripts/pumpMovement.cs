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
    public float soundSpeed;
    //public GameObject pullyLocation;
    
    //private float originalSpeed;
    private bool cartShouldMove;
    private bool timerActive;
    private bool hightLimitReached;
    private bool lowLimitReached;
    private bool pumpActive;
    private bool moveSoundPlaying = false;

    //public GameObject[] wayPoints;
    //private int index = 0;

    //public float speed;

    public Animator groundAnim;
    public float maxSpeed;

    public AudioClip pullyUp;
    public AudioClip pullyDown;
    //public AudioSource cartMoveSound;
    public AudioSource pullySound;

    public Renderer rendLeft;
    public Renderer rendRight;
    void Start()
    {
        cartShouldMove = false;
        
        timerActive = false;
        hightLimitReached = false;
        lowLimitReached = false;
        pumpActive = false;
        
        groundAnim.speed = 0;
        maxSpeed = 1;
        soundSpeed = -0.15f;

        pullySound = GetComponent<AudioSource>();
       
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
            groundAnim.speed += 0.08f;
            pumpActive = true;
            //StopAllCoroutines();
            //pullySound.pitch = Random.Range(0.7f, 1.2f);
            pullySound.PlayOneShot(pullyUp);

        }

        else if (this.transform.rotation == Quaternion.Euler(lowLimit, 0, 0) && lowLimitReached == false)
        {
            //pump.transform.rotation = Quaternion.Euler(-13, 0, 0);
            cartShouldMove = true;
            Debug.Log("cart should move LOW");
            hightLimitReached = false;
            lowLimitReached = true;
            groundAnim.speed += 0.08f;
            pumpActive = true;
            //StopAllCoroutines();
            //pullySound.pitch = Random.Range(0.8f, 1.4f);
            pullySound.PlayOneShot(pullyDown);

        }
        else
        {
            //cartShouldMove = false;
        }

        if (cartShouldMove == true)
        {
            //MoveCart();
            //groundAnim.SetTrigger("move");
            
            if (groundAnim.speed > maxSpeed)

            {
                groundAnim.speed = maxSpeed;
            }
            //groundAnim.speed = 0.1f;
            if (timerActive == false)
            {
                TimerController.instance.BeginTimer();
                timerActive = true;

            }
        }
        if (pumpActive == true)
        {
            

            if(moveSoundPlaying == false)
            {
                //cartMoveSound.Play();
                moveSoundPlaying = true;
            }
            
            //cartMoveSound.pitch = groundAnim.speed + soundSpeed;

            StartCoroutine(SlowDown());
            //pumpActive = false;
            
        }
        
        if(groundAnim.speed < 0)
        {
            groundAnim.speed = 0;
        }
  
    }

    

    IEnumerator SlowDown()
    {
        
            yield return new WaitForSeconds(4);
            groundAnim.speed -= groundAnim.speed * 0.001f;
            //pumpActive = false;
        
         if(pumpActive == true)
        {
            //groundAnim.speed += 0.08f;
        }
            
            //yield return null;
          
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FinishLine")
        {
            //cartMoveSound.Stop();
            TimerController.instance.EndTimer();
            rendLeft.enabled = false;
            rendRight.enabled = false;
            cartShouldMove = false;
        }

        if(other.gameObject.tag == "SpeedUpOne")
        {
            soundSpeed = 0.12f;
        }

        if (other.gameObject.tag == "SpeedUpTwo")
        {
            soundSpeed = 0.02f;
        }
    }
}
