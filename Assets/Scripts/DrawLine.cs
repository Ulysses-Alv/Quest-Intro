using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private int linePoints;
    [SerializeField] private float timeBtwPoints;

    private bool canDraw;
    public void DrawTrajectory(Vector3 origin, Vector3 velocity)
    {
        if (!canDraw) return;

        lineRenderer.positionCount = Mathf.CeilToInt(linePoints / timeBtwPoints);
        float time = 0;

        for (int i = 0; i < linePoints; i++)
        {
            Vector3 point = velocity * time + (Physics.gravity / 2 * time * time);

            lineRenderer.SetPosition(i, origin + point);
            time += timeBtwPoints;
        }
    }
    public void ActivateDraw()
    {
        canDraw = true;
        lineRenderer.enabled = true;
    }
    public void DeactivateDraw()
    {
        canDraw = false;

        lineRenderer.enabled = false;
    }
}