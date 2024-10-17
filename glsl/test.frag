#version 410 core
#extension GL_ARB_separate_shader_objects: enable
out vec4 FragColor;

uniform vec3 sinColor;

void main()
{
    FragColor = vec4(sinColor, 1.0f);
}