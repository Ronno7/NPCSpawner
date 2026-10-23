using UnityEngine;

public class Beggar : INPC
{
    public string DisplayName => "Beggar";
    public string Dialogue => "I ask for food and spare coins.";

    public void Speak() => Debug.Log(DisplayName + ": " + Dialogue);
}
