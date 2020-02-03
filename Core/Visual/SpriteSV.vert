﻿//!#version 450

// Resource Sets
layout(binding = 0) uniform _Projection { mat4 uProjection; };
layout(binding = 1) uniform _View { mat4 uView; };

// Shared set
#include "CommonResources.glsl"

// Vertex Data
layout(location = 0) in vec2 vPosition;
layout(location = 1) in vec2 vTexCoords;

// Instance Data
layout(location = 2) in vec3 iT1;
layout(location = 3) in vec3 iT2;
layout(location = 4) in vec3 iT3;
layout(location = 5) in vec3 iT4;
layout(location = 6) in vec2 iTexOffset;
layout(location = 7) in vec2 iTexSize;
layout(location = 8) in int  iTexLayer;
layout(location = 9) in uint iFlags;

// Outputs to fragment shader
layout(location = 0) out vec2 oTexPosition;   // Texture Coordinates
layout(location = 1) out flat float oLayer;   // Texture Layer
layout(location = 2) out flat uint oFlags;    // Flags
layout(location = 3) out vec2 oNormCoords;    // Normalised sprite coordinates
layout(location = 4) out vec3 oWorldPosition; // World position

void main()
{
	mat4 transform = mat4(vec4(iT1, 0), vec4(iT2, 0), vec4(iT3, 0), vec4(iT4, 1));

	if ((iFlags & SF_BILLBOARD) != 0)
	{
		float c = cos(-u_camera_look_direction.x);
		float s = sin(-u_camera_look_direction.x);
		transform = transform * mat4(
			c, 0, s, 0,
			0, 1, 0, 0,
		   -s, 0, c, 0,
			0, 0, 0, 1);
	}

	vec4 worldSpace = transform * vec4(vPosition, 0, 1);

	vec4 normPosition = ((iFlags & SF_NO_TRANSFORM) == 0)
		? uProjection * uView * worldSpace
		:               uView * worldSpace;

	gl_Position = normPosition;

	oTexPosition = vTexCoords * iTexSize + iTexOffset;
	oLayer = float(iTexLayer);
	oFlags = iFlags;
	oNormCoords = vTexCoords;
	oWorldPosition = worldSpace.xyz;
}

