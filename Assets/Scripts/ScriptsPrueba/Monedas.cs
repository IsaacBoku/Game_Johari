using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Monedas : MonoBehaviour
{
    public int coinCount;
    public TextMeshProUGUI contador;

    // Start is called before the first frame update
    void Start()
    {
        coinCount = 0;

        contador.text = "Will o' Wisps: " + coinCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Coin")
        {
            coinCount++;
            contador.text = "Will o' Wisps: " + coinCount.ToString();
            Destroy(other.gameObject);
        }
    }

}
