using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; } // 单例实例
    
    private int coins = 0; // 玩家的金币数量
    private int clicks = 0; // 玩家点击按钮的次数
    private int debt = 3000;
    
    public delegate void UpdateUI(int coins, int clicks, int debt); // 定义委托
    public UpdateUI OnUIUpdate; // UI更新事件

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 防止在加载新场景时被销毁
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // 销毁额外的实例
        }
    }
   
    public void ReduceDebtAndCoins()
    {
        if (coins > 0) // 检查是否有足够的coins
        {
            coins--; // 减少coins
            if (debt > 0) debt--; // 如果还有debt，则同时减少debt

            OnUIUpdate?.Invoke(coins, clicks, debt); // 更新UI
        }
        else
        {
            // 可以在这里处理coins不足的情况，比如显示一个警告消息
        }
    }
    
    public void AddCoins(int amount)
    {
        coins += amount;
       
    }
    public void RemoveCoins(int amount)
    {
        coins -= amount;
        if (coins < 0) coins = 0; // 确保金币数量不会变成负数
        OnUIUpdate?.Invoke(coins, clicks, debt); // 更新UI
    }
    public void ButtonClicked()
    {
        clicks++;
        

        // 根据强化解锁和其他条件调整增加的金币数量
        int coinsToAdd = CalculateCoinsToAdd();
        AddCoins(coinsToAdd);
        
        // 调用UI更新事件
        OnUIUpdate?.Invoke(coins, clicks, debt);
        
        // 检查成就
        AchievementManager.Instance.CheckForAchievements(clicks);
    }

    private int CalculateCoinsToAdd()
    {
        // 在这里实现金币增加的复杂逻辑
        // 比如根据解锁的能力或其他条件来确定增加的金币数量
        // 暂时返回1作为示例
        return 1;
    }

   

    public int GetCoins()
    {
        return coins;
    }

    public int GetClicks()
    {
        return clicks;
    }
    
    public int GetDebt()
    {
        return debt;
    }
}