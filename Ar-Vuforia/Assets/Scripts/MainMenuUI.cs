using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuUI : MonoBehaviour {
    [SerializeField] string arSceneName = "ARScene";
    #if UNITY_EDITOR
    [SerializeField] SceneAsset arSceneAsset;
    void OnValidate() { if (arSceneAsset) arSceneName = arSceneAsset.name; }
    #endif

    public void StartAR() {
        if (Application.CanStreamedLevelBeLoaded(arSceneName))
            SceneManager.LoadScene(arSceneName);
        else
            Debug.LogError($"Scene '{arSceneName}' absente des Build Settings.");
    }

    public void QuitApp() {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
