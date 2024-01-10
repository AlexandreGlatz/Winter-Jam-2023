using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{

    public string text;
    public TextMeshProUGUI BarText;


    public void UpdateBar(float progress, float max)
    {
        int formatProgress = ((int)(progress * 100));
        BarText.text = text + formatProgress + "/" + max;
        gameObject.GetComponent<Slider>().value = progress;
    }

}
