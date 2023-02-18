using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    void Start()
    {
        StartCoroutine(CreateCoin());
    }

    private IEnumerator CreateCoin()
    {
        float delay = 60;
        var createDelay = new WaitForSeconds(delay);

        while (true)
        {
            Instantiate(_coin, transform.position, Quaternion.identity);

            yield return createDelay;
        }
    }
}
