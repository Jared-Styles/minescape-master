using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpMovement : MonoBehaviour
{
    public float highLimit;
    public float lowLimit;
    public GameObject pump;
    public GameObject cart;
    public GameObject fireworksParticle;
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
    private bool musicSlowDown = false;
   

    public Animator groundAnim;
    public float maxSpeed;

    public AudioClip pullyUp;
    public AudioClip pullyDown;
    public AudioSource music;
    //public AudioSource cartMoveSound;
    public AudioSource pullySound;
    public AudioSource cartSound;

    public Renderer rendLeft;
    public Renderer rendRight;

    public float animSpeed;
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
        animSpeed = 0;
        groundAnim.speed = animSpeed;
        fireworksParticle.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        groundAnim.speed = animSpeed;
        if (this.transform.rotation == Quaternion.Euler(highLimit, 0, 0) && hightLimitReached == false)
        {
            pullySound.PlayOneShot(pullyUp);
            //pump.transform.rotation = Quaternion.Euler(13, 0, 0);
            cartShouldMove = true;
            Debug.Log("cart should move High");
            hightLimitReached = true;
            lowLimitReached = false;
            //groundAnim.speed += 0.08f;
            animSpeed += 0.08f;
            pumpActive = true;
            
            

        }

        else if (this.transform.rotation == Quaternion.Euler(lowLimit, 0, 0) && lowLimitReached == false)
        {
            pullySound.PlayOneShot(pullyDown);
            //pump.transform.rotation = Quaternion.Euler(-13, 0, 0);
            cartShouldMove = true;
            Debug.Log("cart should move LOW");
            hightLimitReached = false;
            lowLimitReached = true;
            //groundAnim.speed += 0.08f;
            animSpeed += 0.08f;
            pumpActive = true;
            
            

        }
       

        if (cartShouldMove == true)
        {
            //MoveCart();
            //groundAnim.SetTrigger("move");
            
            if (animSpeed > maxSpeed)

            {
                animSpeed = maxSpeed;
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

            //groundAnim.speed -= groundAnim.speed * 0.001f;
            animSpeed -= groundAnim.speed * 0.002f;
           
            if (moveSoundPlaying == false)
            {
                music.Play();
                //music.volume += 0.1f;
                cartSound.Play();

                moveSoundPlaying = true;
            }

           
            
            if(musicSlowDown == true)
            {
                music.volume -= 0.001f;
            }
            //cartMoveSound.pitch = groundAnim.speed + soundSpeed;

            //StartCoroutine(SlowDown());
            //pumpActive = false;
            
        }
       
        if (animSpeed < 0)
        {
            animSpeed = 0;
        }
  
    }

    

    IEnumerator SlowDown()
    {
        
            yield return new WaitForSeconds(4);
            groundAnim.speed -=  0.001f;
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
            fireworksParticle.SetActive(true);
            musicSlowDown = true;
            //music.volume -= 0.1f;
            RenderSettings.fog = false;
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
