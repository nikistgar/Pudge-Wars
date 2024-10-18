#version 330

out vec4 outputColor;

in vec2 texCoord;
in vec3 ourColor;

uniform sampler2D texture0;

void main()
{
    outputColor = texture(texture0, texCoord) * vec4(ourColor,0.1f);
}