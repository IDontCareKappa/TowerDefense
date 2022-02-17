using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int Money;
    public static int Lives;

    public int startMoney = 300;
    public int startLives = 5;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }

}
