using UnityEngine;

public class Shopowner : INPC
{
    public string DisplayName => "Shopowner";
    public string Dialogue => "I buy and sell everyday supplies.";

    public void Speak() => Debug.Log(DisplayName + ": " + Dialogue);
}
