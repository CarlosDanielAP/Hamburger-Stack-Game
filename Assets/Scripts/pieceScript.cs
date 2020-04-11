using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceScript : MonoBehaviour
{

    float speed;
    bool goingRight;
    bool stopMoving;
    public bool newPiece;
    Rigidbody rb;

    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        newPiece = false;
        goingRight = true;
        stopMoving = false;
        //si la torre tiene mas de una pieza le ponemos su velocidad
        if (GameManager.sharedInstance.tower.Count > 1)
            speed = GameManager.sharedInstance.speed;
        else
            speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (newPiece == true) 
        {
            stopMoving = true;
            rb.useGravity = true;
            if (!GameManager.sharedInstance.tapaOnGame)
            {
                if (GameManager.sharedInstance.tower.Count >= 10)
                {

                    GameManager.sharedInstance.StartGame();
                }
                else GameManager.sharedInstance.InicialGame();
            }

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
            Debug.Log("chocado");
            GameManager.sharedInstance.blockColl = true;
            this.enabled = false;
            
        }
    }
}
