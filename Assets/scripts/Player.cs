using UnityEngine;
using Assets.scripts;
using System;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public Game Game;

    public Platform CurrentPlatform;

    public void ReachFinish()
    {
       Rigidbody.velocity = Vector3.zero;
       Game.OnPlayerReachedFinish();
    }

    public void Bounce()
    {
        Rigidbody.velocity = new Vector3(0, BounceSpeed, 0);
    }

    public void Die()
    {
        Rigidbody.velocity = Vector3.zero;
        Game.OnPlayerDied();
    }

    private void Update()
    {
    }
}
