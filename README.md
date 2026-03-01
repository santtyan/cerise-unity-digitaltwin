# CERISE Digital Twin — Unity + ROS2

Digital twin do TurtleBot3 Waffle para visualização e teleoperação via Unity 6.

## Stack
- Unity 6
- ROS2 Humble (via ROS-TCP-Endpoint)
- TurtleBot3 Waffle (Gazebo)

## Funcionalidades
- ✅ Camera streaming (5 Hz, estável 15+ min)
- ✅ Teleop WASD responsivo
- 🔄 LiDAR visualization (em desenvolvimento)

## Startup
```bash
# T1 - ROS Bridge
cd ~/unity_bridge_ws && source install/setup.bash
ros2 run ros_tcp_endpoint default_server_endpoint --ros-args -p ROS_IP:=0.0.0.0

# T2 - Gazebo
export TURTLEBOT3_MODEL=waffle
ros2 launch turtlebot3_gazebo turtlebot3_world.launch.py gui:=false
```

Abrir Unity → Play → controlar com WASD.

## Instituição
UFG - CERISE Lab | Orientador: Prof. Aldo
