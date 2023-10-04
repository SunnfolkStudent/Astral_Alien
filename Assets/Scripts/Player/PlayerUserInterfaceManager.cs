using UnityEngine;
using UnityEngine.UI;


public class PlayerUserInterfaceManager : MonoBehaviour
{
    public PlayerHealthManager playerHealth;
    public Image[] hearts;

    // Update is called once per frame
    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].color = i < playerHealth.health ? 
                new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0.2f);
        }
    }
}
