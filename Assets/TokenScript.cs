using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameHandler GH;
    public AudioClip CoinSound;
    void Start()
    {
        GH = GameObject.Find("coin").GetComponent<GameHandler>();
        
    }
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(CoinSound, transform.position);
        GH.Coins++;
    }
}
