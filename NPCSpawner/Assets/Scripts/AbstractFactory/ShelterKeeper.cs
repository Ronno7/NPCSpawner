using UnityEngine;

public sealed class ShelterKeeper : INPC
{
    public string DisplayName => "Shelter Keeper";
    public string Dialogue => "I keep the shelter lit through the night.";
    public void Speak() => Debug.Log(DisplayName + ": " + Dialogue);
}
