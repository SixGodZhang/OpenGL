#version 330 core
out vec4 FragColor;

in vec3 Normal;
in vec3 FragPos;

struct Material{
	vec3 ambient;
	vec3 diffuse;
	vec3 specular;
	float skininess;
};

struct Light{
	vec3 position;
	
	vec3 ambient;
	vec3 diffuse;
	vec3 specular;
};

uniform Material material;
uniform Light light;

uniform vec3 lightPos;
uniform vec3 viewPos;

void main()
{
	//ambient
	float ambientStrength = 0.1;
	vec3 ambient = light.ambient * ambientStrength * material.ambient;
	
	//diffuse
	vec3 norm = normalize(Normal);
	vec3 lightDir = normalize(lightPos - FragPos);
	float diff = max(dot(norm,lightDir),0);
	vec3 diffuse = light.diffuse * diff * (diff * material.diffuse);
	
	//specular
	float specularStrength;
	vec3 viewDir = normalize(viewPos - FragPos);
	vec3 reflectDir = reflect(-lightDir,norm);
	float spec = pow(max(dot(viewDir,reflectDir),0.0),material.skininess);
	vec3 specular = light.specular * specularStrength * (spec * material.specular);
	
	vec3 result = ambient + diffuse + specular;
    FragColor = vec4(result, 1.0);
}