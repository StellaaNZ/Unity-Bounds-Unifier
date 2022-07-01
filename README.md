# Unity-Bounds-Unifier
A Unity tool designed for use with VRChat avatar creation. The tool "unifies" all of the mesh renderer bounds to be the same as the chosen mesh in the tool.

After import the package to unity, the tool can be found under Tools/BoundsUnifier

You first need to manually set the bounds of one mesh to the full size.

Bounds Unifier sets all the bounds of Skinned Mesh Renderers that are children to the Parent Object to that of the selected Skinned Mesh Renderer.

With include inactive, inactive gameobjects will get their bounds changed as well, with it off they will be excluded

The mesh being copied can be a child of the parent object and will be ignored.
