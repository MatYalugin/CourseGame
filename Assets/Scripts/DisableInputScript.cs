using UnityEngine;

public class DisableInputScript : MonoBehaviour
{
    [SerializeField] private float initialBlockDuration = 8f;
    [SerializeField] private float blockDuration = 2f;

    private bool isInputBlocked = true;

    void Start()
    {
        // Сбрасываем ввод на начальный период времени
        Invoke("UnblockInput", initialBlockDuration);
    }

    void Update()
    {
        if (isInputBlocked)
        {
            // Если ввод заблокирован, сбрасываем все входные данные с клавиатуры и мыши
            Input.ResetInputAxes();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            return;
        }

        // Обработка входных данных
        // ...

    }

    public void BlockInput()
    {
        isInputBlocked = true;
        Invoke("UnblockInput", blockDuration);
    }

    void UnblockInput()
    {
        isInputBlocked = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}