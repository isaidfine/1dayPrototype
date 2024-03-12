using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI clicksText;
    private bool isSubscribed = false; // 记录是否已订阅

    private void Update()
    {
        // 确保只订阅一次
        if (!isSubscribed && ResourceManager.Instance != null)
        {
            ResourceManager.Instance.OnUIUpdate += UpdateUI;
            isSubscribed = true; // 标记已订阅
            UpdateUI(ResourceManager.Instance.GetCoins(), ResourceManager.Instance.GetClicks(),ResourceManager.Instance.GetDebt()); // 立即更新UI
        }
    }

    private void OnDisable()
    {
        if (ResourceManager.Instance != null)
        {
            ResourceManager.Instance.OnUIUpdate -= UpdateUI;
        }
    }

    private void UpdateUI(int coins, int clicks, int debt)
    {
        coinsText.text = "Coins: " + coins;
        clicksText.text = "Clicks: " + clicks;
    }
}