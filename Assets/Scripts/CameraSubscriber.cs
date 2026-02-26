using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Sensor;

public class CameraSubscriber : MonoBehaviour
{
    public UnityEngine.UI.RawImage rawImage;
    private Texture2D tex;
    private float lastUpdate = 0f;
    private const float UPDATE_RATE = 0.2f;
    private byte[] pendingData = null;
    
    void Start()
    {
        tex = new Texture2D(2, 2);
        rawImage.texture = tex;
        ROSConnection.GetOrCreateInstance().Subscribe<CompressedImageMsg>("/camera/image_raw/compressed", QueueImage);
    }
    
    void QueueImage(CompressedImageMsg msg)
    {
        pendingData = msg.data;
    }
    
    void Update()
    {
        if (Time.time - lastUpdate > UPDATE_RATE && pendingData != null)
        {
            tex.LoadImage(pendingData);
            pendingData = null;
            lastUpdate = Time.time;
        }
    }
    
    void OnDestroy()
    {
        if (tex != null) Destroy(tex);
    }
}
