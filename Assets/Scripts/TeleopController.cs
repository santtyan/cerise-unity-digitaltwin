using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Geometry;

public class TeleopController : MonoBehaviour
{
    private ROSConnection ros;
    private float linearSpeed = 0.15f;
    private float angularSpeed = 0.8f;
    
    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<TwistMsg>("/cmd_vel");
    }
    
    void Update()
    {
        float l = 0f, a = 0f;
        
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) l = linearSpeed;
            if (Keyboard.current.sKey.isPressed) l = -linearSpeed;
            if (Keyboard.current.aKey.isPressed) a = angularSpeed;
            if (Keyboard.current.dKey.isPressed) a = -angularSpeed;
        }
        
        ros.Publish("/cmd_vel", new TwistMsg(
            new Vector3Msg(l, 0, 0),
            new Vector3Msg(0, 0, a)
        ));
    }
}
