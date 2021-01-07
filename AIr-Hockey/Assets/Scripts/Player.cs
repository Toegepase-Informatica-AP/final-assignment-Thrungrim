using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Game game;
    private Rigidbody rb = null;
    public bool matchWon = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        game = GetComponentInParent<Game>();
        matchWon = false;
        game.ResetGame(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
