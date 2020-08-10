using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Panda: MonoBehaviour
{

    public float speed; 
    public Text scoreText;

    public GameObject pointsPopupPrefab;

    public int maxHealth = 100;
    private int currentHealth;

    public HealthBar healthBar;


    private int score;

    public int time = 0;
    public Text WarningTxt;

    public float gravity = 8;
    // private float rotSpeed = 80;
    // private float rot = 0f;

    Vector3 moveDir = Vector3.zero; 

    CharacterController controller;
    Animator anim;



    // Start is called before the first frame update
    void Start()
    {
      score = 0;
      currentHealth = 100;
      speed *= 1.5f;

      currentHealth = maxHealth;
      healthBar.SetMaxHealth(maxHealth);

      WarningTxt.text = "";

      SetScoreText (); 

      controller = GetComponent<CharacterController> ();  
      anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
    	transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 15f,0f,0f);
    	transform.Translate(0f,0f, Input.GetAxis("Vertical") * Time.deltaTime *15f);

      if (controller.isGrounded)
      {
         if (Input.GetKey (KeyCode.UpArrow))
         {
           anim.SetInteger("condition", 1);
           moveDir = new Vector3 (0, 0, 1);
           moveDir *= speed;
           // moveDir = transform.TransformDirection(moveDir);

         }

         if(Input.GetKeyUp (KeyCode.UpArrow))
         {
          anim.SetInteger("condition", 0);
          moveDir = new Vector3 (0, 0, 0);
         }
       }
       // rot += Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime;
       // transform.eulerAngles = new Vector3 (0, rot, 0);

       moveDir.y -= gravity *Time.deltaTime;
       controller.Move(moveDir * Time.deltaTime);
      
  

      if (currentHealth >= maxHealth)
      {
        currentHealth = maxHealth;
      }

      if (currentHealth <= 0)
        {
          FindObjectOfType<GameManager>().EndGame();
        }


        
    }
   

     void FixedUpdate () {
      
      if(!Input.anyKey) 

      {

        time = time + 1;
                     
        }

         else {
         
            time = 0;
            
           }

         

           
          if(time >= 400) 

          {

          Debug.Log("400 frames passed with no input");
          WarningTxt.text = "Warning. You must move your player or lose the game.";

          }

          else {
             
            WarningTxt.text = "";
          
          }
          if(time >= 800) 

          {

          Debug.Log("800 frames passed with no input");
          FindObjectOfType<GameManager>().EndGame();
        
          }

          
      
      }

    private void OnCollisionEnter(Collision collision)

    {
 		Pickup pickup = collision.gameObject.GetComponent<Pickup>();

         if (pickup == null)

            {
                Debug.Log(collision.gameObject.name + " is MISSING Pickup script!");
                return;
            }
        if (collision.gameObject.tag == "CollectPoints")
        {       
          
            score += pickup.pointValue;

            GameObject pointsPopup = Instantiate(pointsPopupPrefab, pickup.transform.position, pickup.transform.rotation);

            Text pointsPopupTxt = pointsPopup.GetComponentInChildren<Text>();

            pointsPopupTxt.text = pickup.pointValue.ToString();


            FindObjectOfType<AudioManager>().Play("Coin");

            SetScoreText();

            //Debug.Log("Destroy");
            //Destroy(collision.gameObject);
            pickup.Remove();
        }

        if (collision.gameObject.tag == "Rock")
        {

            // Pickup pickup = collision.gameObject.GetComponent<Pickup>();

            // if (pickup == null)
            // {
            //     Debug.Log(collision.gameObject.name + " is MISSING Pickup script!");
            //     return;
            // }

            FindObjectOfType<AudioManager>().Play("Hit");

            TakeDamage(25);
            pickup.Remove();
        }
        
    }



   private void SetScoreText()
  {
        Debug.Log("SetScoreText");
        // Update the text field of our 'countText' variable
        scoreText.text = "Score: " + score.ToString ();
  }

  private void TakeDamage(int damage)
  {
    currentHealth -= damage;
    healthBar.SetHealth(currentHealth);
  }

  // private void GameOver()
  // {
  // 	currentHealth = 0;
  // }

    
}
