using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameHandler GH;
    public AudioClip CoinSound;
    void Start()
    {
        if (GH == null)
        {
            Debug.LogError("GameHandler reference not set in the Inspector");
        }

    }
    //private void Update()
    //{
        
    //}

    private void OnTriggerEnter(Collider other)
    {
        
        
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(CoinSound, transform.position);
        GH.Coins++;
    }
}
