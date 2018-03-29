#version 330 core
out vec4 FragColor;//最终片元颜色

struct Material {
    sampler2D diffuse; // 漫反射
    vec3 specular; //镜面反射
    float shininess; //镜面反射强度
}; 

struct Light {
    vec3 position; //光源 位置
	//vec3 direction; //光 方向
	
    vec3 ambient; //环境光 颜色
    vec3 diffuse; //漫反射 颜色
    vec3 specular; //镜面反射 颜色
	
	//光照衰减系数
	float constant;// 常数项
	float linear;//一次项
	float quadratic;//二次项
};

in vec3 FragPos;  
in vec3 Normal;  
in vec2 TexCoords;
  
uniform vec3 viewPos;
uniform Material material;
uniform Light light;

void main()
{
    // ambient
    vec3 ambient = light.ambient * texture(material.diffuse, TexCoords).rgb;
  	
    // diffuse 
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(light.position - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = light.diffuse * diff * texture(material.diffuse, TexCoords).rgb;  
    
    // specular
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);  
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
    vec3 specular = light.specular * spec * material.specular;  
	
	//attenuation(衰减)
	float distance = length(light.position - FragPos);
	float attenuation = 1.0 / (light.constant + light.linear * distance + light.quadratic * (distance*distance));
	
	ambient *=attenuation;
	diffuse *=attenuation;
	specular *=attenuation;
        
    vec3 result = ambient + diffuse + specular;
    FragColor = vec4(result, 1.0);
} 