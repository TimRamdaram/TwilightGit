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
        // ѕровер€ем уровень освещенности вокруг персонажа игрока
        Vector3 playerPos = player.transform.position;
        float lightLevel = CalculateLightLevel(playerPos);

        // ќбновл€ем значение шкалы в зависимости от уровн€ освещенности
        if (lightLevel < 0.3f)
        {
            currentDarkness -= Time.deltaTime / 5f;
        }
        else
        {
            currentDarkness += Time.deltaTime / 10f;
        }

        // ќграничиваем значение шкалы в пределах от 0 до 1
        currentDarkness = Mathf.Clamp(currentDarkness, 0f, maxDarkness);

        // ќбновл€ем значение шкалы
        darkMeter.fillAmount = currentDarkness;
    }

    // –ассчитываем уровень освещенности вокруг персонажа
    private float CalculateLightLevel(Vector3 position)
    {
        float lightLevel = 0f;

        // ѕолучаем все источники света на сцене
        Light[] lights = FindObjectsOfType<Light>();

        foreach (Light light in lights)
        {
            // –ассчитываем рассто€ние до источника света
            float distance = Vector3.Distance(position, light.transform.position);

            // ≈сли источник света достаточно близко, добавл€ем его €ркость в общий уровень освещенности
            if (distance < light.range)
            {
                lightLevel += light.intensity / Mathf.Pow(distance, 2);
            }
        }

        // Ќормализуем уровень освещенности в пределах от 0 до 1
        lightLevel = Mathf.Clamp01(lightLevel / 10f);

        return lightLevel;
    }
}