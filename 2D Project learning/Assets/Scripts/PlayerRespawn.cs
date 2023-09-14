using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerRespawn : MonoBehaviour
{
    private Rigidbody2D rb;
    private float deathZone = -30f;
    private Vector3 respawnPoint;
    private SpriteRenderer spriteRenderer;
    private int hp = 3;
    public GameObject gameOverScreen;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private Text hpText;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        if (rb.transform.position.y < deathZone)
        {
            Die();
        }
        hpText.text = "HP: " + hp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CheckPoint")
        {
            respawnPoint = transform.position;
        }
    }

    private void Die()
    {
        if (hp > 1)
        {
            rb.bodyType = RigidbodyType2D.Static;
            deathSoundEffect.Play();
            StartCoroutine(Respawn(0.5f));
        }
        else
        {
            gameOverScreen.SetActive(true);
            
        }
    }

    IEnumerator Respawn(float duration)
    {
        hp--;
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        rb.transform.position = respawnPoint;
        rb.bodyType = RigidbodyType2D.Dynamic;
        spriteRenderer.enabled = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
