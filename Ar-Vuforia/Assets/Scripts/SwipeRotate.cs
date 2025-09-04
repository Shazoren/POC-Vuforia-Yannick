using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeRotate : MonoBehaviour {
    [Header("Cible à tourner")]
    public Transform target;              // mets ton objet "Card" ici
    [Header("Réglages")]
    public float sensitivity = 0.2f;      // degrés par pixel (0.15–0.3 confortable)
    public float inertiaDamping = 5f;     // amortissement (plus grand = s’arrête vite)
    public float maxSpeed = 360f;         // vitesse max (deg/s)
    public float minDragToCount = 8f;     // pixels avant de considérer un drag (évite faux taps)

    Vector2 lastPos;
    bool dragging;
    float angularVelocity;
    int activeFingerId = -1;

    void Update() {
        if (Input.touchCount > 0) {
            for (int i = 0; i < Input.touchCount; i++) {
                var t = Input.GetTouch(i);
                if (activeFingerId == -1 && t.phase == TouchPhase.Began) {
                    if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject(t.fingerId))
                        continue; // ignore UI
                    activeFingerId = t.fingerId;
                    lastPos = t.position;
                    dragging = false;
                    angularVelocity = 0f;
                    break;
                }
                if (t.fingerId == activeFingerId) {
                    if (t.phase == TouchPhase.Moved) {
                        var dx = t.position.x - lastPos.x;
                        if (!dragging && Mathf.Abs(dx) > minDragToCount) dragging = true;
                        if (dragging) {
                            float deltaDeg = dx * sensitivity;
                            Rotate(deltaDeg);
                            angularVelocity = Mathf.Clamp((deltaDeg / Time.deltaTime), -maxSpeed, maxSpeed);
                        }
                        lastPos = t.position;
                    } else if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled) {
                        activeFingerId = -1;
                    }
                }
            }
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)) {
            if (EventSystem.current == null || !EventSystem.current.IsPointerOverGameObject()) {
                lastPos = Input.mousePosition;
                dragging = false;
                angularVelocity = 0f;
            }
        }
        if (Input.GetMouseButton(0)) {
            var cur = (Vector2)Input.mousePosition;
            var dx = cur.x - lastPos.x;
            if (!dragging && Mathf.Abs(dx) > minDragToCount) dragging = true;
            if (dragging) {
                float deltaDeg = -dx * sensitivity;
                Rotate(deltaDeg);
                angularVelocity = Mathf.Clamp((deltaDeg / Time.deltaTime), -maxSpeed, maxSpeed);
            }
            lastPos = cur;
        }
#endif
        if (!dragging && Mathf.Abs(angularVelocity) > 0.01f) {
            Rotate(angularVelocity * Time.deltaTime);
            angularVelocity = Mathf.MoveTowards(angularVelocity, 0f, inertiaDamping * Time.deltaTime * Mathf.Sign(angularVelocity) * Mathf.Abs(angularVelocity) / maxSpeed);
        }
    }

    void Rotate(float deltaDeg) {
        if (!target) target = transform;
        target.Rotate(Vector3.up, deltaDeg, Space.Self);
    }
}
