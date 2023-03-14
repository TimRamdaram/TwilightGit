using UnityEngine;
using UnityEngine.UI;

public class DarknessMeter : MonoBehaviour
{
    public Image darkMeter;
    public GameObject player;

    private float maxDarkness = 1f;
    private float currentDarkness;

    private void Start()
    {
        currentDarkness = maxDarkness;
    }

    private void Update()
    {
        // ��������� ������� ������������ ������ ��������� ������
        Vector3 playerPos = player.transform.position;
        float lightLevel = CalculateLightLevel(playerPos);

        // ��������� �������� ����� � ����������� �� ������ ������������
        if (lightLevel < 0.3f)
        {
            currentDarkness -= Time.deltaTime / 5f;
        }
        else
        {
            currentDarkness += Time.deltaTime / 10f;
        }

        // ������������ �������� ����� � �������� �� 0 �� 1
        currentDarkness = Mathf.Clamp(currentDarkness, 0f, maxDarkness);

        // ��������� �������� �����
        darkMeter.fillAmount = currentDarkness;
    }

    // ������������ ������� ������������ ������ ���������
    private float CalculateLightLevel(Vector3 position)
    {
        float lightLevel = 0f;

        // �������� ��� ��������� ����� �� �����
        Light[] lights = FindObjectsOfType<Light>();

        foreach (Light light in lights)
        {
            // ������������ ���������� �� ��������� �����
            float distance = Vector3.Distance(position, light.transform.position);

            // ���� �������� ����� ���������� ������, ��������� ��� ������� � ����� ������� ������������
            if (distance < light.range)
            {
                lightLevel += light.intensity / Mathf.Pow(distance, 2);
            }
        }

        // ����������� ������� ������������ � �������� �� 0 �� 1
        lightLevel = Mathf.Clamp01(lightLevel / 10f);

        return lightLevel;
    }
}