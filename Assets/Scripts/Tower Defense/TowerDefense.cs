using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerDefense : MonoBehaviour
{
    [SerializeField] private int PlayerHealth = 3;

    [SerializeField] private GameObject GameOverScreen;

    [SerializeField] private TMP_Text HP_text;
    // Start is called before the first frame update
    void Start()
    {
        HP_text.SetText( PlayerHealth.ToString());
    }

    public void PlayerDamaged()
    {
        PlayerHealth--;
        HP_text.SetText( PlayerHealth.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth <= 0)
        {
            GameOverScreen.SetActive(true);
        }
    }
}
