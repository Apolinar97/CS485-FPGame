using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public AudioSource pickUpSound;

    private void Start()
    {
        pickUpSound = GetComponent<AudioSource>();
    }
    private void Update()
    {
        transform.Rotate(new Vector3(5, 0, 0));
        
        
    }

}
