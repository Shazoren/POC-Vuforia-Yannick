using UnityEngine;

public class LinkButton : MonoBehaviour {
    [SerializeField] string url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ&ab_channel=RickAstley";
    public AudioSource sfx; public AudioClip clickClip;

    public void Open() {
        var u = url?.Trim();
        if (string.IsNullOrEmpty(u)) { Debug.LogError("URL vide."); return; }
        if (!u.StartsWith("http://") && !u.StartsWith("https://")) u = "https://" + u;

        Debug.Log("Opening URL: " + u);
        Application.OpenURL(u);

        if (sfx && clickClip) sfx.PlayOneShot(clickClip, 0.8f);
    }
}
