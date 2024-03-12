using UnityEngine;
using TMPro;

public class DebtButton : MonoBehaviour
{
    public TextMeshProUGUI debtText; // 显示debt的TextMeshPro组件
    public TextMeshProUGUI coinsText; // 显示coins的TextMeshPro组件

    private void OnEnable()
    {
        if (ResourceManager.Instance != null)
        {
            ResourceManager.Instance.OnUIUpdate += UpdateUI;
        }
    }

    private void OnDisable()
    {
        if (ResourceManager.Instance != null)
        {
            ResourceManager.Instance.OnUIUpdate -= UpdateUI;
        }
    }

    public void OnButtonClick()
    {
        ResourceManager.Instance.ReduceDebtAndCoins(); // 点击时减少debt和coins
    }

    private void UpdateUI(int coins, int clicks, int debt)
    {
        debtText.text = "Debt: " + debt;
        coinsText.text = "Coins: " + coins;
    }
}