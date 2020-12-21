using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public HammerPlayer player;
    public Hammer opponent;
    private TextMeshPro scoreBoard;
    public Puck puckPrefab;
    public GameObject position;
    public bool rightSide;

    public void OnEnable()
    {
        scoreBoard = transform.GetComponentInChildren<TextMeshPro>();
    }

    public void FixedUpdate()
    {
        foreach (Transform _object in position.transform)
        {
            if (_object.gameObject.transform.localPosition.x > 0)
            {
                rightSide = true;
            }
            else
            {
                rightSide = false;
            }
        }
        scoreBoard.text = player.GetCumulativeReward().ToString("f2") + " | " + opponent.GetCumulativeReward().ToString("f2");
    }

    public void ClearEnvironment(bool playerScored)
    {
        if (player.goalAmount > 5)
        {
            player.EndEpisodeHockey();
            opponent.EndEpisodeHockey();
        }
        else if (opponent.goalAmount > 5)
        {
            opponent.EndEpisodeHockey();
            player.EndEpisodeHockey();
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
            player.transform.localPosition = new Vector3(-5.5f, -0.64f, 0);
            opponent.transform.localPosition = new Vector3(9f, -0.64f, 0);
        }
        else
        {
            GameObject newPuck = Instantiate(puckPrefab.gameObject);
            newPuck.transform.SetParent(position.transform);
            newPuck.transform.localPosition = new Vector3(5f, 0f);
            player.transform.localPosition = new Vector3(-5.5f, -0.64f, 0);
            opponent.transform.localPosition = new Vector3(9f, -0.64f, 0);
        }
    }
    //-0.375184

    public void AddPointsPlayer()
    {
        player.AddReward(1f);
        opponent.AddReward(-1f);
        player.goalAmount++;
    }
    public void AddPointsOpponent()
    {
        opponent.AddReward(1f);
        player.AddReward(-1f);
        opponent.goalAmount++;
    }

}
