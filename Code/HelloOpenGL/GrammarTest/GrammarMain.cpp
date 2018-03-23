#include <iostream> 
#include <iomanip>
#include <direct.h>

#define random01 (rand()/double(RAND_MAX))

int main()
{
	//C++查看系统当前目录
	char buffer[_MAX_PATH];
	_getcwd(buffer, _MAX_PATH);
	std::cout << buffer << std::endl;
	system("Pause");
	return -1;
}


