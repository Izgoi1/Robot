using UnityEngine;
using UnityEngine.UI;

public class Itemcolector : MonoBehaviour
{
    private int gears = 0;

    [SerializeField] private Text gearsText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gears"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            gears++;
            gearsText.text = "Gears: " + gears;
        }
    } 
}
