### Alertness Bar - Linear Interpolation
- Implemented a lerp-based alertness system.
- When the player is within the ghost's view, the alertness bar begins to fill.
- If the bar fills completely, it triggers a fail state.
- The bar gradually decreases when the player is no longer in view.

### Line of Sight Detection - Dot Product
- Added dot product logic to determine if the player is within the ghost’s field of view. If detected, the ghost speeds up.
- Combines directional checks with distance-based detection.

### Visual and Audio Feedback
- Ghosts now have particle trails that visually represent their state.
- The trail material changes when the ghost becomes alerted to the player.
- A sound effect is triggered when the ghost detects the player.
