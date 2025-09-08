import uiautomation as auto
import time
import sys

try:
    while True:
        x, y = auto.GetCursorPos()
        sys.stdout.write(f"\rX: {x:<5} Y: {y:<5}")
        sys.stdout.flush()
        time.sleep(0.1)
except KeyboardInterrupt:
    print("\n")