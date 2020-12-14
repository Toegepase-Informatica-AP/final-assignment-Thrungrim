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

    public void OnEnable()
    {
        scoreBoard = transform.GetComponentInChildren<TextMeshPro>();
    }

    public void ClearEnvironment(bool playerScored)
    {
        if (player.goalAmount > 5)
        {
            player.EndEpisode();
            opponent.EndEpisode();
        }
        else if (opponent.goalAmount > 5)
        {
            opponent.EndEpisode();
            player.EndEpisode();
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
            player.transform.position = new Vector3(-5.5f, -0.64f, 0);
            opponent.transform.position = new Vector3(9f, -0.64f, 0);
        }
        else
        {
            GameObject newPuck = Instantiate(puckPrefab.gameObject);
            newPuck.transform.SetParent(position.transform);
            newPuck.transform.localPosition = new Vector3(5f, 0f);
            player.transform.position = new Vector3(-5.5f, -0.64f, 0);
            opponent.transform.position = new Vector3(9f, -0.64f, 0);
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

    public void FixedUpdate()
    {
        scoreBoard.text = player.GetCumulativeReward().ToString("f2") + " | " + opponent.GetCumulativeReward().ToString("f2");
    }
}
