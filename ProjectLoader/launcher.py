import subprocess
import time
import uiautomation as auto

##########################################################################################################################

subprocess.Popen(
    r"C:\Users\Muhan\Desktop\ERG_BTS\ProjectLoader\Camera capture\Camera1\rtsp_gst.exe",
    cwd=r"C:\Users\Muhan\Desktop\ERG_BTS\ProjectLoader\Camera capture\Camera1"
)

time.sleep(1)

window = auto.WindowControl(searchDepth=1, Name="?CapCam передний верхний")

if window.Exists():
    window.MoveWindow(0, 0, 975, 500)

##########################################################################################################################

subprocess.Popen(
    r"C:\Users\Muhan\Desktop\ERG_BTS\ProjectLoader\Camera capture\Camera1\rtsp_gst.exe",
    cwd=r"C:\Users\Muhan\Desktop\ERG_BTS\ProjectLoader\Camera capture\Camera2"
)

time.sleep(1)

window = auto.WindowControl(searchDepth=1, Name="?CapCam левый")

if window.Exists():
    window.MoveWindow(975, 0, 975, 500)

##########################################################################################################################

subprocess.Popen(
    r"C:\Users\Muhan\Desktop\ERG_BTS\ProjectLoader\Camera capture\Camera1\rtsp_gst.exe",
    cwd=r"C:\Users\Muhan\Desktop\ERG_BTS\ProjectLoader\Camera capture\Camera3"
)

time.sleep(1)

window = auto.WindowControl(searchDepth=1, Name="?CapCam правый")

if window.Exists():
    window.MoveWindow(487, 500, 975, 500)

##########################################################################################################################

subprocess.Popen(
    r"C:\Users\Muhan\Desktop\ERG_BTS\ProjectLoader\Audio capture\AudioCamera1\rtsp_gst_audio.exe",
    cwd=r"C:\Users\Muhan\Desktop\ERG_BTS\ProjectLoader\Audio capture\AudioCamera1"
)

time.sleep(1)

window = auto.WindowControl(searchDepth=1, Name="﻿CapAudio звук передний камеры")

if window.Exists():
    window.MoveWindow(1500, 700, 400, 100)