using TMPro;
using UnityEngine;

public class BulletUIManager : MonoBehaviour
{
    public static BulletUIManager instance;

    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateText(int bulletsRemaining)
    {
        text.color = Color.black;

        if (bulletsRemaining == 0) 
        {
            text.color = Color.red;
        }
        text.text = $"{bulletsRemaining}";
    }
}