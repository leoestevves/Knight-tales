using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHeathBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
        totalHeathBar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10; // Imagem tem 10 cora��es, dividindo por 10 fica a quantidade de cora��es que eu quero
    }

}
