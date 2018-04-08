#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

uniform sampler2D texture1;

void main()
{    
	vec4 texColor = texture(texture1,TexCoords);
	//丢弃片段
	//if(texColor.a < 0.1)
		//discard;
	FragColor = texColor;

	//FragColor = texture(texture1, TexCoords);
	//FragColor = vec4(vec3(gl_FragCoord.z),1.0);
}