using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Sensor;

public class LidarVisualizer : MonoBehaviour
{
    private LineRenderer lr;
    public Color startColor = Color.red;
    public Color endColor = Color.yellow;
    public float lineWidth = 0.05f;
    
    void Start()
    {
        lr = gameObject.AddComponent<LineRenderer>();
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = startColor;
        lr.endColor = endColor;
        lr.useWorldSpace = false;
        
        ROSConnection.GetOrCreateInstance().Subscribe<LaserScanMsg>("/scan", DrawScan);
    }
    
    void DrawScan(LaserScanMsg scan)
    {
        lr.positionCount = scan.ranges.Length;
        
        for (int i = 0; i < scan.ranges.Length; i++)
        {
            float angle = scan.angle_min + i * scan.angle_increment;
            float range = scan.ranges[i];
            
            if (range > scan.range_max || range < scan.range_min)
                range = 0f;
            
            float x = range * Mathf.Cos(angle);
            float z = range * Mathf.Sin(angle);
            
            lr.SetPosition(i, new Vector3(x, 0, z));
        }
    }
}
