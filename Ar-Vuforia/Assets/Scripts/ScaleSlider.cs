using UnityEngine; using UnityEngine.UI;
public class ScaleSlider : MonoBehaviour {
    public Transform target;
    public Slider slider;
    public float min = 0.5f, max = 2f;
    Vector3 initial;
    void Start(){
        if(!target) target = transform;
        initial = target.localScale;
        slider.minValue = 0f; slider.maxValue = 1f; slider.value = 0.5f;
        slider.onValueChanged.AddListener(v => {
            float s = Mathf.Lerp(min, max, v);
            target.localScale = initial * s;
        });
    }
}
