using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public int money;

    public bool TryRemoveMoney(int moneyToRemove)
    {
        if (money >= moneyToRemove)//do we have enough money
        {
            money -= moneyToRemove;//remove money
            return true;//tell the transaction was successfull
        }
        else//don't have enough money
        {
            return false;//transaction NOT successfull
        }
    }
}