using UnityEngine;

// Small visual details are kept out of the factory and its products.
public static class SpawnPresentation
{
    public static Color GroupColor(SpawnRequirements requirements)
    {
        if (requirements.Weather == Weather.Storm) return new Color(.75f, .65f, .43f);
        return requirements.Safety == VillageSafety.Peaceful
            ? new Color(.56f, .67f, .51f) : new Color(.69f, .51f, .44f);
    }

    public static void Tint(GameObject target, Color color)
    {
        var tint = new MaterialPropertyBlock();
        tint.SetColor("_BaseColor", color);
        target.GetComponent<Renderer>().SetPropertyBlock(tint);
    }

    public static GameObject Part(Transform parent, Material material, PrimitiveType shape,
        string name, Vector3 position, Vector3 scale, Color color)
    {
        var part = GameObject.CreatePrimitive(shape);
        part.name = name;
        part.transform.SetParent(parent, false);
        part.transform.localPosition = position;
        part.transform.localScale = scale;
        part.GetComponent<Renderer>().sharedMaterial = material;
        Object.Destroy(part.GetComponent<Collider>());
        Tint(part, color);
        return part;
    }

    public static void AddProp(GameObject figure, INPC character)
    {
        var material = figure.GetComponent<Renderer>().sharedMaterial;
        var wood = new Color(.43f, .32f, .24f);
        var metal = new Color(.55f, .60f, .63f);
        Vector3 hand = new Vector3(.65f, -.1f, -.25f);
        if (character is Merchant)
            Part(figure.transform, material, PrimitiveType.Cube, "Supply crate", hand, Vector3.one * .45f, wood);
        else if (character is Raider)
            Part(figure.transform, material, PrimitiveType.Cube, "Shield", hand, new Vector3(.55f, .8f, .12f), metal);
        else if (character is Infiltrator)
            Part(figure.transform, material, PrimitiveType.Cube, "Dagger", hand, new Vector3(.1f, .65f, .1f), metal);
        else if (character is RescueWorker)
        {
            Part(figure.transform, material, PrimitiveType.Cube, "First aid kit", hand, new Vector3(.55f, .4f, .3f), new Color(.85f, .83f, .73f));
            Part(figure.transform, material, PrimitiveType.Cube, "Cross vertical", hand + Vector3.back * .16f, new Vector3(.08f, .25f, .02f), new Color(.65f, .30f, .27f));
            Part(figure.transform, material, PrimitiveType.Cube, "Cross horizontal", hand + Vector3.back * .16f, new Vector3(.25f, .08f, .02f), new Color(.65f, .30f, .27f));
        }
        else // Night Watch and Shelter Keeper carry lanterns.
        {
            Part(figure.transform, material, PrimitiveType.Cube, "Lantern frame", hand, new Vector3(.37f, .5f, .3f), metal);
            Part(figure.transform, material, PrimitiveType.Cube, "Lantern window", hand + Vector3.back * .16f, new Vector3(.24f, .32f, .02f), new Color(1f, .78f, .35f));
        }
    }

    public static AudioClip CreateSpawnSound()
    {
        const int rate = 22050;
        var samples = new float[rate / 7];
        for (int i = 0; i < samples.Length; i++)
        {
            float t = i / (float)rate;
            float envelope = Mathf.Sin(Mathf.PI * i / samples.Length);
            samples[i] = Mathf.Sin(2 * Mathf.PI * 660 * t) * envelope * envelope * .12f;
        }
        var clip = AudioClip.Create("Soft spawn tone", samples.Length, 1, rate, false);
        clip.SetData(samples, 0);
        return clip;
    }
}
