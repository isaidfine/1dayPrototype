using UnityEngine;
using TMPro;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance { get; private set; }

    public GameObject achievementPopupPrefab; // 成就弹出窗口的预制体
    public Transform popupSpawnPoint; // 弹出窗口的生成位置

    private bool[] achievementsUnlocked;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return; // 确保在销毁对象后不执行后面的代码
        }

        // 确保每次实例化时都会初始化数组，但不会重置已解锁的成就
        if (achievementsUnlocked == null)
        {
            achievementsUnlocked = new bool[5]; // 现在有5个成就
        }
    }

    public void CheckForAchievements(int clicks)
    {
        // 根据点击次数解锁成就
        if (clicks >= 10 && !achievementsUnlocked[0]) UnlockAchievement(0, "Click 10 times!");
        if (clicks >= 100 && !achievementsUnlocked[1]) UnlockAchievement(1, "Click 100 times!");
        if (clicks >= 200 && !achievementsUnlocked[2]) UnlockAchievement(2, "Click 200 times!");
        if (clicks >= 500 && !achievementsUnlocked[3]) UnlockAchievement(3, "Click 500 times!");
        if (clicks >= 1000 && !achievementsUnlocked[4]) UnlockAchievement(4, "Click 1000 times!");
        // ...可添加更多成就条件...
    }

    private void UnlockAchievement(int index, string message)
    {
        achievementsUnlocked[index] = true;
        CreateAchievementPopup(message);
    }

    private void CreateAchievementPopup(string message)
    {
        GameObject popup = Instantiate(achievementPopupPrefab, Vector3.zero, Quaternion.identity);
        popup.transform.SetParent(FindObjectOfType<Canvas>().transform, false); // 设置Canvas为父对象，并保持局部位置和旋转
        TextMeshProUGUI textComponent = popup.GetComponentInChildren<TextMeshProUGUI>();
        textComponent.text = "Achievement Unlocked: " + message;
    
        // 设置3秒后销毁弹出窗口
        Destroy(popup, 4f); // 3f代表3秒后销毁
    }

}