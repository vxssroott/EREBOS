# EREBOS — BUILD ARCHITECTURE

Ephemeral Remote Execution & Boundary Orchestration System

## 10 PHASES / 21 SYSTEMS

### PHASE 1 — FOUNDATION
1. System Identity

### PHASE 2 — PRESENCE
2. Autonomous Presence Fabric

### PHASE 3 — HUMAN INTERACTION
3. Human Interaction Layer

### PHASE 4 — PEER + NETWORK
4. Peer Resolution & Session Establishment
5. Network Fabric

### PHASE 5 — CAPABILITY + COMPUTE
6. Capability Architecture
7. Remote Desktop / Screen Plane
8. Clipboard Fabric
9. Personal Distributed File Fabric
10. Process Fabric
11. Terminal / Remote Execution Plane
12. Network Inspection Plane

### PHASE 6 — SESSION + SECURITY
13. Session Fabric
14. Security / Trust Architecture

### PHASE 7 — RUNTIME
15. Persistent Agent
16. Ephemeral Runtime

### PHASE 8 — PROTOCOL PLANES
17. Control Plane
18. Data Plane
19. Media Plane
20. Audit Plane

### PHASE 9 — OBSERVABILITY
21. Observability

### PHASE 10 — INTEGRATION + HARDENING

Phase 10 integrates and hardens systems 1–21.

---

## BUILD RULE

Implementation proceeds strictly:

1 → 2 → 3 → 4 → 5 → 6 → 7 → 8 → 9 → 10 → 11
→ 12 → 13 → 14 → 15 → 16 → 17 → 18 → 19 → 20 → 21

A directory is NOT an implementation.

Each system requires:

- Architecture
- Contracts
- Implementation
- Unit tests
- Integration tests where applicable
- Security verification
- Failure handling
- Observability
- Acceptance criteria
- Git commit

---

## NORTH STAR

erebos
  ↓
DISCOVER
  ↓
IDENTIFY
  ↓
AUTHENTICATE
  ↓
RESOLVE POLICY
  ↓
RESOLVE CAPABILITIES
  ↓
SELECT TRANSPORT
  ↓
ESTABLISH SESSION
  ↓
OPERATE
  ↓
AUDIT
  ↓
TERMINATE / REVOKE
