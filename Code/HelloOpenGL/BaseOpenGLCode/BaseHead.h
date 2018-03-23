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

	//��ʼ��GLFW
	//1.����OpenGL Setting
	//2.����Setting���д��ڴ���
	//3.����OpenGL�����к���ָ��

	static int InitializeGLFW()
	{
		glfwInit();

		//����OpenGL Setting
		glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
		glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
		glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);


		//����Setting���д��ڴ���
		window = glfwCreateWindow(SCR_WIDTH, SCR_HEIGHT, "LearnOpenGL", NULL, NULL);
		if (window == NULL) {
			std::cout << "Failed to create GLFW window" << std::endl;
			glfwTerminate();
			return -1;
		}

		glfwMakeContextCurrent(window);//�������Ĵ�������������Ϊ��ǰ��������

		//glfwSetFramebufferSizeCallback(window, framebuffer_size_callback);

		//����OpenGL�����к���ָ��
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