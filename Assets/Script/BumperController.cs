using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;
    public float score;

    private Renderer render;
    private Animator animator;

    public AudioManager audioManager;
    public VFXManager vfxManager;
    public ScoreManager scoreManager;

    private void Start()
    {
        render = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

       render.material.color = color;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity = bolaRig.velocity * multiplier;

            //Animasi
            animator.SetTrigger("Hit");

            //playSFX
            audioManager.PlaySFX(collision.transform.position);

            //playVFX
            vfxManager.PlayVFX(collision.transform.position);

            //AddScore
            scoreManager.AddScore(score);
        }
    }
}
