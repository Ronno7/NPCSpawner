using System.Collections.Generic;
using UnityEngine;

public class RequirementsSpawnDemo : MonoBehaviour
{
    public const int Capacity = 6;
    public GameObject characterPrefab;
    public INPC CurrentCharacter { get; private set; }
    public SpawnRequirements LastRequirements { get; private set; }
    public int Count => figures.Count;
    private int timeChoice, safetyChoice, weatherChoice;
    private readonly List<GameObject> figures = new List<GameObject>();
    private readonly List<INPC> characters = new List<INPC>();
    private GUIStyle title, text, centered, control;
    private AudioSource audioSource;
    private AudioClip spawnSound;
    private static readonly string[] Times = { "Day", "Night" };
    private static readonly string[] Safety = { "Peaceful", "Threatened" };
    private static readonly string[] WeatherChoices = { "Clear", "Storm" };

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0;
        spawnSound = SpawnPresentation.CreateSpawnSound();
        SpawnPresentation.Part(transform, characterPrefab.GetComponent<Renderer>().sharedMaterial,
            PrimitiveType.Cube, "Ground platform", new Vector3(0, -.22f, 0),
            new Vector3(12, .22f, 1.5f), new Color(.30f, .34f, .35f));
    }

    public void Spawn(TimeOfDay time, VillageSafety safety, Weather weather = Weather.Clear)
    {
        if (Count >= Capacity) return;
        var requirements = new SpawnRequirements(time, safety, weather);
        AbstractCharacterFactory factory = new CharacterFactory(requirements);
        INPC character = factory.Create();
        var figure = Instantiate(characterPrefab, new Vector3(-5 + Count * 2, .6f, 0), Quaternion.identity, transform);
        figure.name = character.DisplayName;
        figure.transform.localScale = Vector3.one * .65f;
        SpawnPresentation.Tint(figure, SpawnPresentation.GroupColor(requirements));
        SpawnPresentation.AddProp(figure, character);
        figures.Add(figure);
        characters.Add(character);
        LastRequirements = requirements;
        CurrentCharacter = character;
        character.Speak();
        audioSource.PlayOneShot(spawnSound);
    }

    public void Clear()
    {
        foreach (var figure in figures)
        {
            figure.SetActive(false);
            Destroy(figure);
        }
        figures.Clear();
        characters.Clear();
        CurrentCharacter = null;
        LastRequirements = null;
        audioSource.Stop();
    }

    private void OnDestroy()
    {
        if (spawnSound != null) Destroy(spawnSound);
    }

    private void OnGUI()
    {
        if (title == null)
        {
            title = new GUIStyle(GUI.skin.label) { fontSize = 28, fontStyle = FontStyle.Bold };
            text = new GUIStyle(GUI.skin.label) { fontSize = 16, wordWrap = true };
            centered = new GUIStyle(text) { alignment = TextAnchor.UpperCenter };
            control = new GUIStyle(GUI.skin.button) { fontSize = 18 };
        }
        float scale = Mathf.Min(Screen.width / 1100f, Screen.height / 650f);
        Vector2 offset = new Vector2((Screen.width - 1100 * scale) / 2, (Screen.height - 650 * scale) / 2);
        var previous = GUI.matrix;
        GUI.matrix = Matrix4x4.TRS(offset, Quaternion.identity, Vector3.one * scale);
        GUI.Label(new Rect(40, 25, 1000, 45), "Spawn Systems ++", title);
        GUI.Label(new Rect(40, 75, 1000, 30), "Choose conditions and build a group of up to six characters.", text);
        GUI.Label(new Rect(40, 120, 310, 25), "Time of day", text);
        timeChoice = GUI.Toolbar(new Rect(40, 150, 310, 42), timeChoice, Times, control);
        GUI.Label(new Rect(395, 120, 310, 25), "Village safety", text);
        safetyChoice = GUI.Toolbar(new Rect(395, 150, 310, 42), safetyChoice, Safety, control);
        GUI.Label(new Rect(750, 120, 310, 25), "Weather", text);
        weatherChoice = GUI.Toolbar(new Rect(750, 150, 310, 42), weatherChoice, WeatherChoices, control);
        for (int i = 0; i < Count; i++)
        {
            var screen = Camera.main.WorldToScreenPoint(figures[i].transform.position + Vector3.down * .85f);
            float x = (screen.x - offset.x) / scale;
            float y = (Screen.height - screen.y - offset.y) / scale;
            GUI.Label(new Rect(x - 80, y + 12, 160, 50), characters[i].DisplayName, centered);
        }
        if (CurrentCharacter == null)
            GUI.Label(new Rect(200, 455, 700, 55), "The platform is ready. Choose conditions and press Spawn.", centered);
        else
            GUI.Label(new Rect(150, 455, 800, 55), CurrentCharacter.DisplayName + ": " + CurrentCharacter.Dialogue, centered);
        GUI.enabled = Count < Capacity;
        if (GUI.Button(new Rect(300, 530, 230, 45), "Spawn  (" + Count + " / " + Capacity + ")", control))
            Spawn((TimeOfDay)timeChoice, (VillageSafety)safetyChoice, (Weather)weatherChoice);
        GUI.enabled = Count > 0;
        if (GUI.Button(new Rect(570, 530, 230, 45), "Clear", control)) Clear();
        GUI.enabled = true;
        GUI.Label(new Rect(150, 595, 800, 35), Count == Capacity
            ? "Platform full. Clear the group to spawn again."
            : "Storms prioritise rescue. Existing characters keep their roles.", centered);
        GUI.matrix = previous;
    }
}
