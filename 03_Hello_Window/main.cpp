#include <glad/glad.h>

// sudo apt install libgles2-mesa-dev
// #define GLFW_INCLUDE_ES3

// sudo apt install libglfw3-dev
#include <GLFW/glfw3.h>

// sudo apt install libglew-dev
// #include <GL/glew.h>

#include <iostream>
#include <stack>
#include <string>
#include <fstream>
#include <cmath>
#include <glm/glm.hpp>
#include <glm/gtc/type_ptr.hpp>
#include <glm/gtc/matrix_transform.hpp>

int main(int argc, const char **arg){
    glfwInit();
    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
    glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
    // glfwWindowHint(GLFW_OPENGL_FORWARD_COMPAT, GL_TRUE);

    GLFWwindow *window = glfwCreateWindow(800, 600, "LearnOpenGL", NULL, NULL);
    if(window == NULL) {
        std::cout << "Failed to create GLFW window" << std::endl;;
        glfwTerminate();
        exit(EXIT_FAILURE);
    }
    glfwMakeContextCurrent(window);
    if(!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress)) {
        std::cout << "Failed to initialize GLAD" << std::endl;
        exit( EXIT_FAILURE);
    }
    glViewport(0, 0, 800, 600);

    exit(EXIT_SUCCESS);
}
