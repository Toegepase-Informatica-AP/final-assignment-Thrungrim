using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Player player;
    public HammerPlayer opponent;
    private TextMeshPro scoreBoard;
    public PuckGame puckPrefab;
    public GameObject position;
    private int goalAmountPlayer = 0;
    private int goalAmountOpponent = 0;

    public void OnEnable()
    {
        scoreBoard = transform.GetComponentInChildren<TextMeshPro>();
    }

    public void FixedUpdate()
    {
        scoreBoard.text = goalAmountPlayer.ToString() + " - " + goalAmountOpponent.ToString();
    }

    public void ResetGame(bool playerScored)
    {
        if (goalAmountPlayer >= 5 || goalAmountOpponent >= 5)
        {
            Application.Quit();
        }
        else
        {
            foreach (Transform _object in position.transform)
            {
                Destroy(_object.gameObject);
            }
            SpawnPuck(playerScored);
        }
    }

    public void SpawnPuck(bool playerScored)
    {
        if (!playerScored)
        {
            GameObject newPuck = Instantiate(puckPrefab.gameObject);
            newPuck.transform.SetParent(position.transform);
            newPuck.transform.localPosition = new Vector3(-5f, 0f);
            opponent.transform.localPosition = new Vector3(9f, -0.64f, 0);
        }
        else
        {
            GameObject newPuck = Instantiate(puckPrefab.gameObject);
            newPuck.transform.SetParent(position.transform);
            newPuck.transform.localPosition = new Vector3(5f, 0f);
            opponent.transform.localPosition = new Vector3(9f, -0.64f, 0);
        }
    }

    public void AddPointsPlayer()
    {
        goalAmountPlayer++;
    }

    public void AddPointsOpponent()
    {
        goalAmountOpponent++;
    }
}
