using UnityEngine;
using UnityEngine.EventSystems; // 引入事件系统命名空间
using UnityEngine.UI; // 引入UI命名空间

public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Sprite normalSprite; // 平常状态的Sprite
    public Sprite hoverSprite;  // 鼠标悬停状态的Sprite
    public Sprite pressedSprite; // 按下状态的Sprite
    public AudioClip downSound; // 按下时的音效
    public AudioClip upSound;   // 松开时的音效
    public AudioClip coinSound;

    private Image buttonImage;    // 按钮的Image组件
    private AudioSource audioSource; // 音频源组件
    
    public ResourceManager resourceManager; // 引用资源管理器

    private void Awake()
    {
        if (ResourceManager.Instance != null)
        {
            resourceManager = ResourceManager.Instance;
        }
    }
    private void Start()
    {
        buttonImage = GetComponent<Image>(); // 获取Image组件
        audioSource = GetComponent<AudioSource>(); // 获取音频源组件
        buttonImage.sprite = normalSprite; // 初始设置为普通状态的Sprite
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 鼠标悬停时的操作
        ChangeSprite(hoverSprite);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 鼠标离开时的操作
        ChangeSprite(normalSprite);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // 鼠标按下时的操作
        ChangeSprite(pressedSprite);
        audioSource.PlayOneShot(downSound); // 播放按下时的音效
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 鼠标抬起时的操作
        ChangeSprite(hoverSprite); // 假设抬起后仍然处于悬停状态
        audioSource.PlayOneShot(upSound); // 播放松开时的音效
        audioSource.PlayOneShot(coinSound); // 播放按下时的音效
        
        ButtonClicked();
    }

    void ChangeSprite(Sprite newSprite)
    {
        // 更改按钮的Sprite
        buttonImage.sprite = newSprite;
    }
    
    private void ButtonClicked()
    {
        if (resourceManager != null)
        {
            resourceManager.ButtonClicked(); // 调用资源管理器的按钮点击处理方法
        }
    }
}