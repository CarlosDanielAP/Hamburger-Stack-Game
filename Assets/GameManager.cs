using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    newCube,
    startGame
}

public class GameManager : MonoBehaviour
{
    public float limitLeft, limitRight;
    public float speed = 3.0f;
    public float spacingPiecesFactor= 0.5f;
    public GameState currentGameState = GameState.startGame;
    public static GameManager sharedInstance;
    public List<pieceScript> myPieces= new List<pieceScript>();
    public List<pieceScript> tower= new List<pieceScript>();
    // Start is called before the first frame update
    void Start()
    {
        
        //piece= Instantiate<cube>
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

        

    }

    public void CreateNewCube (){
        Debug.Log("neeeew");
        SetGameState(GameState.newCube);
}

    private void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.newCube)
        {
            pieceScript newPiece;
            newPiece = Instantiate(myPieces[0]);
            pieceScript lastPiece = tower[tower.Count-1];
            lastPiece.GetComponent<pieceScript>().newPiece = true;
            newPiece.transform.position = new Vector3(limitLeft, lastPiece.transform.position.y + spacingPiecesFactor, lastPiece.transform.position.z);
            tower.Add(newPiece);

            //TODO colocar la logica del menu
        }
        this.currentGameState = newGameState;
    }
    }
