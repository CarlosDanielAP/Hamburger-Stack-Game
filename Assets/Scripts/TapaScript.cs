using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapaScript : MonoBehaviour
{

    float speed;
    bool goingRight;
    bool stopMoving;
    
    Rigidbody rb;

    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        stopMoving = false;
        speed = GameManager.sharedInstance.speed;

    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.sharedInstance.sueltaTapa)
        {
            GameManager.sharedInstance.sueltaTapa = false;
            stopMoving = true;
            rb.useGravity = true; ;
        }


      

        if (!stopMoving)
        {
            if (transform.position.x > GameManager.sharedInstance.limitRight)
            {
                goingRight = false;
            }
            if (transform.position.x < GameManager.sharedInstance.limitLeft)
            {
                goingRight = true;
            }

            if (goingRight)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(GameManager.sharedInstance.limitRight + 1, transform.position.y, transform.position.z), Time.deltaTime * speed);

            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(GameManager.sharedInstance.limitLeft - 1, transform.position.y, transform.position.z), Time.deltaTime * speed);

            }
        }
         
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject == GameManager.sharedInstance.tower[GameManager.sharedInstance.tower.Count-2].gameObject)
        {
            Debug.Log("next Level");
           // GameManager.sharedInstance.tower[GameManager.sharedInstance.tower.Count - 2].GetComponent<pieceScript>().enabled = false;
            //this.enabled = false;
            GameManager.sharedInstance.NextLevel();
           
            
        }
    }
}
