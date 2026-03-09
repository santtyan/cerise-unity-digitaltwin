using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Tf2;

public class TFSubscriber : MonoBehaviour
{
    private ROSConnection ros;
    
    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.Subscribe<TFMessageMsg>("/tf", UpdateTransform);
    }
    
    void UpdateTransform(TFMessageMsg msg)
    {
        foreach (var transform in msg.transforms)
        {
            if (transform.child_frame_id == "base_footprint")
            {
                var pos = transform.transform.translation;
                var rot = transform.transform.rotation;
                
                this.transform.position = new Vector3(
                    (float)pos.x, (float)pos.y, (float)pos.z
                );
                
                this.transform.rotation = new Quaternion(
                    (float)rot.x, (float)rot.y, (float)rot.z, (float)rot.w
                );
            }
        }
    }
}
