# CERISE Digital Twin — Unity + ROS2

Digital twin do TurtleBot3 Waffle para visualização e teleoperação via Unity 6.

## Stack

- **Unity 6.3 LTS** (ROS-TCP-Connector)
- **ROS 2 Humble** (via ROS-TCP-Endpoint)
- **Gazebo 11** (TurtleBot3 Waffle headless)
- **Ubuntu 22.04**

## Funcionalidades

- ✅ **Camera streaming** (5 Hz rate-limited, estável 30+ min)
- ✅ **Teleop WASD** (Input System, responsivo)
- ✅ **LiDAR 360° visualization** (LineRenderer real-time)
- ✅ **TF-based tracking** (robô segue transformações ROS)

## Arquitetura
```
ROS 2 Humble ←→ ROS-TCP-Endpoint (Port 10000) ←→ Unity 6
     ↓                                                 ↓
  Gazebo                                      Digital Twin Viz
TurtleBot3 Waffle                         Câmera + LiDAR + Teleop
```

## Startup

### Terminal 1 - ROS Bridge
```bash
cd ~/unity_bridge_ws
source install/setup.bash
ros2 run ros_tcp_endpoint default_server_endpoint --ros-args -p ROS_IP:=0.0.0.0
```

### Terminal 2 - Gazebo
```bash
export TURTLEBOT3_MODEL=waffle
ros2 launch turtlebot3_gazebo turtlebot3_world.launch.py gui:=false
```

### Unity
1. Abrir projeto no Unity Hub
2. Scene: `Assets/Scenes/SampleScene.unity`
3. Play ▶️
4. Controlar com **WASD** (foco na janela Game)

## Estrutura Scripts
```
Assets/Scripts/
├── CameraSubscriber.cs    # Subscribe /camera/image_raw/compressed
├── TeleopController.cs     # Publish /cmd_vel via Input System
├── LidarVisualizer.cs      # Subscribe /scan, render LineRenderer
└── TFSubscriber.cs         # Subscribe /tf, tracking base_footprint
```

## Troubleshooting

**Câmera preta no Game view:**
- Preview funciona? Sistema OK (problema cosmético Canvas)

**WASD não responde:**
- Clicar na janela Game (foco necessário)
- Verificar `Edit → Project Settings → Player → Active Input Handling = Both`

**LiDAR não aparece:**
- Verificar `Hierarchy → RobotBase → LidarViz` (parent-child correto)
- Console sem erros de compilação?

**Queue warnings (amarelo):**
- Normal em alta frequência ROS. Não afeta funcionalidade.

## Próximos Passos

- [ ] MetaQuest VR integration (reunião 18/03)
- [ ] URDF import (modelo 3D TurtleBot3 real)
- [ ] Nav2 path visualization
- [ ] Multi-robot coordination

## Instituição

**UFG - CERISE Lab**  
Orientador: Prof. Alisson  
Desenvolvedor: Yan Tyan

## Licença

MIT
