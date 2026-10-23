using UnityEngine;

public class Shopowner : INPC
{
    public string DisplayName => "Shopowner";
    public string Dialogue => "Do you wish to purchase something?";

    public void Speak() => Debug.Log(DisplayName + ": " + Dialogue);
}
