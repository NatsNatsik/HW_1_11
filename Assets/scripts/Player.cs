using UnityEngine;
using Assets.scripts;
using System;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public Game Game;

    public AudioSource bounceAudio;

    public Platform CurrentPlatform;

    public float disappearFactor = 0.0f;

    private Material material;
    private bool die = false;

    public void ReachFinish()
    {
       Rigidbody.velocity = Vector3.zero;
       Game.OnPlayerReachedFinish();
    }

    public void Bounce()
    {
        bounceAudio.Play();
        Rigidbody.velocity = new Vector3(0, BounceSpeed, 0);
    }

    public void Die()
    {
        Rigidbody.velocity = Vector3.zero;
        die = true;
        GetComponent<ParticleSystem>().Play();
        Game.OnPlayerDied();
    }


    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        bool t = material.HasFloat("_Dissolve_amount");
        disappearFactor = 0;
        disappearFactor = material.GetFloat("_Dissolve_amount");
        die = false;
    }
    private void Update()
    {
        if (die && disappearFactor < 1)
        {
            disappearFactor += Time.deltaTime * 0.7f;
            material.SetFloat("_Dissolve_amount", disappearFactor);
        }
    }
}
