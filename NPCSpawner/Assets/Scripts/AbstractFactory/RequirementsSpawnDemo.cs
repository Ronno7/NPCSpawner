using UnityEngine;

public class RequirementsSpawnDemo : MonoBehaviour
{
    public GameObject characterPrefab;
    public INPC CurrentCharacter { get; private set; }
    public SpawnRequirements LastRequirements { get; private set; }
    private int timeChoice, safetyChoice;
    private GameObject figure;
    private GUIStyle title, text, centered, control;
    private static readonly string[] Times = { "Day", "Night" };
    private static readonly string[] Safety = { "Peaceful", "Threatened" };

    public void Spawn(TimeOfDay time, VillageSafety safety)
    {
        LastRequirements = new SpawnRequirements(time, safety);
        AbstractCharacterFactory factory = new CharacterFactory(LastRequirements);
        CurrentCharacter = factory.Create();
        CurrentCharacter.Speak();

        if (figure != null)
        {
            figure.SetActive(false);
            Destroy(figure);
        }
        figure = Instantiate(characterPrefab, new Vector3(2.5f, 1, 0), Quaternion.identity, transform);
        figure.name = CurrentCharacter.DisplayName;
        var tint = new MaterialPropertyBlock();
        tint.SetColor("_BaseColor", safety == VillageSafety.Peaceful
            ? new Color(.56f, .67f, .51f) : new Color(.69f, .51f, .44f));
        figure.GetComponent<Renderer>().SetPropertyBlock(tint);
    }

    private void OnGUI()
    {
        if (title == null)
        {
            title = new GUIStyle(GUI.skin.label) { fontSize = 28, fontStyle = FontStyle.Bold };
            text = new GUIStyle(GUI.skin.label) { fontSize = 17, wordWrap = true };
            centered = new GUIStyle(text) { alignment = TextAnchor.UpperCenter };
            control = new GUIStyle(GUI.skin.button) { fontSize = 18 };
        }
        float scale = Mathf.Min(Screen.width / 1000f, Screen.height / 600f);
        var previous = GUI.matrix;
        GUI.matrix = Matrix4x4.TRS(new Vector3((Screen.width - 1000 * scale) / 2,
            (Screen.height - 600 * scale) / 2, 0), Quaternion.identity, Vector3.one * scale);
        GUI.Label(new Rect(45, 30, 900, 45), "Requirements based NPC Spawner", title);
        GUI.Label(new Rect(45, 82, 900, 35), "Choose conditions then spawn the corresponding character.", text);
        GUI.Label(new Rect(45, 170, 330, 30), "Time of day", text);
        timeChoice = GUI.Toolbar(new Rect(45, 210, 330, 44), timeChoice, Times, control);
        GUI.Label(new Rect(45, 285, 330, 30), "Village safety", text);
        safetyChoice = GUI.Toolbar(new Rect(45, 325, 330, 44), safetyChoice, Safety, control);
        if (GUI.Button(new Rect(45, 420, 330, 48), "Spawn", control))
            Spawn((TimeOfDay)timeChoice, (VillageSafety)safetyChoice);
        if (CurrentCharacter == null)
            GUI.Label(new Rect(530, 330, 380, 60), "Character Spawns Here", centered);
        else
        {
            GUI.Label(new Rect(530, 360, 380, 36), CurrentCharacter.DisplayName, centered);
            GUI.Label(new Rect(530, 402, 380, 70), CurrentCharacter.Dialogue, centered);
            string group = LastRequirements.Safety == VillageSafety.Peaceful ? "Friendly" : "Hostile";
            GUI.Label(new Rect(530, 490, 380, 65), group + " / " + LastRequirements.Time + " / " + LastRequirements.Safety, centered);
        }
        GUI.Label(new Rect(45, 535, 400, 45), "New choices take effect when you press Spawn.", text);
        GUI.matrix = previous;
    }
}
