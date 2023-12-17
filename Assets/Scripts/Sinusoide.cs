using UnityEngine;

public class Sinusoide : MonoBehaviour
{
    public int resolution = 100; // R�solution du dessin de la sinuso�de
    public float frequence = 1.0f; // Fr�quence de la sinuso�de
    public float amplitude = 1.0f; // Amplitude de la sinuso�de
    public LineRenderer lineRenderer; // Composant LineRenderer pour dessiner la sinuso�de

    void Start()
    {
        lineRenderer.positionCount = resolution;

        for (int i = 0; i < resolution; i++)
        {
            float x = (float)i / (float)resolution * 10.0f; // �chelle en x, tu peux ajuster la valeur pour �tendre ou r�duire l'affichage
            float y = Mathf.Sin(2 * Mathf.PI * frequence * x) * amplitude; // Calcul de la valeur y en fonction de la sinuso�de

            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}