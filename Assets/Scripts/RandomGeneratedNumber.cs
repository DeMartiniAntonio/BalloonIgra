using UnityEngine;

public static class RandomGeneratedNumber
{
    public static int RandomNumber(int length)
    {
        return Random.Range(0, length);
    }
}
