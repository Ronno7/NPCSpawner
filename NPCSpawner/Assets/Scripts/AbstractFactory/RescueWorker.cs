using UnityEngine;

public sealed class RescueWorker : INPC
{
    public string DisplayName => "Rescue Worker";
    public string Dialogue => "I guide villagers out of the storm.";
    public void Speak() => Debug.Log(DisplayName + ": " + Dialogue);
}
