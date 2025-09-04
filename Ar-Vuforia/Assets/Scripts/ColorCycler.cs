using UnityEngine;

public class CardColorCycler : MonoBehaviour {
    public MeshRenderer[] renderers;
    public Color[] colors = { Color.white, Color.green, Color.cyan, Color.magenta };
    public int startIndex = 0;

    [Header("Audio")]
    public AudioClip tapSound;
    public float volume = 0.8f;

    int i;
    MaterialPropertyBlock mpb;
    AudioSource audioSource;

    void Awake() {
        if (renderers == null || renderers.Length == 0)
            renderers = GetComponentsInChildren<MeshRenderer>(true);

        mpb = new MaterialPropertyBlock();

        // Ajoute un AudioSource automatiquement si absent
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0; // son 2D
    }

    void Start() {
        i = Mathf.Clamp(startIndex, 0, colors.Length - 1);
        Apply();
    }

    void Apply() {
        var c = colors[i];
        foreach (var r in renderers) {
            if (!r) continue;
            r.GetPropertyBlock(mpb);
            mpb.SetColor("_Color", c);
            mpb.SetColor("_BaseColor", c);
            r.SetPropertyBlock(mpb);
        }
    }

    public void NextColor() {
        i = (i + 1) % colors.Length;
        Apply();

        // Joue le son si dispo
        if (tapSound && audioSource) {
            audioSource.PlayOneShot(tapSound, volume);
        }
    }
}
