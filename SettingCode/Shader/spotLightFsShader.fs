#version 330 core
out vec4 FragColor;//最终片元颜色

struct Material {
    sampler2D diffuse; // 漫反射
    vec3 specular; //镜面反射
    float shininess; //镜面反射强度
}; 

struct Light {
    vec3 position; //聚光源 位置
	vec3 direction; //聚光 方向
	float cutOff;//切光角 内圆锥体余弦值
	float outerCutOff;//切光角 外圆锥体余弦值
	
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
	vec3 lightDir = normalize(light.position - FragPos);
	
	//check if lighting is inside the spotlight cone
	float theta = dot(lightDir,normalize(-light.direction));
	float epsilon = light.cutOff - light.outerCutOff;
	float intensity = clamp((theta - light.outerCutOff)/epsilon,0.0,1.0);
	
	// ambient
	vec3 ambient = light.ambient * texture(material.diffuse, TexCoords).rgb;

	// diffuse 
	vec3 norm = normalize(Normal);
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

	ambient *=attenuation * intensity;
	diffuse *=attenuation * intensity;
	specular *=attenuation * intensity;
		
	vec3 result = ambient + diffuse;
	FragColor = vec4(result, 1.0);



} 