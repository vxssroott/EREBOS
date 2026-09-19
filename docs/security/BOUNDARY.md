# EREBOS SECURITY BOUNDARY

EREBOS operates only between authorized EREBOS-capable devices governed by
explicit device policy.

The following are NOT security credentials:

- MAC address
- IP address
- Hostname alone

The system must establish cryptographic identity before privileged operations.

Baseline operational capabilities include:

DEVICE_INFO
REACHABILITY
HEALTH
NETWORK_STATUS
SESSION_STATUS

SCREEN_READ
SCREEN_CONTROL
INPUT_CONTROL

CLIPBOARD_READ
CLIPBOARD_WRITE

FILE_READ
FILE_WRITE

PROCESS_INSPECTION
PROCESS_CONTROL

NETWORK_DIAGNOSTICS

TERMINAL_EXECUTION
REMOTE_EXECUTION

CAMERA_ACCESS and MICROPHONE_ACCESS are intentionally absent from the
EREBOS capability model.
