using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Stats playerStats;

    [SerializeField] internal PlayerMovement playerMovement;
    [SerializeField] internal GameHandle gameHandle;
    [SerializeField] internal PlayerTrigger playerTrigger;

    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rigidBody2D;


    [SerializeField] internal float score { get; set; }
    [SerializeField] internal float bestScore { get; set; }

    internal string playerTag { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        bestScore = 0;
        score = 0;
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        LocatePlayer();
        playerTag = gameObject.tag;
    }

    public void LocatePlayer()
    {
        gameObject.transform.position = new Vector3(0, -3, 0);
    }

    void LocatePlayer(Vector3 vector3)
    {
        gameObject.transform.position = vector3;
    }

    public void SendStatsToSaveFile()
    {
        playerStats.bestScore = score;
    }
    public void TakeStatsFromSaveFile()
    {
        bestScore = playerStats.bestScore;
    }
    

}
