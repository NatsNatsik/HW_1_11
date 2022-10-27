using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsGood = true;
    public Material GoodMaterial;
    public Material BadMaterial;
    Rigidbody Rigidbody;
    private bool isFirstTouch = true;

    public AudioSource breakAudio;


    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        Renderer sectorRenderer = GetComponent<Renderer>();
        sectorRenderer.sharedMaterial = IsGood ? GoodMaterial : BadMaterial;
    }
       
    void FallPlatform()
    {
        Rigidbody.isKinematic = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;
        Vector3 normal = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.up);
        if (dot < 0) return;

        if (IsGood)
        {
            player.Bounce();

            var meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;
            var ownColider = GetComponent<Collider>();
            ownColider.enabled = false;
            breakAudio.PlayDelayed(0.25f);

            Invoke("FallPlatform", 1f);
            Destroy(gameObject, 2);

            Game.Score++;
        }
        else
        {
            player.Die();
        }

    }      
    private void OnValidate()
    {
        UpdateMaterial();
    }
}
