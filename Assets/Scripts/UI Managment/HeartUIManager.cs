using UnityEngine;
using UnityEngine.UI;

public class HeartUIManager : MonoBehaviour
{
    private PlayerHealthManager _target;
    public int numberOfHearts = 3;

    public Image[] hearts;
    private void Start()
    {
        _target = GameObject.Find("Player").GetComponent<PlayerHealthManager>();
    }

    
    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].color = i < _target.health ? new Color32(204, 219, 190, 255) : new Color32(204, 219, 190, 75);
        }
    }
}
