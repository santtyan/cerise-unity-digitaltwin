#!/bin/bash
set -e

# Source ROS
source /opt/ros/humble/setup.bash
source /ros_ws/install/setup.bash

exec "$@"
