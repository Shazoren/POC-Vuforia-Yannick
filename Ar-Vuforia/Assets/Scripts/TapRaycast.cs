using UnityEngine;
using UnityEngine.EventSystems;

public class TapRaycast : MonoBehaviour {
    public Camera arCam;
    public float dragThreshold = 8f; // px

    Vector2 startPos;
    bool moved;

    void Update() {
        // TOUCH
        if (Input.touchCount > 0) {
            var t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began) { moved = false; startPos = t.position; }
            else if (t.phase == TouchPhase.Moved && Vector2.Distance(t.position, startPos) > dragThreshold) moved = true;
            else if (t.phase == TouchPhase.Ended) {
                if (moved) return;
                if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject(t.fingerId)) {
                    Debug.Log("Tap ignoré : sur l'UI");
                    return;
                }
                Raycast3D(t.position);
            }
        }

        // SOURIS (éditeur)
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)) { moved = false; startPos = Input.mousePosition; }
        else if (Input.GetMouseButton(0) && Vector2.Distance((Vector2)Input.mousePosition, startPos) > dragThreshold) moved = true;
        else if (Input.GetMouseButtonUp(0)) {
            if (moved) return;
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) {
                Debug.Log("Click ignoré : sur l'UI");
                return;
            }
            Raycast3D(Input.mousePosition);
        }
#endif
    }

    void Raycast3D(Vector2 screenPos) {
        if (!arCam) arCam = Camera.main;
        var ray = arCam.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out var hit, 100f)) {
            // Cherche un ColorCycler à proximité
            var cc = hit.collider.GetComponent<CardColorCycler>()
                     ?? hit.collider.GetComponentInChildren<CardColorCycler>()
                     ?? hit.collider.GetComponentInParent<CardColorCycler>();
            if (cc) {
                cc.NextColor();
                Debug.Log("ColorCycler.NextColor sur : " + cc.name);
            } else {
                Debug.Log("Raycast touche : " + hit.collider.name + " (pas de ColorCycler trouvé)");
            }
        } else {
            Debug.Log("Raycast : rien touché");
        }
    }
}
