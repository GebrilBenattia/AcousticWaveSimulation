using UnityEngine;

public class Sinusoide : MonoBehaviour
{
    public int resolution = 100; // Résolution du dessin de la sinusoïde
    public float frequence = 1.0f; // Fréquence de la sinusoïde
    public float amplitude = 1.0f; // Amplitude de la sinusoïde
    public LineRenderer lineRenderer; // Composant LineRenderer pour dessiner la sinusoïde

    void Start()
    {
        lineRenderer.positionCount = resolution;

        for (int i = 0; i < resolution; i++)
        {
            float x = (float)i / (float)resolution * 10.0f; // Échelle en x, tu peux ajuster la valeur pour étendre ou réduire l'affichage
            float y = Mathf.Sin(2 * Mathf.PI * frequence * x) * amplitude; // Calcul de la valeur y en fonction de la sinusoïde

            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}