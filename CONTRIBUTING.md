# Contributing to EREBOS

EREBOS is security-sensitive infrastructure. Changes must preserve explicit architectural boundaries.

## Engineering Rules

- Prefer small, auditable changes.
- Do not silently weaken security boundaries to make tests pass.
- Do not introduce unnecessary SYSTEM privileges.
- Do not commit secrets.
- Do not make undocumented protocol changes.
- Add or update tests for security-sensitive behavior.
- Keep implementation claims aligned with verified behavior.

## Change Workflow

1. Inspect the architecture.
2. Identify the affected contract.
3. Make the smallest appropriate change.
4. Build.
5. Run affected tests.
6. Run broader tests when boundaries are crossed.
7. Review the final diff.
8. Commit with a descriptive message.

## Security-Sensitive Changes

Identity, cryptography, enrollment, authorization, capabilities, session state, privilege boundaries, and transport security require particular scrutiny.

Never substitute a passing test for an architectural security argument.
