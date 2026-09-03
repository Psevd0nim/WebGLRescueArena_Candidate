# Summary

# Environment

Unity version: 6000.5.4f1

Browser: Google Chrome 153.0.8010.12

Hardware: AMD Ryzen 7 9700X, NVIDIA GeForce RTX 3060 Ti, 32 GB RAM, Windows 11 Home

# Baseline Before:

FPS / Frame Time: 55_enemies idle - mean 6.94 ms (~144 FPS) | 140_enemies idle - mean 6.94 ms (~144 FPS)

Memory: 55_enemies idle — ~146.3 MB | 140_enemies idle — ~146.8 MB | 140_enemies run & shoot — ~147.6 MB (Total Used Memory)

GC Alloc: 55_enemies idle - mean 2.0 KB, 3.9 MB total | 140_enemies idle - mean 5.7 KB, 11.2 MB total (2,000-frame captures)

Build Size: development build - 64.3 MB

Load Time: median of 5 runs - 0.84 s

# Issues Found

# Changes Made

# Measurements After Changes

FPS / Frame Time: 55_enemies idle - mean 6.94 ms (~144 FPS) | 140_enemies idle - mean 6.94 ms (~144 FPS)

Memory: 55_enemies idle — ~146.0 MB | 140_enemies idle — ~146.9 MB | 140_enemies run & shoot with particle effects — ~147.0-148.4 MB (Total Used Memory)

GC Alloc: 55_enemies idle — median 0 B/frame, 180 B total | 140_enemies idle — median 0 B/frame, 1.3 KB total | 140_enemies run & shoot with particle effects — mean 6 B/frame, 12.1 KB total (2,000-frame captures)

Build Size: development build - 66.4 MB, default build - 9.87 MB

Load Time: median of 5 runs - 0.88 s

# Remaining Issues

# What I Would Do Next
