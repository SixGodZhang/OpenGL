#pragma once
#include <glad/glad.h>
#include <GLFW\glfw3.h>
#include <iostream>

const unsigned int SCR_WIDTH = 800;
const unsigned int SCR_HEIGHT = 600;

class CommonMethod
{
public:
	CommonMethod();
	~CommonMethod();

	static GLFWwindow* window;

	//初始化GLFW
	//1.设置OpenGL Setting
	//2.根据Setting进行窗口创建
	//3.加载OpenGL的所有函数指针

	static int InitializeGLFW()
	{
		glfwInit();

		//设置OpenGL Setting
		glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
		glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
		glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);


		//根据Setting进行窗口创建
		window = glfwCreateWindow(SCR_WIDTH, SCR_HEIGHT, "LearnOpenGL", NULL, NULL);
		if (window == NULL) {
			std::cout << "Failed to create GLFW window" << std::endl;
			glfwTerminate();
			return -1;
		}

		glfwMakeContextCurrent(window);//将创建的窗口上下文设置为当前的上下文

		//glfwSetFramebufferSizeCallback(window, framebuffer_size_callback);

		//加载OpenGL的所有函数指针
		if (!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
		{
			std::cout << "Failed to initialize GLAD" << std::endl;
			return -1;
		}
	}

private:
};

CommonMethod::CommonMethod()
{
}

CommonMethod::~CommonMethod()
{
}