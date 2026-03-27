FROM osrf/ros:humble-desktop

# Instalar dependências
RUN apt-get update && apt-get install -y \
    ros-humble-gazebo-ros-pkgs \
    ros-humble-turtlebot3 \
    ros-humble-turtlebot3-simulations \
    python3-pip \
    git \
    && rm -rf /var/lib/apt/lists/*

# ROS-TCP-Endpoint
ENV PIP_BREAK_SYSTEM_PACKAGES=1
RUN pip3 install rospkg catkin_pkg

WORKDIR /ros_ws
RUN mkdir -p src && \
    cd src && \
    git clone -b main-ros2 https://github.com/Unity-Technologies/ROS-TCP-Endpoint.git

# Build workspace
RUN . /opt/ros/humble/setup.sh && \
    colcon build

# Variáveis ambiente
ENV TURTLEBOT3_MODEL=waffle
ENV ROS_DOMAIN_ID=0

# Entrypoint
COPY entrypoint.sh /
RUN chmod +x /entrypoint.sh
ENTRYPOINT ["/entrypoint.sh"]
CMD ["bash"]
