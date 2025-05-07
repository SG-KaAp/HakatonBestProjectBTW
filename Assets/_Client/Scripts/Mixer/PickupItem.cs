using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemName; // Название предмета (например: "Fire", "Water", и т.д.)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Подобрано: " + itemName);
            // Здесь можно добавить в инвентарь, если нужно
            Destroy(gameObject); // Удаляем объект с земли
        }
    }
}
