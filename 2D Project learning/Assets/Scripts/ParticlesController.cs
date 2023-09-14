using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    [SerializeField] private ParticleSystem dieParticle;
    [SerializeField] private Rigidbody2D rb;

    private ParticleSystem _system;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void PlayDieParticle(Vector2 pos)
    {
        dieParticle.transform.position = pos;
        dieParticle.Play();
    }

}
