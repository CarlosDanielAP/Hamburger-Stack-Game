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
    // Start is called before the first frame update
    void Start()
    {
        InicialGame();
        moveCamera = false;
       
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
     
        if (currentGameState == GameState.startGame && Input.GetMouseButtonDown(0))
        {
            CreateNewCube();
        }
        if(currentGameState == GameState.inicialGame && Input.GetMouseButtonDown(0))
        {
            CreateNewCube();
           
        }



    }
    public void StartGame()
    {
        SetGameState(GameState.startGame);
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
                newPiece.transform.position = new Vector3(limitLeft, lastPiece.transform.position.y + spacingPiecesFactor, lastPiece.transform.position.z);

            }
            else
            {
                newPiece.transform.position = new Vector3(limitLeft, tower[0].transform.position.y+ 5, lastPiece.transform.position.z);
            }
            lastPiece.GetComponent<pieceScript>().newPiece = true;
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
