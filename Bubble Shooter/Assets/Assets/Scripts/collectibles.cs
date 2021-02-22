using UnityEngine;

public class collectibles : Singleton<collectibles>
{
    [SerializeField] GameObject coinNumPrefab;
    [SerializeField] GameObject CoinManager;

    public void Gold_Coin(Transform transform)
    {
        Coin_Manager.Instance.AddCoins(transform.position, 3);
        if (coinNumPrefab != null) { Destroy(Instantiate(coinNumPrefab, transform.position, Quaternion.identity), 1f); }
    }

}
