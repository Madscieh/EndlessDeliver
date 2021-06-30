using UnityEngine;
using UnityEngine.UI;

public class ChangeAlpha : MonoBehaviour
{
    public GameObject[] button;

    private void Awake()
    {
        for (int i = 0; i < button.Length; i++)
        {
            Image image = button[i].GetComponent<Image>();
            Color color = image.color;
            color.a = 0;
        }
    }
    public void TrocaAlfa()
    {
        Image image = gameObject.GetComponent<Image>();
        Color color = image.color;

        if (color.a == 0)
        {
            color.a = .5f;
        }
        else
        {
            color.a = 0;
        }
    }
}
