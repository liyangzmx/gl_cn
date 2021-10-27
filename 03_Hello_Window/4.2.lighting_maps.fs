#version 330 core
out vec4 FragColor;

struct Material {
    sampler2D diffuse;
    sampler2D specular;    
    float shininess;
}; 

struct Light {
    vec3 position;
    vec3 direction;

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;

    float constant;
    float linear;
    float quadratic;
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
    vec3 lightDir = normalize(-light.direction);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = light.diffuse * diff * texture(material.diffuse, TexCoords).rgb;  
    
    // specular
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);  
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
    vec3 specular = light.specular * spec * texture(material.specular, TexCoords).rgb;  

    float distance    = length(light.position - FragPos);
    float attenuation = 1.0 / (light.constant + light.linear * distance + 
                light.quadratic * (distance * distance));
    ambient  *= attenuation; 
    diffuse  *= attenuation;
    specular *= attenuation;


    vec3 lightDir2 = normalize(light.position - FragPos);
    float diff2 = max(dot(norm, lightDir), 0.0);
    vec3 diffuse2 = light.diffuse * diff2 * texture(material.diffuse, TexCoords).rgb;  
    
    // specular
    vec3 viewDir2 = normalize(viewPos - FragPos);
    vec3 reflectDir2 = reflect(-lightDir, norm);  
    float spec2 = pow(max(dot(viewDir2, reflectDir2), 0.0), material.shininess);
    vec3 specular2 = light.specular * spec2 * texture(material.specular, TexCoords).rgb;  

    float distance2    = length(light.position - FragPos);
    float attenuation2 = 1.0 / (light.constant + light.linear * distance2 + 
                light.quadratic * (distance2 * distance2));

    vec3 ambient2 = light.ambient * texture(material.diffuse, TexCoords).rgb;
    ambient2  *= attenuation2; 
    diffuse2  *= attenuation2;
    specular2 *= attenuation2;
        
    vec3 result = ambient + diffuse + specular + ambient2 + diffuse2 + specular2;
    FragColor = vec4(result, 1.0);
} 