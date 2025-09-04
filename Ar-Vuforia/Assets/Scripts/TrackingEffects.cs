using UnityEngine;
using Vuforia;

public class TrackingEffects : DefaultObserverEventHandler {
    public Transform popTarget;        // ex : Logo3D
    public float popScale = 1f;        // 1 = scale courante de l'objet (après setup)
    public float popDuration = 0.2f;
    public ParticleSystem sparkle;

    Vector3 baseScale;
    float t = 0f;
    bool popping = false;

    protected override void Start() {
        base.Start();
        if (popTarget) {
            baseScale = popTarget.localScale;
            popScale = baseScale.x;
        }
    }

    protected override void OnTrackingFound() {
        base.OnTrackingFound();
        if (sparkle) sparkle.Play();
        if (popTarget) {
            popping = true; t = 0f;
            popTarget.localScale = baseScale * 0.8f;
        }
    }

    protected override void OnTrackingLost() {
        base.OnTrackingLost();
        popping = false;
        if (popTarget) popTarget.localScale = baseScale;
    }

    void Update() {
        if (popping && popTarget) {
            t += Time.deltaTime / popDuration;
            float k = Mathf.SmoothStep(0.8f, 1f, Mathf.Clamp01(t));
            popTarget.localScale = baseScale * k;
            if (t >= 1f) popping = false;
        }
    }
}
