using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    menu,
    newCube,
    startGame,
    inicialGame,
}

public class GameManager : MonoBehaviour
{
    public float levelDistance = 0.1f;
    public bool gameOver;
    public float limitLeft, limitRight;
    public float speed = 3.0f;
    public float spacingPiecesFactor= 0.5f;
    //every time you stack this blocks it will move
    public int cameraMoveBlock;
    public GameState currentGameState = GameState.inicialGame;
    public static GameManager sharedInstance;
    public List<pieceScript> myPieces= new List<pieceScript>();
    public List<pieceScript> tower= new List<pieceScript>();
    public bool moveCamera;
    public bool blockColl;
    bool left;
    float startDistance;
    public GameObject deathZone;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        InicialGame();
        moveCamera = false;
        blockColl = true;
        
       
       
    }
    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
        //yo soy la instancia compartida y el unico que va a gobernar.
    }

    // Update is called once per frame
    void Update()
    {

        if (!gameOver)
        {
            if (blockColl)
            {

                if (currentGameState == GameState.startGame && Input.GetMouseButtonDown(0))
                {

                    CreateNewCube();

                    blockColl = false;

                }
                if (currentGameState == GameState.inicialGame && Input.GetMouseButtonDown(0))
                {


                    CreateNewCube();
                    blockColl = false;
                    Invoke("checkFirstCubes", 0.5f);



                }

            }
        }

       
       


    }
    public void StartGame()
    {
        SetGameState(GameState.startGame);
    }
    public void checkFirstCubes()
    {
        if (tower.Count > 2)
        {
            blockColl = false;
        }
        else
        {
            blockColl = true;

        }
    }

    public void CreateNewCube (){
        Debug.Log("neeeew");
        SetGameState(GameState.newCube);
        
    }
    public void InicialGame()
    {
        SetGameState(GameState.inicialGame);
    }

    private void SetGameState(GameState newGameState)
    {
        
        if (newGameState == GameState.newCube)
        {
            

            pieceScript newPiece;
            newPiece = Instantiate(myPieces[0]);
            pieceScript lastPiece = tower[tower.Count-1];
            
            if (moveCamera)
            {
                if (left)
                {
                    newPiece.transform.position = new Vector3(limitLeft, lastPiece.transform.position.y + spacingPiecesFactor, tower[0].transform.position.z);
                    left = false;
                }
                else
                {
                    newPiece.transform.position = new Vector3(limitRight, lastPiece.transform.position.y + spacingPiecesFactor, tower[0].transform.position.z);
                    left = true;
                }

            }
            else
            {
                startDistance += 0.5f;
                if (left)
                {
                    newPiece.transform.position = new Vector3(limitLeft, tower[0].transform.position.y + (levelDistance+startDistance), tower[0].transform.position.z);
                    left = false;
                }
                else
                {
                    newPiece.transform.position = new Vector3(limitRight, tower[0].transform.position.y + (levelDistance+startDistance), tower[0].transform.position.z);
                    left = true;
                }
            }
            lastPiece.GetComponent<pieceScript>().newPiece = true;
            deathZone.gameObject.transform.position = new Vector2(deathZone.gameObject.transform.position.x, deathZone.gameObject.transform.position.y +0.5f);
            tower.Add(newPiece);

            //TODO colocar la logica del menu
        }
        else if (newGameState == GameState.inicialGame)
        {
            
            moveCamera = false;
        }
        else if (newGameState == GameState.startGame)
        {
            moveCamera = true;
        }
        this.currentGameState = newGameState;
    }
    }
