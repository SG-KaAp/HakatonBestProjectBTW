using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemName; // �������� �������� (��������: "Fire", "Water", � �.�.)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("���������: " + itemName);
            // ����� ����� �������� � ���������, ���� �����
            Destroy(gameObject); // ������� ������ � �����
        }
    }
}
