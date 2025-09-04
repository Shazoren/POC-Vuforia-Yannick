using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    private static MusicLoop _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);   // il y en a déjà un : on détruit le doublon
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
