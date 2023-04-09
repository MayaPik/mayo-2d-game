using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starspawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Star;
    [SerializeField]
    private GameObject Coin; 

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            int numCoins = Random.Range(2, 4);
            float coinX = Random.Range(-10f, 90f);
            float coinY = Random.Range(0f, 4f);
            float starX = Random.Range(-10f, 90f);
            float starY = Random.Range(0f, 4f);

                GameObject newStar = Instantiate(Star);
                newStar.transform.position = new Vector3(starX, starY, 0f);

            for (int j = 1; j < numCoins; j++)
            {
                GameObject newCoin = Instantiate(Coin);
                newCoin.transform.position = new Vector3(coinX + j, coinY - j, 0f);
            }
        }
    }
}
